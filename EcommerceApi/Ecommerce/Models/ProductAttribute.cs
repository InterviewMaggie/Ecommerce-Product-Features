
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class ProductAttribute
    {
        [Key]
        public int ProductAttributeId { get; set; }
        public string AttributeName { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public Product Product { get; set; }

    }
}
