using EcommerceAPI.Data;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Add product category data
        /// </summary>
        /// <param name="productcategory"></param>
        /// <returns></returns>
        public bool CreateProductCategory(ProductCategory productcategory)
        {
            _dbContext.ProductCategories.Add(productcategory);
            return Save();
        }
       

        /// <summary>
        /// Get a list of all productcategory ordered by productName
        /// </summary>
        /// <returns></returns>
        public ICollection<ProductCategory> GetProductCategories()
        {
            return _dbContext.ProductCategories.OrderBy(name => name.CategoryName).ToList();
        }

        /// <summary>
        /// Check if a productCategory exist by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ProductCategoryExists(string name)
        {
            return _dbContext.ProductCategories.Any(prod => prod.CategoryName.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// check if a productCategory exists based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProductCategoryExists(int id)
        {
            return _dbContext.ProductCategories.Any(prod => prod.ProductCategoryId == id);
        }

        /// <summary>
        /// Save new records or updated to the database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return _dbContext.SaveChanges() >= 0 ? true : false;
        }
       
    }
}
