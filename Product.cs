using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FinalProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
