using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)] public DateTime ReleaseDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
        public int SpecificationId { get; set; } 
        public Specification Specification { get; set; }
        
        public string Description {get; set;}
        [Range(0,100000)]
        public decimal Price { get; set; }
        [Range(0,100)]
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string IMEI { get; set; }
        public bool IsDeleted { get; set; }
    }
}
