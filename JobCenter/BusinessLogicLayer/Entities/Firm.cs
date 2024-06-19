using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Firm
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Site { get; set; } = string.Empty;
        public int Rating { get; set; }
        public ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();

        public override string ToString()
        {
            return $"{(Id.ToString()).PadRight(4)}|{Name.PadRight(30)}|{Phone.PadRight(12)}|{Email.PadRight(20)}|{Site.PadRight(30)}|{Rating.ToString().PadLeft(2)}";
        }
    }
}
