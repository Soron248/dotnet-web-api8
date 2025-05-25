using System.ComponentModel.DataAnnotations;

namespace testapiproject.Models
{
    public class Category
    {
        [Key]
        public Guid CateId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
