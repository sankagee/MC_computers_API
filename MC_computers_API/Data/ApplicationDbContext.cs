using MC_computers_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC_computers_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Customer>? Customers { get; set; }
        public virtual DbSet<Products>? Products { get; set; }
        public virtual DbSet<CustomerInvoice>? CustomerInvoices { get; set; }
        public virtual DbSet<InvoiceDetails>? InvoiceDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Data for Products and Customers Tables
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductID = 1,
                    ProductName = "Laptop",
                    Price = 1000,
                    StockQuantity = 15
                },
                new Products
                {
                    ProductID = 2,
                    ProductName = "Keyboard",
                    Price = 50,
                    StockQuantity = 18
                },
                new Products
                {
                    ProductID = 3,
                    ProductName = "Mouse",
                    Price = 20,
                    StockQuantity = 12
                },
                new Products
                {
                    ProductID = 4,
                    ProductName = "Mother Board",
                    Price = 300,
                    StockQuantity = 10
                }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    Cus_Name = "Nimal",
                    Email = "Nimal@example.com",
                    Phone = "023-456-7890",
                    Address = "123 Main St, LK",
                    CreatedAt = new DateTime()
                },
                new Customer
                {
                    CustomerID = 2,
                    Cus_Name = "Kamal",
                    Email = "Kamal@example.com",
                    Phone = "087-654-3210",
                    Address = "123 Main St, LK",
                    CreatedAt = new DateTime()
                },
                new Customer
                {
                    CustomerID = 3,
                    Cus_Name = "Amal",
                    Email = "Amal@example.com",
                    Phone = "055-123-4567",
                    Address = "123 Main St, LK",
                    CreatedAt = new DateTime()
                }
            );
            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(18, 2)");
        }
    }
}
