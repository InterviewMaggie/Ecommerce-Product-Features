using EcommerceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.DTO
{
    public class ProductAttributeDTO
    {
        public int ProductAttributeId { get; set; }
        [Required]
        public string AttributeName { get; set; }
        public int Id { get; set; }
        

    }
}
