using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public Product Item {get; set;}
        public decimal Price { get; set; }
        public int Quantity {get; set;}
        public void UpdatePrice()
        {
            Price=Convert.ToDecimal(Item.Price*Quantity);   
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