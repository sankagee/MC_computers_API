using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MC_computers_API.Controllers;
using MC_computers_API.Data; 
using MC_computers_API.Models.Entities;
using Xunit;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MC_computers_API.Tests.Controllers
{
    public class CustomerControllerTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomerController _controller;

        public CustomerControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Customers!.RemoveRange(_context.Customers);
            _context.SaveChanges();

            _context.Customers!.AddRange(new List<Customer>
        {
            new Customer
            {
                CustomerID = 1,
                Cus_Name = "Kumara",
                Email = "Kumara@example.com",
                Phone = "1234567890",
                Address = "123 Main St lk",
                CreatedAt = DateTime.UtcNow
            },
            new Customer
            {
                CustomerID = 2,
                Cus_Name = "Sanath",
                Email = "Sanath@example.com",
                Phone = "9876543210",
                Address = "456 Main St lk",
                CreatedAt = DateTime.UtcNow
            }
        });
            _context.SaveChanges(); // Save the seeded data to the in-memory database

            _controller = new CustomerController(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetCustomers_ReturnsListOfCustomers()
        {
            // Act
            var result = await _controller.GetCustomers();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Customer>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var customers = Assert.IsAssignableFrom<IEnumerable<Customer>>(okResult.Value);
            Assert.Equal(2, customers.Count());
        }

        [Fact]
        public async Task GetCustomers_ReturnsEmptyList_WhenNoCustomersExist()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Customers!.RemoveRange(context.Customers);
                context.SaveChanges();

                var controller = new CustomerController(context);

                // Act
                var result = await controller.GetCustomers();

                // Assert
                var actionResult = Assert.IsType<ActionResult<IEnumerable<Customer>>>(result);
                var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
                var customers = Assert.IsAssignableFrom<IEnumerable<Customer>>(okResult.Value);
                Assert.Empty(customers);
            }
        }
    }
}