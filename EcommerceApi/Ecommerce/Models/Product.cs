using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Product
    {/*
        id int NOT NULL,
	productName nvarchar(250) NOT NULL,
    category_id int NOT NULL,
	subcategory_id int NOT NULL,
	PreviewImages nvarchar NOT NULL,*/
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Price { get; set; }
        public string SKU { get; set; }
        public DateTime Created { get; set; }
        [Required]
        public string PreviewImage { get; set; }
    }
}
