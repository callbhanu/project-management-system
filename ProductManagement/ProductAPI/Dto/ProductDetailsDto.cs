using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Dto
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        //public string CategoryName { get; set; }
        //public string SubcategoryName { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
