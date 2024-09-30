using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Category
    {
        [Required]
        public int CategoryId { get; internal set; }
        public string Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
