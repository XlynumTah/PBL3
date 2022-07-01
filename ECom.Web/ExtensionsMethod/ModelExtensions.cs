using ECom.Models;

namespace ECom.Web.ExtensionsMethod;

public static class ModelExtensions
{
    public static async Task SaveImageAsync(this Product product, string webRootPath)
    {
        string fileName = System.Guid.NewGuid().ToString();
        string fileExtension = Path.GetExtension(product.Image.FileName);
        string imageFileName = fileName + fileExtension;
        string imageUrl = Path.Combine("img/featured", imageFileName);
        using (var fileStream = new FileStream(Path.Combine(webRootPath,imageUrl), FileMode.Create))
        {
            await product.Image.CopyToAsync(fileStream);
        }
        product.ImageUrl = "/"+imageUrl;
    }

    public static async Task SaveImageAsync(this Product product, string webRootPath, IFormFile file)
    {
        string fileName = System.Guid.NewGuid().ToString();
        string fileExtension = Path.GetExtension(file.FileName);
        string imageFileName = fileName + fileExtension;
        string imageUrl = Path.Combine("img/featured", imageFileName);
        using (var fileStream = new FileStream(Path.Combine(webRootPath,imageUrl), FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }
        product.ImageUrl = "/"+imageUrl;
    }

    public static void LoadImage(this Product product, string webRootPath)
    {
        if (String.IsNullOrEmpty(product.ImageUrl)) throw new Exception("ImageUrl has not been initialized ");
        string path = Path.Combine(webRootPath, product.ImageUrl.Remove(0, 1));
        if (!System.IO.File.Exists(path))
        {
            product.ImageUrl = "";
        }
        using(var stream=new FileStream(path,FileMode.Open))
        {
            product.Image = new FormFile(stream, 0, stream.Length,
                "attachment", Path.GetFileName(stream.Name));
        }
    }

    public static void RemoveImage(this Product product, string webRootPath)
    {
        if(System.IO.File.Exists(Path.Combine(webRootPath,product.ImageUrl.Remove(0,1))))
        {
            System.IO.File.Delete(Path.Combine(webRootPath,product.ImageUrl.Remove(0,1)));
        }
    }

    public static async Task EditImageAsync(this Product product, string webRootPath)
    {
        RemoveImage(product, webRootPath);
        await SaveImageAsync(product, webRootPath);
    }

    public static async Task EditImageAsync(this Product product, string webRootPath, IFormFile file)
    {
        RemoveImage(product, webRootPath);
        await SaveImageAsync(product, webRootPath, file);
    }
}