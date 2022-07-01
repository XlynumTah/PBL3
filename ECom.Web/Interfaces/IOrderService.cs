using ECom.DataAccess.Data;
using ECom.Models;

namespace ECom.Web.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
    Task UpdateOrderStatusAsync(int orderId, string status);
}