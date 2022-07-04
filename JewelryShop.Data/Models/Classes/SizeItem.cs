using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class SizeItem : ISizeItem
    {
        public IMaterial[] Materials { get  ; set  ; }
        public float? Length { get  ; set  ; }
        public float? Width { get  ; set  ; }
        public float? Caliber { get  ; set  ; }
    }
}
