using EcommerceAPI.Data;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public class ProductAttributesRepository : IProductAttributes
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductAttributesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Add product Attribute data
        /// </summary>
        /// <param name="productattribute"></param>
        /// <returns></returns>
        public bool CreateProductAttribute(ProductAttribute productattribute)
        {
            _dbContext.ProductAttributes.Add(productattribute);
            return Save();
        }
       

        /// <summary>
        /// Get a list of all productcategory ordered by productName
        /// </summary>
        /// <returns></returns>
        public ICollection<ProductAttribute> GetProductAttributes()
        {
            return _dbContext.ProductAttributes.OrderBy(name => name.AttributeName).ToList();
        }

        /// <summary>
        /// Get the product based on the categoryId
        /// </summary>
        /// <param name="attributeId"></param>
        /// <returns></returns>
        public Product GetProductByAttributeId(int attributeId)
        {
            return _dbContext.Products.FirstOrDefault(cat => cat.Id == attributeId);
        }

        /// <summary>
        /// Check if a productCategory exist by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ProductAttributeExists(string name)
        {
            return _dbContext.ProductAttributes.Any(prod => prod.AttributeName.ToLower().Trim() == name.ToLower().Trim());
        }

        /// <summary>
        /// check if a productAttribute exists based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ProductAttributeExists(int id)
        {
            return _dbContext.ProductAttributes.Any(prod => prod.ProductAttributeId == id);
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
