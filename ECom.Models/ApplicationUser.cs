using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECom.Models;

public class ApplicationUser : IdentityUser
{
    
    public string? Name { get; set; }
    public Address? Address { get; set; }
    public List<Basket> Baskets { get; set; }
    public List<Order> Orders { get; set; }
}