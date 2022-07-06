using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public class SizeItem:Size
    {
        public virtual Material[] Materials { get; set; }
    }
}
