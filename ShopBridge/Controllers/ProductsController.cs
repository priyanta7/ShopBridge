using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Models;
using ShopBridge.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    

    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductData _productData;

        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<List<Product>> GetProducts()
        {

            return await _productData.GetProducts();
        }

        [HttpGet]
        [Route("api/[controller]/(id)")]
        public Product GetProduct(Guid id)
        {
            var product = _productData.GetSingleProduct(id);

            return product;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<string> AddNewProduct(Product product)
        {
            await _productData.AddProduct(product);
            return product.Name;
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = _productData.GetSingleProduct(id);
            if (product != null)
            {
                await _productData.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {id} was not found");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult ModifyProduct(Guid id, Product product)
        {
            var existingProduct = _productData.GetSingleProduct(id);
                if(existingProduct != null)
                {
                product.Id = existingProduct.Id;
                _productData.ModifyProduct(product);
                }
            return Ok(product);
        
        }
    }
}
