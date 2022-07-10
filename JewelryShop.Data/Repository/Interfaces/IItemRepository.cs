using JewelryShop.Data.Models;

namespace JewelryShop.Data.Repository.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetByCategory(Category categoryItem);

    }

}
