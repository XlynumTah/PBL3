using ECom.DataAccess.Data;
using ECom.DataAccess.Migrations;
using ECom.Models;
using ECom.Web.Interfaces;
using ECom.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECom.Web.Services;

public class BasketViewModelService : IBasketViewModelService
{
    private readonly ApplicationDbContext _context;

    public BasketViewModelService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<BasketViewModel> GetOrCreateBasketViewModelForUserAsync(int userId)
    {
        var basket = await _context.Baskets.Include(b => b.Items).FirstOrDefaultAsync(b => b.BuyerId == userId);
        if (basket == null)
        {
            return await CreateBasketViewModelForUserAsync(userId);
        }

        var viewModel = await MapAsync(basket);
        return viewModel;
    }

    private async Task<BasketViewModel> CreateBasketViewModelForUserAsync(int userId)
    {
        var basket = new Basket()
        {
            BuyerId = userId
        };
        _context.Baskets.Add(basket);
        await _context.SaveChangesAsync();
        return new BasketViewModel()
        {
            BuyerId = basket.BuyerId,
            Id=basket.Id
        };
    }
    public async Task<BasketViewModel> MapAsync(Basket basket)
    {
        return new BasketViewModel
        {
            BuyerId = basket.BuyerId,
            Id = basket.Id,
            Items = await GetBasketItemViewModelAsync(basket.Items)
        };
    }
    public async Task<List<BasketItemViewModel>> GetBasketItemViewModelAsync(List<BasketItem> basketItems)
    {
        var productIds = basketItems.Select(b => b.ProductId);
        var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
        var items = basketItems.Select(basketItem =>
        {
            var product = products.First(p => p.Id == basketItem.ProductId);

            var basketItemViewModel = new BasketItemViewModel
            {
                Id = basketItem.Id,
                UnitPrice = basketItem.UnitPrice,
                Quantity = basketItem.Quantity,
                ProductItemId = product.Id,
                ProductName = product.Name,
                ImageUrl = product.ImageUrl
            };
            return basketItemViewModel;
        }).ToList();
        
        return items;
    }
}