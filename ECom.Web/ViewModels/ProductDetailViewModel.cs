using ECom.Models;

namespace ECom.Web.ViewModels;

public class ProductDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Specification Specification { get; set; }
    public string ImageUrl {get; set;}
    public int Price {get; set;}
}