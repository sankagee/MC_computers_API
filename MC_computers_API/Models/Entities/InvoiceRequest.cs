namespace MC_computers_API.Models.Entities
{
    public class InvoiceRequest
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal BalanceAmount { get; set; }
        public List<InvoiceProductRequest> Products { get; set; }
    }
}
