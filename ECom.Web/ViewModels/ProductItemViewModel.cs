using ECom.DataAccess.Data;
using ECom.Models;
using ECom.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECom.Web.ViewModels
{
    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl {get; set;}
        public int Price {get; set;}
        public int DPrice { get; set;}
        public int Discount { get; set; }
        public string Category { get; set; }
    }
}