using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECom.Models;
/// <summary>
/// Khóa chính là Int, thừa kế từ IdentityUser
/// </summary>
public class ApplicationUser : IdentityUser<Int32>
{
    /// <summary>
    /// Tên của User
    /// </summary>
    [PersonalData]
    [MaxLength(100)]
    public string? Name { get; set; }
    /// <summary>
    /// Địa chỉ User
    /// </summary>
    [PersonalData]
    public Address? Address { get; set; }
    public List<Basket> Baskets { get; set; }=new List<Basket>();
    public List<Order> Orders { get; set; }=new List<Order>();
}