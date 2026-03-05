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
                    //new Person { Id = 1, Name = "John Doe" },
                    //new Person { Id = 2, Name = "Jane Doe" },
                    new Person { Id = 3, Name = "Gandolf" },
                    new Person { Id = 4, Name = "Cooper Howard" },
                    new Person { Id = 5, Name = "The Wander" },
                    new Person { Id = 6, Name = "Lucy Mcclain" },
                    new Person { Id = 7, Name = "Barbara Howard" },
                    new Person { Id = 8, Name = "Frodo Baggins" },
                    new Person { Id = 9, Name = "Cassian Andor" },
                    new Person { Id = 10, Name = "Jon Snow" },
                    new Person { Id = 11, Name = "Alexander Hamilton" }
                );

            modelBuilder.Entity<AstronautDuty>()
                .HasData(
                    //new AstronautDuty
                    //{
                    //    Id = 1,
                    //    PersonId = 1,
                    //    DutyStartDate = new DateTime(2024, 1, 1),
                    //    DutyTitle = "Commander",
                    //    Rank = "1LT",
                    //    DutyEndDate = null
                    //},
                    new AstronautDuty
                    {
                        Id = 2,
                        PersonId = 3, // Gandolf
                        DutyStartDate = new DateTime(2012, 5, 1),
                        DutyTitle = "The White",
                        Rank = "MAJ",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 3,
                        PersonId = 4, // Cooper Howard
                        DutyStartDate = new DateTime(2021, 3, 15),
                        DutyTitle = "Pilot",
                        Rank = "CPT",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 4,
                        PersonId = 5, // The Wander
                        DutyStartDate = new DateTime(2020, 7, 10),
                        DutyTitle = "Explorer",
                        Rank = "LT",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 5,
                        PersonId = 6, // Lucy Mcclain
                        DutyStartDate = new DateTime(2019, 9, 1),
                        DutyTitle = "Scientist",
                        Rank = "CIV",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 6,
                        PersonId = 7, // Barbara Howard
                        DutyStartDate = new DateTime(2018, 2, 20),
                        DutyTitle = "Engineer",
                        Rank = "CIV",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 7,
                        PersonId = 8, // Frodo Baggins (example retired duty)
                        DutyStartDate = new DateTime(2010, 1, 1),
                        DutyTitle = "Ringbearer",
                        Rank = "ENS",
                        DutyEndDate = new DateTime(2020, 12, 31)
                    },
                    new AstronautDuty
                    {
                        Id = 8,
                        PersonId = 9, // Cassian Andor
                        DutyStartDate = new DateTime(2018, 6, 1),
                        DutyTitle = "Operative",
                        Rank = "CPT",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 9,
                        PersonId = 10, // Jon Snow
                        DutyStartDate = new DateTime(2019, 8, 1),
                        DutyTitle = "Lord Commander",
                        Rank = "CPT",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 10,
                        PersonId = 11, // Alexander Hamilton
                        DutyStartDate = new DateTime(1789, 3, 4),
                        DutyTitle = "Treasurer",
                        Rank = "MAJ",
                        DutyEndDate = null
                    },
                    new AstronautDuty
                    {
                        Id = 11,
                        PersonId = 3, // Gandolf
                        DutyStartDate = new DateTime(2011, 5, 1),
                        DutyTitle = "The Grey",
                        Rank = "MAJ",
                        DutyEndDate = new DateTime(2012, 4, 30)
                    },
                    new AstronautDuty
                    {
                        Id = 12,
                        PersonId = 10, // Jon Snow
                        DutyStartDate = new DateTime(2018, 8, 1),
                        DutyTitle = "RETIRED",
                        Rank = "CPT",
                        DutyEndDate = new DateTime(2019, 7, 31)
                    }
                ); 
        }
    }
}
