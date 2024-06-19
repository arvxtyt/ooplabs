using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DataAccessLayer.Models
{
    [Table("resumes")]
    public class Resume : Base
    {
        [ForeignKey("Unemployed")]
        public long UnemployedId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        [ForeignKey("Field")]
        public long FieldId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Field Field { get; set; }
        public Unemployed Unemployed { get; set; }
    }
}