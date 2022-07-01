using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ECom.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [DisplayName("Manufacture")]
        public int? ManufactureId { get; set; }
        public Manufacture? Manufacture { get; set; }
        public Specification? Specification { get; set; }
        [MaxLength(2560)]
        public string Description {get; set;}
        [Range(0,100000)]
        public decimal Price { get; set; }
        [Range(0,100)]
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
        [MaxLength(256)]
        public string? ImageUrl{ get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public bool IsDeleted { get; set; }

        // public async Task SaveImageAsync(string WebRootPath)
        // {
        //     string fileName = System.Guid.NewGuid().ToString();
        //     string fileExtension = Path.GetExtension(Image.FileName);
        //     string imageFileName = fileName + fileExtension;
        //     string imageUrl = Path.Combine("img/featured", imageFileName);
        //     using (var fileStream = new FileStream(Path.Combine(WebRootPath,imageUrl), FileMode.Create))
        //     {
        //         await Image.CopyToAsync(fileStream);
        //     }
        //     ImageUrl = "/"+imageUrl;
        // }
        // public async Task SaveImageAsync(string WebRootPath, IFormFile file)
        // {
        //     string fileName = System.Guid.NewGuid().ToString();
        //     string fileExtension = Path.GetExtension(file.FileName);
        //     string imageFileName = fileName + fileExtension;
        //     string imageUrl = Path.Combine("img/featured", imageFileName);
        //     using (var fileStream = new FileStream(Path.Combine(WebRootPath,imageUrl), FileMode.Create))
        //     {
        //         await file.CopyToAsync(fileStream);
        //     }
        //     ImageUrl = "/"+imageUrl;
        // }
        // public void LoadImage(string WebRootPath)
        // {
        //     if (String.IsNullOrEmpty(ImageUrl)) throw new Exception("ImageUrl has not been initialized ");
        //     string path = Path.Combine(WebRootPath, ImageUrl.Remove(0, 1));
        //     if (!System.IO.File.Exists(path))
        //     {
        //         ImageUrl = "";
        //     }
        //     using(var stream=new FileStream(path,FileMode.Open))
        //     {
        //         Image = new FormFile(stream, 0, stream.Length,
        //             "attachment", Path.GetFileName(stream.Name));
        //     }
        // }
        //
        // public void RemoveImage(string WebRootPath)
        // {
        //     if(System.IO.File.Exists(Path.Combine(WebRootPath,ImageUrl.Remove(0,1))))
        //     {
        //         System.IO.File.Delete(Path.Combine(WebRootPath,ImageUrl.Remove(0,1)));
        //     }
        // }
        //
        // public async Task EditImageAsync(string WebRootPath)
        // {
        //     RemoveImage(WebRootPath);
        //     await SaveImageAsync(WebRootPath);
        // }
        //
        // public async Task EditImageAsync(string WebRootPath, IFormFile file)
        // {
        //     RemoveImage(WebRootPath);
        //     await SaveImageAsync(WebRootPath, file);
        // }
    }
}
