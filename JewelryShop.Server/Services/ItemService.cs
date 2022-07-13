using JewelryShop.Data.Models;
using JewelryShop.Data.Repository;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly ISizeItemRepository sizeItemRepository;
        private readonly IPhotoURIRepository photoURIRepository;
        private readonly ICategoryItemRepository categoryItem;
        private readonly IMaterialService materialService;
        public ItemService(ISizeItemRepository sizeItemRepository, IItemRepository itemRepository, IPhotoURIRepository photoURIRepository, ICategoryItemRepository categoryItem, IMaterialService materialService)
        {
            this.materialService = materialService;
            this.categoryItem = categoryItem;
            this.photoURIRepository = photoURIRepository;
            this.sizeItemRepository = sizeItemRepository;
            this.itemRepository = itemRepository;
        }
        public async Task<bool> Delete(int? id)
        {
            try
            {
                var tempItem = itemRepository.Get(id);
                if (tempItem == null) throw new NullReferenceException();
                var item = tempItem.Result;
                foreach (var size in item.Sizes)
                {
                    sizeItemRepository.Delete(size.Id);
                }
                foreach (var photo in item.PhotosURI)
                {
                    //left to delete photo memory
                    photoURIRepository.Delete(photo.Id);
                }
                foreach (var category in item.Categories)
                {
                    if (itemRepository.GetByCategory(category) == null)
                        categoryItem.Delete(category.Id);

                }
                return await itemRepository.Delete(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }

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

        public async Task ProduceWithItems(Item item)
        {
            var itemInDB = await Get(item.Id);
            if (itemInDB == null) throw new NullReferenceException();
            foreach (var sizeItem  in item.Sizes)
            {
                var size = (SizeItem)sizeItem;
                foreach (var material in size.Materials)
                {
                    await materialService.ProduceWithMaterial(material);
                }
            }
        }
        public async Task<bool> Update(Item item) => await itemRepository.Update(item);

    }
}
