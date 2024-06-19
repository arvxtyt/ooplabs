using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("vacancies")]
    public class Vacancy : Base
    {
        [ForeignKey("Firm")]
        public long FirmId { get; set; }
        [ForeignKey("Field")]
        public long FieldId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Firm Firm { get; set; }
        public Field Field { get; set; }
        public IList<Application> Applictions { get; set; }
    }
}
