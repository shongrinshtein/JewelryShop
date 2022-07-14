using JewelryShop.Data.Models;

namespace JewelryShop.Server.IServices
{
    public interface IItemService : IService<Item>
    {
        Task ProduceWithItems(Item item);
    }
}
