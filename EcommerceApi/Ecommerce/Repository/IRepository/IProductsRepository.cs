using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public interface IProductsRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductByCategoryId(int categoryId);
        Product GetProductByProductId(int id);
        bool ProductExists(string name);
        bool ProductExists(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool Save();
    }
}
