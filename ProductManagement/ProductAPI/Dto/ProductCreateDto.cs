
    using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProductAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace ProductAPI.Dto
    {
        public class ProductCreateDto
        {
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("productCode")]
        public string ProductCode { get; set; }

        [JsonProperty("name")]

        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("subCategoryId")]

        public int SubCategoryId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("image")]

        public IFormFile? Image { get; set; }

        [JsonProperty("imageUrl")]
        public string? ImageUrl { get; set; }
        }
    }


