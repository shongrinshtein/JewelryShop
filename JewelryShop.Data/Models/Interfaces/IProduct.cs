namespace JewelryShop.Data.Models.Interfaces
{
    public interface IProduct : IProductBase
    {
        public bool ForSell { get; set; }
    }
}
