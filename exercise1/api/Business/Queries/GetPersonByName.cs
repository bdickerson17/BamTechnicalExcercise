using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Data;
using StargateAPI.Business.Dtos;
using StargateAPI.Controllers;

namespace StargateAPI.Business.Queries
{
    public class GetPersonByName : IRequest<GetPersonByNameResult>
    {
        public required string Name { get; set; } = string.Empty;
    }

    public class GetPersonByNameHandler : IRequestHandler<GetPersonByName, GetPersonByNameResult>
    {
        private readonly StargateContext _context;
        public GetPersonByNameHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetPersonByNameResult> Handle(GetPersonByName request, CancellationToken cancellationToken)
        {
            var result = new GetPersonByNameResult();

            //var query = $"SELECT a.Id as PersonId, a.Name, b.CurrentRank, b.CurrentDutyTitle, b.CareerStartDate, b.CareerEndDate FROM [Person] a LEFT JOIN [AstronautDetail] b on b.PersonId = a.Id WHERE '{request.Name}' = a.Name";

            var person = await _context.People
                .Include(p => p.AstronautDuties)
                .FirstOrDefaultAsync(p => p.Name == request.Name);

            if(person == null)
            {
                throw new Exception($"No Person found with name {request.Name}");
            }

            PersonAstronaut personAstronaut = new PersonAstronaut
            {
                PersonId = person.Id,
                Name = person.Name,
                CurrentRank = person.AstronautDetail?.Rank,
                CurrentDutyTitle = person.AstronautDetail?.DutyTitle,
                CareerStartDate = person.AstronautDetail?.DutyStartDate,
                CareerEndDate = person.AstronautDetail?.DutyEndDate
            };

            result.Person = personAstronaut;

            return result;
        }
    }

    public class GetPersonByNameResult : BaseResponse
    {
        public PersonAstronaut? Person { get; set; }
    }
}
