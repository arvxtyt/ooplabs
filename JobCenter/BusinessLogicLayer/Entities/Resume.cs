using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Resume
    {
        public long Id { get; set; }
        
        public long UnemployedId { get; set; }

        public string? UnemployedName { get; set; }

        public long FieldId { get; set; }

        public string? FieldName { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{Id, -4}|{Title, -20}|{Description, -30}|{FieldId, -8}|{FieldName, -20}|{UnemployedId, -4}|{UnemployedName, -20}|{CreatedAt, -10}|{UpdatedAt, -10}";
        }
    }
}
