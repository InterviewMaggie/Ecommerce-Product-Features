using EcommerceAPI.Data;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateProduct(Product product)
        {
            _dbContext.Add(product);
            return Save();
        }
        /// <summary>
        /// Get the product based on the categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Product GetProduct(int categoryId)
        {
            return _dbContext.Products.FirstOrDefault(cat => cat.Id == categoryId);
        }
        /// <summary>
        /// Get a list of all products ordered by productName
        /// </summary>
        /// <returns></returns>
        public ICollection<Product> GetProducts()
        {
            return _dbContext.Products.OrderBy(name => name.ProductName).ToList();
        }

        /// <summary>
        /// Check if a product exist by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ProductExists(string name)
        {
            return _dbContext.Products.Any(prod => prod.ProductName.ToLower().Trim() == name.ToLower().Trim());
        }
        /// <summary>
        /// check if a product exists based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProductExists(int id)
        {
            return _dbContext.Products.Any(prod => prod.Id == id);
        }

        /// <summary>
        /// Save new records or updated to the database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
        /// <summary>
        /// Modify Product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProduct(Product product)
        {
            _dbContext.Update(product);
             return Save();
        }
    }
}
