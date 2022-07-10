using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        public ItemService(IItemRepository itemRepository) =>
                            this.itemRepository = itemRepository;
        public async Task<bool> Delete(int? id)
        {
            return await itemRepository.Delete(id);
        }

        public async Task<Item> Get(int? id)
        {
            return await this.itemRepository.Get(id);
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await itemRepository.GetAll();
        }

        public async Task<IEnumerable<Item>> GetByIndex(int index, int manyInPage)
        {
            return await itemRepository.GetByIndex(index, manyInPage);
        }

        public async Task<Item> Insert(Item item)
        {

            return await itemRepository.Insert(item);
        }

        public async Task<bool> Update(Item item)
        {
            return await itemRepository.Update(item);
        }
    }
}
