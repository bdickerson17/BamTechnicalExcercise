using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StargateAPI.Business.Data
{
    public class StargateContext : DbContext
    {
        public IDbConnection Connection => Database.GetDbConnection();
        public DbSet<Person> People { get; set; }
        public DbSet<AstronautDuty> AstronautDuties { get; set; }

        public StargateContext(DbContextOptions<StargateContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //applies all class configurations defined in individual classes
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StargateContext).Assembly);

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            HandleNewDuties();          
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleNewDuties();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleNewDuties()
        {
            var newDuties = ChangeTracker.Entries<AstronautDuty>()
                .Where(d => d.State == EntityState.Added)
                .Select(e => e.Entity);


            foreach (var duty in newDuties)
            {

                //validate if new duty has an invalid person Id
                var person = People.Include(p => p.AstronautDuties)
                    .SingleOrDefault(p => p.Id == duty.PersonId);
                if(person == null)
                {
                    throw new InvalidOperationException($"Person with Id {duty.PersonId} not found.");
                }

                
                //set new duty starts after Previous Duty
                var previousDuty = AstronautDuties
                    .Where(d => d.PersonId == duty.PersonId && d.DutyEndDate == null)
                    .SingleOrDefault();

                if(previousDuty != null && duty.DutyStartDate >= previousDuty.DutyEndDate)
                {
                    throw new InvalidOperationException($"New duty with title {duty.DutyTitle} with start date of {duty.DutyStartDate:d} must be after previous duty end date {previousDuty.DutyEndDate}.");
                }

                if (previousDuty != null)
                {
                    previousDuty.DutyEndDate = duty.DutyStartDate.AddDays(-1);
                    Entry(previousDuty).State = EntityState.Modified;
                }
            }

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            //add seed data
            modelBuilder.Entity<Person>()
                .HasData(
                    new Person
                    {
                        Id = 1,
                        Name = "John Doe"
                    },
                    new Person
                    {
                        Id = 2,
                        Name = "Jane Doe"
                    }
                );

            //modelBuilder.Entity<AstronautDetail>()
            //    .HasData(
            //        new AstronautDetail
            //        {
            //            Id = 1,
            //            PersonId = 1,
            //            CurrentRank = "1LT",
            //            CurrentDutyTitle = "Commander",
            //            CareerStartDate = DateTime.Now
            //        }
            //    );

            modelBuilder.Entity<AstronautDuty>()
                .HasData(
                    new AstronautDuty
                    {
                        Id = 1,
                        PersonId = 1,
                        DutyStartDate = DateTime.Now,
                        DutyTitle = "Commander",
                        Rank = "1LT"
                    }
                );
        }
    }
}
