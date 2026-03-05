using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq; 
using StargateAPI.Business.Data;
using StargateAPI.Business.Dtos;
using StargateAPI.Controllers;

namespace StargateAPI.Business.Queries
{
    public class GetAstronautDutiesByName : IRequest<GetAstronautDutiesByNameResult>
    {
        public string Name { get; set; } = string.Empty;
    }

    public class GetAstronautDutiesByNameHandler : IRequestHandler<GetAstronautDutiesByName, GetAstronautDutiesByNameResult>
    {
        private readonly StargateContext _context;

        public GetAstronautDutiesByNameHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetAstronautDutiesByNameResult> Handle(GetAstronautDutiesByName request, CancellationToken cancellationToken)
        {

            var result = new GetAstronautDutiesByNameResult();

            var person = await _context.People
                .Include(p => p.AstronautDuties)
                .FirstOrDefaultAsync(p => p.Name == request.Name, cancellationToken);

            if (person == null)
            {
                throw new Exception($"No person found with name {request.Name}");
            }
            else{

                //would rather use mapper or constructor with person with astronautDuties included but this is fine for now
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
                result.AstronautDuties = person.AstronautDuties.ToList();
            }


            return result;

        }
    }

    public class GetAstronautDutiesByNameResult : BaseResponse
    {
        public PersonAstronaut Person { get; set; }
        public List<AstronautDuty> AstronautDuties { get; set; } = new List<AstronautDuty>();
    }
}
