using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Table("firms")]
    public class Firm : Base
    {
        public string Name   { get; set; }
        public string Phone  { get; set; }
        public string Email  { get; set; }
        public string Site   { get; set; }
        public int    Rating { get; set; }

        public IList<Vacancy> Vacancies { get; set; }
    }
}
