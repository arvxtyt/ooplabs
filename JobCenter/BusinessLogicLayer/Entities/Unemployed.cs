using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Unemployed
    {
        public DateTime DateOfBirth { get; set; }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Resume> Resumes { get; set; } = new List<Resume>();

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{Id, -4}|{Name, -15}|{Surname, -15}|{Phone, -12}|{Email, -20}|{Description, -30}|{CreatedAt, -10}|{UpdatedAt, -10}";
        }
    }
}
