using EcommerceAPI.Models;
using System.Collections.Generic;

namespace EcommerceAPI.Repository
{
    //ProductAttributesRepository
    public interface IProductAttributes
    {
        ICollection<ProductAttribute> GetProductAttributes();
        bool ProductAttributeExists(string name);
        bool ProductAttributeExists(int id);
        bool CreateProductAttribute(ProductAttribute attribute);
        Product GetProductByAttributeId(int id);
        bool Save();
    }
}
