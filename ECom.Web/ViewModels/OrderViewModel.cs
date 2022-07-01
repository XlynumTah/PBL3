using ECom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECom.Web.ViewModels;

public class OrderViewModel
{
    public OrderViewModel(Order order)
    {
        Id=order.Id;
        BuyerId = order.BuyerId;
        OrderStatuses = order.OrderStatuses;
        decimal total = 0;
        foreach(var item in order.OrderItems)
        {
            total += item.Units * item.UnitPrice;
        }
        TotalPrice = total;
        ShippingAddress = order.ShipToAddress;
        OrderItems = order.OrderItems.Select(oi => new OrderItemViewModel
        {
            Id = oi.Id,
            ProductName = oi.ProductName,
            UnitPrice = oi.UnitPrice,
            Units = oi.Units,
            ImageUrl = oi.ImageUrl
        }).ToList();
    }
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public List<OrderStatus> OrderStatuses { get; set; }

    public List<SelectListItem> OrderStatusSelectListItems
    {
        get
        {
            return new List<String> {"Shipping", "Completed", "Cancelled", "Returned"}
                .Select(s => new SelectListItem
                {
                    Value = s,
                    Text = s,
                    Selected = OrderStatuses.Last().Name.ToString() == s ? true : false
                }).ToList();
        }
        private set{}
    }
        
    public OrderStatus CurrentOrderStatus
    {
        get => OrderStatuses.Last();
        private set { }
    }
    public decimal TotalPrice { get; set; }
    public Address ShippingAddress { get; set; }
    public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
}