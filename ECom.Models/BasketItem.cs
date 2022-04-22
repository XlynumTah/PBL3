using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public Product Product {get; set;}
        public decimal Price { get; set; }
        public int Quantity {get; set;}
        public int BasketId {get; set;}
        public Basket Basket { get; set; }
        public void UpdatePrice()
        {
            Price=Convert.ToDecimal(Product.Price*Quantity);   
        }
        public void AddUnits(int quantity)
        {
            Quantity+=quantity;
            UpdatePrice();
        }
        public void SetQuantity(int quantity)
        {
            Quantity=quantity;
            UpdatePrice();
        }

    }
}