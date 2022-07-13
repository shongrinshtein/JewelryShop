using JewelryShop.Data.Models;

namespace JewelryShop.Server.IServices
{
    public interface IItemService : IService<Item>
    {
        Task ProduceWithitem(Item item);
    }
}
