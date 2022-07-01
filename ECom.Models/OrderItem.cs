using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(100)]
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product? Product {get; set;}
        [Range(0,100000)]
        public decimal UnitPrice { get; set; }
        public int Units {get; set;}
        public int OrderId {get; set;}
        public Order? Order {get; set;}
    }
}
