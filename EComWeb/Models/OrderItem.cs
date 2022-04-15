using System.ComponentModel.DataAnnotations;
using EComWeb.Collections;

namespace EComWeb.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public ItemOrdered ItemOrdered {get; set;}

        public decimal UnitPrice { get; set; }
        public decimal Units {get; set;}

    }
}
