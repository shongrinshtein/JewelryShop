using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class Material : IMaterial
    {
        public int Id { get ; set; }
        public string Name { get ; set ; }
        public float? Weight { get ; set ; }
        public float Price { get  ; set  ; }
        public int? Quantity { get  ; set  ; }
        public string Color { get  ; set  ; }
        public string MaterialName { get  ; set  ; }
        public string[] PhotosURI { get  ; set  ; }
        public string? OrderURL { get  ; set  ; }
    }
}
