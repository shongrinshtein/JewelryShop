namespace JewelryShop.Data.Models.Interfaces
{
    public interface ISizeProduct : ISize
    {
        public IProductBase[] ProductsBase { get; set; }
    }

}
