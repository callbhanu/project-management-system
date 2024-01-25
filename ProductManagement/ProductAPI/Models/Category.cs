using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}
