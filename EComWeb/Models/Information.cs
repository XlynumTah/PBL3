using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }
        public string Processor {get; set;}
        public string Storage {get; set;}
        public string RAM {get; set;}
        public string Screen {get; set;}
        public string Camera {get; set;}
        public string Description {get; set;}
    }
}
