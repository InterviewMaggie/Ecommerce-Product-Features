using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float Price { get; set; }
        public string SKU { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string PreviewImage { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
    }
}
