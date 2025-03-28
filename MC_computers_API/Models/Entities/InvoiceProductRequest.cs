namespace MC_computers_API.Models.Entities
{
    public class InvoiceProductRequest
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
