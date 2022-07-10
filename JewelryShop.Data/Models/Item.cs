using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public class Item : ProductBase
    {
        public virtual Supplier Supplier { get   ; set   ; }
    }
}
