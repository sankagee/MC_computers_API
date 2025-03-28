using System.ComponentModel.DataAnnotations;

namespace MC_computers_API.Models.Entities
{
    public class CustomerInvoice
    {
        [Key]
        public int InvoiceID { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? CustomerName { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public ICollection<InvoiceDetails>? InvoiceDetails { get; set; }
    }
}
