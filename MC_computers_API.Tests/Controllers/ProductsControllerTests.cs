using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MC_computers_API.Controllers;
using MC_computers_API.Data;
using MC_computers_API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MC_computers_API.Tests.Controllers
{
    public class ProductsControllerTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Products.RemoveRange(_context.Products);
            _context.SaveChanges();

            // Seed data into the in-memory database
            _context.Products.AddRange(new List<Products>
        {
            new Products { ProductID = 1, ProductName = "Laptop", Price = 1000, StockQuantity = 15 },
            new Products { ProductID = 2, ProductName = "Keyboard", Price = 50, StockQuantity = 18 }
        });
            _context.SaveChanges();

            _controller = new ProductsController(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetProducts_ReturnsListOfProducts()
        {
            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<Products>>>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<Products>>(okResult.Value);
            Assert.Equal(2, products.Count());
            Assert.Equal("Laptop", products.First().ProductName);
        }

        [Fact]
        public async Task GetProducts_ReturnsEmptyList_WhenNoProductsExist()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();

                var controller = new ProductsController(context);

                // Act
                var result = await controller.GetProducts();

                // Assert
                var okResult = Assert.IsType<ActionResult<IEnumerable<Products>>>(result);
                var products = Assert.IsAssignableFrom<IEnumerable<Products>>(okResult.Value);
                Assert.Empty(products);
            }
        }
    }
}