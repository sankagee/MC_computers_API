using MC_computers_API.Data;
using MC_computers_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MC_computers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("generate-invoice")]
        public IActionResult GenerateInvoice([FromBody] InvoiceRequest request)
        {
            try
            {
                // Step 1: Create the CustomerInvoice record
                var customerInvoice = new CustomerInvoice
                {
                    TransactionDate = DateTime.UtcNow,
                    CustomerName = request.CustomerName,
                    TotalAmount = request.TotalAmount,
                    Discount = request.Discount,
                    BalanceAmount = request.BalanceAmount,
                    InvoiceDetails = request.Products.Select(p => new InvoiceDetails
                    {
                        ProductID = p.ProductID,
                        Quantity = p.Quantity,
                        Price = p.Price,
                        Total = p.Price * p.Quantity
                    }).ToList()
                };

                _context.CustomerInvoices.Add(customerInvoice);
                _context.SaveChanges();

                // Step 2: Update the stock quantities for each product
                foreach (var product in request.Products)
                {
                    var dbProduct = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
                    if (dbProduct != null)
                    {
                        dbProduct.StockQuantity -= product.Quantity;
                    }
                }

                _context.SaveChanges();

                var invoiceDto = new InvoiceDto
                {
                    InvoiceID = customerInvoice.InvoiceID,
                    TransactionDate = (DateTime)customerInvoice.TransactionDate,
                    CustomerName = customerInvoice.CustomerName,
                    TotalAmount = (decimal)customerInvoice.TotalAmount,
                    Discount = (decimal)customerInvoice.Discount,
                    BalanceAmount = (decimal)customerInvoice.BalanceAmount,
                    InvoiceDetails = customerInvoice.InvoiceDetails.Select(d => new InvoiceDetailDto
                    {
                        ProductID = d.ProductID,
                        ProductName = d.Product.ProductName,
                        Quantity = (int)d.Quantity,
                        Price = (decimal)d.Price,
                        Total = (decimal)d.Total
                    }).ToList()
                };

                return Ok(new { Message = "Invoice generated successfully!", Invoice = invoiceDto });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        }
}
