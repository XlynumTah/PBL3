using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ECom.Models
{
    public class Basket
    {
        [Key]
        public int Id {get; set;}
        public int BuyerId {get; set;}
        public ApplicationUser Buyer { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public void AddItem(int productItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productItemId))
            {
                Items.Add(new BasketItem()
                {
                    ProductId=productItemId,
                    UnitPrice= unitPrice,
                    Quantity = quantity
                });
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productItemId);
            existingItem.Quantity = existingItem.Quantity + quantity;
        }

        public void RemoveEmptyItems()
        {
            Items.RemoveAll(i => i.Quantity <= 0);
        }
    }
    
}