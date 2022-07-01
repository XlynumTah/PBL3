using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ECom.Web.Interfaces;


namespace ECom.Web.Services;

public class OrderService : IOrderService
{
    private readonly ILogger<OrderService> _logger;
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger<OrderService>();
    }
    public async Task CreateOrderAsync(int basketId, Address shippingAddress)
    {
        var basket = await _context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.Id == basketId);
        _logger.LogWarning($"Get basket with Id {basket.Id}");
        basket.Items.ForEach(i=>_logger.LogWarning($"BasketItem Id {i.Id} with productId {i.ProductId} from basketId {i.BasketId}"));
        var productIds = basket.Items.Select(i => i.ProductId);
        var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
        products.ForEach(p=>_logger.LogWarning($"Get product with Id {p.Id} from BasketItem"));
        var items = new List<OrderItem>();
        var basketItems = basket.Items.ToList();
        foreach (var basketItem in basketItems)
        {
            var product = products.First(p => p.Id == basketItem.ProductId);
            var orderItem = new OrderItem
            {
                ProductName = product.Name,
                ImageUrl = product.ImageUrl,
                UnitPrice = basketItem.UnitPrice, //Lấy price trong basket, vì price trong basket đã tính giảm giá
                Units = basketItem.Quantity,
                ProductId = basketItem.ProductId
            };
            items.Add(orderItem);
        }
        var currentOrderStatus = new OrderStatus
        {
            Name = OrderStatus.OrderStatusType.Shipping,
            StartDate = DateTime.Now
        };
        var order = new Order
        {
            BuyerId = basket.BuyerId,
            OrderItems = items,
            ShipToAddress = shippingAddress
        };
        order.OrderStatuses.Add(currentOrderStatus);
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateOrderStatusAsync(int orderId, string orderStatus)
    {
        if (!Enum.IsDefined(typeof(OrderStatus.OrderStatusType), orderStatus))
        {
            throw new ArgumentException(String.Format("Wrong OrderStatus: {orderStatus}"));
        }
        var order = await _context.Orders.Include(o=>o.OrderStatuses).FirstOrDefaultAsync(o=>o.Id==orderId);
        var currentDate = DateTime.Now;
        order.OrderStatuses.Last().EndDate=currentDate;
        order.OrderStatuses.Add(new ECom.Models.OrderStatus
        {
            Name = (OrderStatus.OrderStatusType)Enum.Parse<OrderStatus.OrderStatusType>(orderStatus),
            StartDate = currentDate
        });
        await _context.SaveChangesAsync();
    }
}