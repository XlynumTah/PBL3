using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Models
{
    public class Order
    {
        [Key]
        public int Id {get; set;}
        public int BuyerId {get; set;}
        public ApplicationUser? Buyer { get; set; }
        public Address? ShipToAddress {get; set;}
        [NotMapped]
        public OrderStatus?  CurrentOrderStatus
        {
            get => OrderStatuses.Last();
            private set { }
        }
        public List<OrderStatus> OrderStatuses { get; set; }=new List<OrderStatus>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}