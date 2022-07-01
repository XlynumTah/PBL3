using ECom.Web.ViewModels;

namespace ECom.Web.Interfaces;

public interface IOrderViewModelService
{
    /// <summary>
    ///  Get all orders of user with userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>all OrderViewModel of user with userId</returns>
    Task<List<OrderViewModel>> GetAllOrderAsync(int userId);
    
    /// <summary>
    /// Get Order with orderId as OrderViewModel
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    Task<OrderViewModel> GetOrderDetailAsync(int orderId);
}