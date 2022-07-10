using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class SizeItemService : ISizeItemService
    {
        private readonly ISizeItemRepository sizeItemRepository;
        public SizeItemService(ISizeItemRepository sizeItemRepository) => 
                                    this.sizeItemRepository = sizeItemRepository;
        public Task<bool> Delete(int? id) => sizeItemRepository.Delete(id);

        public Task<SizeItem> Get(int? id) => sizeItemRepository.Get(id);

        public async Task<IEnumerable<SizeItem>> GetAll() => await sizeItemRepository.GetAll();

        public async Task<IEnumerable<SizeItem>> GetByIndex(int index, int manyInPage) => 
                                await sizeItemRepository.GetByIndex(index, manyInPage);

        public Task<SizeItem> Insert(SizeItem item) => await sizeItemRepository.Insert(item);

        public Task<bool> Update(SizeItem item)
        {
            throw new NotImplementedException();
        }
    }
}
