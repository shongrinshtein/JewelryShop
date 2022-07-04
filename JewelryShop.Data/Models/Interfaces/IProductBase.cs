namespace JewelryShop.Data.Models.Interfaces
{
    public interface IProductBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICategory[] Categories { get; set; }
        public string? Description { get; set; }
        public ISize[] Sizes { get; set; }
        public string[] PhotosURI { get; set; }

    }
}
