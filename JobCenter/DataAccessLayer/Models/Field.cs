using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("fields")]
    public class Field : Base
    {
        public string Name { get; set; }

        public IList<Vacancy> Vacancies { get; set; }
        public IList<Resume> Resumes { get; set; }
    }
}
