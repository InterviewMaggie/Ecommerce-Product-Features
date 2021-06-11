using System.ComponentModel.DataAnnotations;


namespace EcommerceAPI.Models
{
    public class ProductCategory
    {
        [Key]
        public int  ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
