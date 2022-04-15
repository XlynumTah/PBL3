using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class Basket
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string BuyerId {get; set;}
        public List<BasketItem> Items {get; set;}
    }
    
}