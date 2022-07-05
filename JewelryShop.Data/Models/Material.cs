using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public class Material
    {
        public int Id { get ; set; }
        public string Name { get ; set ; }
        public float? Weight { get ; set ; }
        public float Price { get  ; set  ; }
        public int? Quantity { get  ; set  ; }
        public string Color { get  ; set  ; }
        public string MaterialName { get  ; set  ; }
        public PhotoURI[] PhotosURI { get  ; set  ; }
        public string? OrderURL { get  ; set  ; }
    }
}
