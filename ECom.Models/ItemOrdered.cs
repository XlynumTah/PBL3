using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
    [Owned]
    public class ItemOrdered
    {
        public ItemOrdered(int ItemId, string ProductName, string PictureUri)
        {
            this.ItemId = ItemId;
            this.ProductName = ProductName;
            this.PictureUri = PictureUri;
        }
        public int ItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUri { get; set; }
    }
}