using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class Product : IProduct
    {
        public bool ForSell { get   ; set   ; }
        public int Id { get   ; set   ; }
        public string Name { get   ; set   ; }
        public ICategory[] Categories { get   ; set   ; }
        public string? Description { get   ; set   ; }
        public ISize[] Sizes { get   ; set   ; }
        public string[] PhotosURI { get   ; set   ; }
    }
}
