using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.Controllers;
using ShopBridge.Models;
using ShopBridge.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopBridge.Test
{
   public class TestProductsController
    {
        [Fact]
        public async Task TestGetAllProducts()
        {
            var mock = new Mock<IProductData>();
            List<Product> mockproduct = new List<Product>()
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
            }
            };
            mock.Setup(r => r.GetProducts()).ReturnsAsync(mockproduct.ToList());
         ProductsController controller = new ProductsController(mock.Object);
            List<Product> response = await controller.GetProducts();
            Assert.Equal(2, response.Count());
        }

        [Fact]
        public async Task TestAddProduct()
        {
            var mock = new Mock<IProductData>();
            List<Product> mockproduct = new List<Product>()
            {
                new Product()
            {
                Id =Guid.NewGuid(),
                Name = "Product One",
                Description ="testdes",
                Price ="100"
            }
            };
            mock.Setup(r => r.AddProduct(It.IsAny<Product>())).Callback((Product product) => { mockproduct.Add(product); });
            ProductsController controller = new ProductsController(mock.Object);
            var newproduct = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Product three",
                Description = "testdes3",
                Price = "300"
            };
            string response = await controller.AddNewProduct(newproduct);
            Assert.Equal(newproduct.Name.ToString(), response);
        }

        [Fact]
        public async Task TestDeleteProductBadResponse()
        {
            var mock = new Mock<IProductData>();

            ProductsController controller = new ProductsController(mock.Object);
            var notExistingGuid = Guid.NewGuid();
            // Act
            var badResponse = await controller.DeleteProduct(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundObjectResult>(badResponse);
        }

        [Fact]
        public void TestSingleProductBadResponse()
        {
            var mock = new Mock<IProductData>();

            ProductsController controller = new ProductsController(mock.Object);
            var notExistingGuid = Guid.NewGuid();
            // Act
            var badResponse = controller.GetProduct(notExistingGuid);
            // Assert
            Assert.Null(badResponse);
        }

        [Fact]
        public void TestPatchResponse()
        {
            var mock = new Mock<IProductData>();
            Product mockproduct = new Product()
            {
                Id =Guid.NewGuid(),
                Name = "Product One",
                Description ="testdes",
                Price ="100"
            };

            Product updatedmockproduct = new Product()
            {
                Id = mockproduct.Id,
                Name = "Product One Updated",
                Description = "testdes updated",
                Price = "150"
            };

            mock.Setup(r => r.ModifyProduct(mockproduct)).Returns(updatedmockproduct);
            ProductsController controller = new ProductsController(mock.Object);
            Product response = controller.ModifyProduct(mockproduct.Id, mockproduct);
            Assert.Equal(mockproduct, response);
        }
    }
    
}
