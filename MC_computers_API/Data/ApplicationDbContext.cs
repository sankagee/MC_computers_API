using MC_computers_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MC_computers_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Products>? Products { get; set; }
        public DbSet<CustomerInvoice>? CustomerInvoices { get; set; }
        public DbSet<InvoiceDetails>? InvoiceDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>()
                .HasKey(p => p.ProductID);

            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(18, 2)");

            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceID);
            });
        }
    }
}
