using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TestAPI.Entity.Modeller;

namespace TestAPIProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Tests> MyTest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tests>().HasData(
                new Tests()
                {
                    Id = 1,
                    Name = "Test 1",
                    dailyHours = 1,
                    weeklyWorkdayAmount = 1,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 2,
                    Name = "Test 2",
                    dailyHours = 2,
                    weeklyWorkdayAmount = 2,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 3,
                    Name = "Test 3",
                    dailyHours = 3,
                    weeklyWorkdayAmount = 3,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 4,
                    Name = "Test 4",
                    dailyHours = 4,
                    weeklyWorkdayAmount = 4,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 5,
                    Name = "Test 5",
                    dailyHours = 5,
                    weeklyWorkdayAmount = 5,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 6,
                    Name = "Test 6",
                    dailyHours = 6,
                    weeklyWorkdayAmount = 6,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 7,
                    Name = "Test 7",
                    dailyHours = 7,
                    weeklyWorkdayAmount = 7,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                },
                new Tests()
                {
                    Id = 8,
                    Name = "Test 8",
                    dailyHours = 8,
                    weeklyWorkdayAmount = 8,
                    ImageUrl = "null",
                    CreateDate = DateTime.Now,
                }

                );
            
        } 
    }

    
}
