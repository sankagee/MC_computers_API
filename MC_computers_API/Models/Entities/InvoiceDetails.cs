using System.ComponentModel.DataAnnotations;

namespace MC_computers_API.Models.Entities
{
    public class InvoiceDetails
    {
        [Key]
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public required int ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }

        public CustomerInvoice Invoice { get; set; }
        public Products Product { get; set; }
    }
}
