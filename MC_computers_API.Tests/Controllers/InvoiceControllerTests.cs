using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using MC_computers_API.Controllers;
using MC_computers_API.Data;
using MC_computers_API.Models.Entities;

namespace MC_computers_API.Tests.Controllers
{
    public class InvoiceControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly InvoiceController _controller;

        public InvoiceControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Invoice")
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Products.AddRange(new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Laptop", Price = 1000, StockQuantity = 15 },
                new Products { ProductID = 2, ProductName = "Keyboard", Price = 50, StockQuantity = 18 }
            });
            _context.SaveChanges();

            _controller = new InvoiceController(_context);
        }

        [Fact]
        public void GenerateInvoice_CreatesInvoiceAndUpdatesStock()
        {
            var request = new InvoiceRequest
            {
                CustomerName = "Kumara",
                TotalAmount = 1050,
                Discount = 50,
                BalanceAmount = 1000,
                Products = new List<InvoiceProductRequest>
        {
            new InvoiceProductRequest { ProductID = 1, Quantity = 1, Price = 1000 },
            new InvoiceProductRequest { ProductID = 2, Quantity = 2, Price = 50 }
        }
            };

            // Act
            var result = _controller.GenerateInvoice(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);

            dynamic response = okResult.Value;
            Assert.Equal("Invoice generated successfully!", response.Message);

            var invoice = _context.CustomerInvoices.FirstOrDefault();
            Assert.NotNull(invoice);
            Assert.Equal("Kumara", invoice.CustomerName);

            var laptop = _context.Products.FirstOrDefault(p => p.ProductID == 1);
            Assert.NotNull(laptop);
            Assert.Equal(14, laptop.StockQuantity);

            var keyboard = _context.Products.FirstOrDefault(p => p.ProductID == 2);
            Assert.NotNull(keyboard);
            Assert.Equal(16, keyboard.StockQuantity);
        }
    }
}