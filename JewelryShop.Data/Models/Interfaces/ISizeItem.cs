namespace JewelryShop.Data.Models.Interfaces
{
    public interface ISizeItem:ISize
    {
        public IMaterial[] Materials { get; set; }
    }

}
