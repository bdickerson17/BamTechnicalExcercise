using StargateAPI.Business.Data;

namespace StargateAPI.Business.Dtos;

public class AstronautDutyDto
{
    public int Id { get; set; }
    public int PersonId { get; set; }

    public string Rank { get; set; } = string.Empty;

    public string DutyTitle { get; set; } = string.Empty;

    public DateTime DutyStartDate { get; set; }

    public DateTime? DutyEndDate { get; set; }

    public AstronautDutyDto()
    {
    }

    public AstronautDutyDto(AstronautDuty duty)
    {
        if(duty is null)
        {
            return;
        }

        Id = duty.Id;
        PersonId = duty.PersonId;
        Rank = duty.Rank;
        DutyTitle = duty.DutyTitle;
        DutyStartDate = duty.DutyStartDate;
        DutyEndDate = duty.DutyEndDate;
    }


}


