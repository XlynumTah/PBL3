using System.ComponentModel.DataAnnotations;

namespace ECom.Models;

public class OrderStatus
{
    [Key]
    public int Id { get; set; }
    public string name { get; set; }
    public List<Order> Orders { get; set; }
}