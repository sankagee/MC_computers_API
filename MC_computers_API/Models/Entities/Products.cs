namespace MC_computers_API.Models.Entities
{
    public class Products
    {
        public required int ProductID { get; set; } // This is the primary key
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required int StockQuantity { get; set; }
    }
}
