using System.ComponentModel.DataAnnotations;


namespace EcommerceAPI.Models
{
    public class ProductCategory
    {
        [Key]
        public int  ProductCategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
