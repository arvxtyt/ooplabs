using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Vacancy
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public string? FirmName { get; set; }

        public long FieldId { get; set; }

        public string? FieldName { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Application> Applications { get; set; } = new List<Application>();

        public override string ToString()
        {
            return $"{Id.ToString().PadRight(4)}|{FirmId.ToString().PadRight(6)}|{FirmName.ToString().PadRight(30)}|{FieldId.ToString().PadRight(8)}|{FieldName.ToString().PadRight(15)}|{Title.PadRight(30)}|{Description.PadRight(50)}|{CreatedAt.ToString().PadRight(10)}|{UpdatedAt.ToString().PadRight(10)}";
        }
    }
}
