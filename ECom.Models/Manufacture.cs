using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Manufacture
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
