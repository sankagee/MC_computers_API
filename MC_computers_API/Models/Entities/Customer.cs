using System.ComponentModel.DataAnnotations;

namespace MC_computers_API.Models.Entities
{
    public class Customer
    {
        [Key]
        public required int CustomerID { get; set; }

        [MaxLength(100)]
        public required string Cus_Name { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
