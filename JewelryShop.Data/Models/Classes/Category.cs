using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
    }
}
