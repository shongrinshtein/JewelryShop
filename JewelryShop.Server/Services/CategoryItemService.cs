using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly ICategoryItemRepository categoryItemRepos;
        private readonly IItemRepository itemRepos;
        public CategoryItemService(ICategoryItemRepository categoryItemRepos, IItemRepository itemRepos)
        {
            this.itemRepos = itemRepos;
            this.categoryItemRepos = categoryItemRepos;
        }
        public async Task<bool> Delete(int? id) => await categoryItemRepos.Delete(id);

        public Task<CategoryItem> Get(int? id)=> categoryItemRepos.Get(id);

        public Task<IEnumerable<CategoryItem>> GetAll()=> categoryItemRepos.GetAll();

        public Task<IEnumerable<CategoryItem>> GetByIndex(int index, int manyInPage)=>categoryItemRepos.GetByIndex(index, manyInPage);  

        public Task<CategoryItem> Insert(CategoryItem item)=>categoryItemRepos.Insert(item);    

        public Task<bool> Update(CategoryItem item)=>categoryItemRepos.Update(item);
    }
}
