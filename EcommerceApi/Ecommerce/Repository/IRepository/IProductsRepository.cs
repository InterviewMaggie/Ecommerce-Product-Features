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
        Product GetProduct(int categoryId);
        bool ProductExists(string name);
        bool ProductExists(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool Save();
    }
}
