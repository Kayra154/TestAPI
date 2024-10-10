using System.ComponentModel.DataAnnotations;

namespace TestAPI.Entity.Modeller.Dto
{
    public class TestDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]

        public string Name { get; set; }
        [Required]

        public static int hourlySalary { get; set; }

        public int dailyHours { get; set; }

        public int weeklyWorkdayAmount { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
