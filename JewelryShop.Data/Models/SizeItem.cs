using JewelryShop.Data.Models;

namespace JewelryShop.Data.Models
{
    public class SizeItem:Size
    {
        public Material[] Materials { get; set; }
    }
}
