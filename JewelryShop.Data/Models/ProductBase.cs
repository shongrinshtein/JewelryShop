using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public abstract class ProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category[] Categories { get; set; }
        public string? Description { get; set; }
        public virtual Size[] Sizes { get; set; }
        public virtual PhotoURI[] PhotosURI { get; set; }

    }
}
