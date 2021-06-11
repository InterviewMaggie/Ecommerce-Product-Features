using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTO
{
    public class ProductCategoryDTO
    {
            
            public int ProductCategoryId { get; set; }
            [Required]
            public string CategoryName { get; set; }
        
    }
}
