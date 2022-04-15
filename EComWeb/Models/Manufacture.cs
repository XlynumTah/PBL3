using System.ComponentModel.DataAnnotations;

namespace EComWeb.Models
{
    public class Manufacture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
