using System;
using StargateAPI.Business.Data;

namespace StargateAPI.Business.Dtos
{
    public class PersonAstronaut
    {
        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string CurrentRank { get; set; } = string.Empty;

        public string CurrentDutyTitle { get; set; } = string.Empty;

        public DateTime? CareerStartDate { get; set; }

        public DateTime? CareerEndDate { get; set; }

        public PersonAstronaut()
        {
        }

        public PersonAstronaut(Person person)
        {
            if (person is null)
            {
                return;
            }

            PersonId = person.Id;
            Name = person.Name;

            var detail = person.AstronautDetail;

            CurrentRank = detail?.Rank ?? string.Empty;
            CurrentDutyTitle = detail?.DutyTitle ?? string.Empty;
            CareerStartDate = detail?.DutyStartDate;

            // Person.CareerEndDate is computed on Person (non-nullable)
            // set DTO CareerEndDate only when the person is retired
            CareerEndDate = person.IsRetired ? person.CareerEndDate : null;
        }
    }
}
