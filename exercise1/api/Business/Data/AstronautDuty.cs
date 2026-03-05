using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StargateAPI.Business.Data
{
    [Table("AstronautDuty")]
    public class AstronautDuty
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Rank { get; set; } = string.Empty;

        public string DutyTitle { get; set; } = string.Empty;

        public DateTime DutyStartDate { get; set; }

        public DateTime? DutyEndDate { get; set; }

        //should this be nullable as AstronautDuties is a master list? Should be able to exist without being assinged to a Person?
        public virtual Person Person { get; set; }
    }

    public class AstronautDutyConfiguration : IEntityTypeConfiguration<AstronautDuty>
    {
        public void Configure(EntityTypeBuilder<AstronautDuty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(d => d.Person)
               .WithMany(p => p.AstronautDuties)
               .HasForeignKey(d => d.PersonId)
               .OnDelete(DeleteBehavior.Cascade);

            //only one active/current duty per person
            builder.HasIndex(x => x.PersonId)
                .IsUnique()
                .HasFilter("DutyEndDate IS NULL");
            builder.Property(d => d.DutyEndDate)
                .IsRequired(false); //even with ? in the class I want to ensure its clear DutyEndDate is nullable
        }
    }
}
