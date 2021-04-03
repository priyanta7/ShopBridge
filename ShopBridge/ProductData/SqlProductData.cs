using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopBridge.ProductData
{
    public class SqlProductData : IProductData
    {
        private ProductContext _productContext;
        

        public SqlProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public async Task <Product> AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();
            
            return product;
        }

        public  async Task DeleteProduct(Product product)
        {

            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();

        }

        public Product GetSingleProduct(Guid id)
        {
            var product = _productContext.Products.Find(id);
            return product;
        }

        public async Task <List<Product>> GetProducts()
        {
            await Task.Delay(1);
            return _productContext.Products.ToList();
        }

        

        //public object GetProducts(object id)
        //{
        //    throw new NotImplementedException();
        //}

        public Product ModifyProduct(Product product)
        {
            var existingProduct = _productContext.Products.Find(product.Id);
            
                if (existingProduct != null)
                {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                    _productContext.Update(existingProduct);
                    _productContext.SaveChanges();
                }
                return product;

        }
    }
}
