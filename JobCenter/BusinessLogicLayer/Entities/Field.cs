using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Field
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();

        public override string ToString()
        {
            return $"{Id,-4}|{Name,-20}";
        }
    }
}
