using JewelryShop.Data.Models.Interfaces;

namespace JewelryShop.Data.Models.Classes
{
    public class Supplier : ISupplier
    {
        public int Id { get   ; set   ; }
        public string Name { get   ; set   ; }
        public string? Adress { get   ; set   ; }
        public string? Phone { get   ; set   ; }
        public string? URL { get   ; set   ; }
    }
}
