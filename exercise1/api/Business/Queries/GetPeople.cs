using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StargateAPI.Business.Data;
using StargateAPI.Business.Dtos;
using StargateAPI.Controllers;

namespace StargateAPI.Business.Queries
{
    public class GetPeople : IRequest<GetPeopleResult>
    {

    }

    public class GetPeopleHandler : IRequestHandler<GetPeople, GetPeopleResult>
    {
        public readonly StargateContext _context;
        public GetPeopleHandler(StargateContext context)
        {
            _context = context;
        }
        
        //Get People result should return all People not just People with Astronaut duties
        //Separate request GetAstronauts should exist
        public async Task<GetPeopleResult> Handle(GetPeople request, CancellationToken cancellationToken)
        {
            var result = new GetPeopleResult();

            var people = await _context.People
                .Include(p=>p.AstronautDuties)
                .ToListAsync();

            result.People = people.Select(p => new PersonAstronaut
            {
                PersonId = p.Id,
                Name = p.Name,
                CurrentRank = p.AstronautDetail != null ? p.AstronautDetail.Rank : null,
                CurrentDutyTitle = p.AstronautDetail != null ? p.AstronautDetail.DutyTitle : null,
                CareerStartDate = p.AstronautDetail != null ? p.AstronautDetail.DutyStartDate : null,
                CareerEndDate = p.AstronautDetail != null ? p.AstronautDetail.DutyEndDate : null
            }).ToList();

            return result;
        }
    }

    public class GetPeopleResult : BaseResponse
    {
        public List<PersonAstronaut> People { get; set; } = new List<PersonAstronaut> { };

    }
}
