using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        public float Price { get; set; }
        public string SKU { get; set; }
        public DateTime Created { get; set; }
        public string PreviewImage { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
    }
}
