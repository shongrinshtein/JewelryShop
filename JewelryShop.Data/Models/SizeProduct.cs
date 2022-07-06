using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public class SizeProduct :Size
    {
        public virtual ProductBase[] ProductsBase { get  ; set  ; }
    }
}
