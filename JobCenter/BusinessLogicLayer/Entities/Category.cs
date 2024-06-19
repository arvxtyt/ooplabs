using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Category
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public override string ToString()
        {
            return $"{Id, -4}|{Name, -10}";
        }
    }
}
