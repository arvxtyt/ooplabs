using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Application
    {
        public long Id { get; set; }

        public long VacancyId { get; set; }

        public string? VacancyName { get; set; }

        public long CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public long UnemployedId { get; set; }

        public string? UnemployedName { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{Id,-4}|{VacancyName,-20}|{UnemployedName, -20}|{CategoryName, -10}";
        }
    }
}
