using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StargateAPI.Business.Data
{
    [Table("Person")]
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<AstronautDuty> AstronautDuties { get; set; } = new HashSet<AstronautDuty>();


        //Rather than having AstronautDetail as a separate table and variable on person
        //Use a query to grab current duties from the AstronautDuties collection associated with Person
        [NotMapped]
        public AstronautDuty? AstronautDetail => AstronautDuties.SingleOrDefault(d => d.DutyEndDate == null);

        [NotMapped]
        public bool IsRetired => AstronautDetail?.DutyTitle == "RETIRED";

        [NotMapped]
        public DateTime CareerEndDate => AstronautDetail != null && IsRetired
            ? AstronautDetail.DutyStartDate.AddDays(-1)
            : default;

        [NotMapped]
        public bool IsAstronaut => AstronautDuties.Count != 0;

    }


    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(z => z.AstronautDuties).WithOne(z => z.Person).HasForeignKey(z => z.PersonId);

            //uniquely identified by name
            builder.HasIndex(p => p.Name)
                .IsUnique();

        }
    }
}
