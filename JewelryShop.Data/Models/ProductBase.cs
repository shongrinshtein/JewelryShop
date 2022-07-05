using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public abstract class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category[] Categories { get; set; }
        public string? Description { get; set; }
        public Size[] Sizes { get; set; }
        public PhotoURI[] PhotosURI { get; set; }

    }
}
