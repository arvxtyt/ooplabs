using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("applications")]
    public class Application : Base
    {
        [ForeignKey("Vacancy")]
        public long VacancyId { get; set; }

        [ForeignKey("Unemployed")]
        public long UnemployedId { get; set; }
        [ForeignKey("Category")]
        public long CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Category Category { get; set; }
        public Vacancy Vacancy { get; set; }
        public Unemployed Unemployed { get; set; }
    }
}