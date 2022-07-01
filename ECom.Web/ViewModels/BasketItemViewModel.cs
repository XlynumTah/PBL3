using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using static System.Int32;

namespace ECom.Web.ViewModels;

public class BasketItemViewModel
{
    [System.ComponentModel.DataAnnotations.Required]
    public int Id { get; set; }
    public int ProductItemId { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    [Range(0, Int32.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
    [System.ComponentModel.DataAnnotations.Required]
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
}