using System.ComponentModel.DataAnnotations;
using System;
using EComWeb.Collections;

namespace EComWeb.Models
{
    public class Order
    {
        [Key]
        public int Id {get; set;}
        public string BuyerId {get; set;}
        public Address ShipToAddress {get; set;}
        public List<OrderItem> OrderItems {get; set;}
    }
}