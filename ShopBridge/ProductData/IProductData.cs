using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.ProductData
{
    public interface IProductData
    {
        Task <List<Product>> GetProducts();
        Product GetSingleProduct(Guid Id);
        Task<Product> AddProduct(Product product);
        Task DeleteProduct(Product product);
        Product ModifyProduct(Product product);

        //object GetProducts(object id);

    }
}
