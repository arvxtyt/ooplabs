using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    [Table("categories")]
    public class Category : Base
    {
        public string Name { get; set; }
        public IList<Application> Applications { get; set; }
    }
}