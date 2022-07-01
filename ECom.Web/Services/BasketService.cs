using ECom.DataAccess.Data;
using ECom.Models;
using ECom.Web.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ECom.Web.Services;

public class BasketService : IBasketService
{
    private readonly ILogger<BasketService> _logger;
    private readonly ApplicationDbContext _context;

    public BasketService(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<BasketService>();
        _context = context;
    }
    public async Task<Basket> AddItemToBasketAsync(int buyerId, int productItemId, int quantity)
    {
        var basket = await  _context.Baskets.Include(b=>b.Items).FirstOrDefaultAsync(b => b.BuyerId == buyerId);
        if (basket == null)
        {
            basket = new Basket()
            {
                BuyerId = buyerId
            };
            await _context.Baskets.AddAsync(basket);
        }
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productItemId);
        var unitPrice = product.Price * (1 - product.Discount);
        basket.AddItem(productItemId, unitPrice, quantity);
        await _context.SaveChangesAsync();
        return basket;
    }

    public async Task<Basket> SetQuantitesAsync(int basketId, Dictionary<string, int> quantities)
    {
        var lines = quantities.Select(kvp => kvp.Key + " " + kvp.Value.ToString());
        _logger.LogWarning("quantities key value pair: "+String.Join('\n',lines));
        var basket = await _context.Baskets.Where(b => b.Id == basketId).Include(b => b.Items).FirstAsync();
        foreach (var item in basket.Items)
        {
            if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
            {
                _logger.LogWarning($"current BasketItem with Id {item.Id} has {item.Quantity} units");
                item.SetQuantity(quantity);
            }
            _logger.LogWarning($"After change: {item.Quantity}");
            
        }
        basket.RemoveEmptyItems();
        await _context.SaveChangesAsync();
        return basket;
    }

    public async Task DeleteBasketAsync(int basketId)
    {
        var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
        _context.Remove(basket);
        await _context.SaveChangesAsync();
    }
}