using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public ItemOrdered ItemOrdered {get; set;}
        public int ProductId { get; set; }
        public Product Product {get; set;}

        public decimal UnitPrice { get; set; }
        public decimal Units {get; set;}
        public int OrderId {get; set;}
        public Order Order {get; set;}
    }
}
