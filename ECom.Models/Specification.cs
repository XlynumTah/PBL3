using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Processor {get; set;}
        [MaxLength(100)]
        public string Storage {get; set;}
        [MaxLength(100)]
        public string RAM {get; set;}
        [MaxLength(100)]
        public string Screen {get; set;}
        [MaxLength(100)]
        public string Camera {get; set;}
        public int ProductId { get; set; }
        public Product? Product {get; set;}
    }
}
