using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class SizeProduct: ISizeProduct
    {
        public float? Length { get ; set ; }
        public float? Width { get ; set ; }
        public float? Caliber { get ; set ; }
        public IProductBase[] ProductsBase { get  ; set  ; }
    }
}
