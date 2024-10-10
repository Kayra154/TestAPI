using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI.Entity.Modeller
{
    public class Tests
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int Id{ get; set; }
        public string Name { get; set; }

        public int hourlySalary { get; } = 12;

        public int dailyHours { get; set; }

        public int weeklyWorkdayAmount { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
