using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
        public Category ProductCategory { get; set; }
        public string Ram {get; set;}
        public Manufacture ProductManufacture { get; set; }
        public Information ProductInformation { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string PictureUri { get; set; }
        public string IMEI { get; set; }
    }
}
