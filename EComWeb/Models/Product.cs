using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public Manufacture Manufacture { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string IMEI { get; set; }
    }
}
