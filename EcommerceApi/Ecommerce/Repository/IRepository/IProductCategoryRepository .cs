using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public interface IProductCategoryRepository
    {
        ICollection<ProductCategory> GetProductCategories();
        bool ProductCategoryExists(string name);
        bool ProductCategoryExists(int id);
        bool CreateProductCategory(ProductCategory product);
       
        bool Save();
    }
}
