using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Specification
    {
        [Key]
        public int Id { get; set; }
        public string Processor {get; set;}
        public string Storage {get; set;}
        public string RAM {get; set;}
        public string Screen {get; set;}
        public string Camera {get; set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
    }
}
