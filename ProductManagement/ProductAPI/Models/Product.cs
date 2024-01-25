using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
