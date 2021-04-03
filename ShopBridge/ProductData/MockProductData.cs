using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.ProductData
{
    public class MockProductData : IProductData
    {
        public List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id =Guid.NewGuid(),
                Name = "Product One",
                Description ="testdes",
                Price ="100"
            },
            new Product()
            {
                Id =Guid.NewGuid(),
                Name = "Product Two",
                Description ="testdes1",
                Price ="200"
            },

        };
        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            products.Add(product);
            return product;

        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product GetSingleProduct(Guid id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        //public object GetProducts(object id)
        //{
        //    throw new NotImplementedException();
        //}

        public Product ModifyProduct(Product product)
        {
            var existingProduct = GetSingleProduct(product.Id);
            existingProduct.Name = product.Name;
            return existingProduct;
        }

        Task<Product> IProductData.AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Task IProductData.DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductData.GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
