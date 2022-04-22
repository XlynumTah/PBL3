using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Order
    {
        [Key]
        public int Id {get; set;}
        public string BuyerId {get; set;}
        public ApplicationUser Buyer { get; set; }
        public Address ShipToAddress {get; set;}
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> OrderItems {get; set;}


    }
}