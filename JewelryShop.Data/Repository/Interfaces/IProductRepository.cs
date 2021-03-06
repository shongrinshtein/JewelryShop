using JewelryShop.Data.Models;

namespace JewelryShop.Data.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(Category categoryProduct);

    }

}
