using ECom.Models;
using ECom.Web.ViewModels;

namespace ECom.Web.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetOrCreateBasketViewModelForUserAsync(int userId);
    Task<BasketViewModel> MapAsync(Basket basket);
}