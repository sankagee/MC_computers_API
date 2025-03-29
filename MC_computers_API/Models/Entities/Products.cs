using System.ComponentModel.DataAnnotations;

namespace MC_computers_API.Models.Entities
{
    public class Products
    {
        [Key]
        public required int ProductID { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public required int StockQuantity { get; set; }
    }
}
