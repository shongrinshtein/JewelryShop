using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ICategoryProductRepository categoryProductRepos;
        public CategoryProductService(ICategoryProductRepository productRepository) => this.categoryProductRepos = productRepository;
        public async Task<bool> Delete(int? id)
        {
            return await categoryProductRepos.Delete(id);
        }

        public async Task<CategoryProduct> Get(int? id)
        {
            return await categoryProductRepos.Get(id);
        }

        public async Task<IEnumerable<CategoryProduct>> GetAll()
        {
            return await categoryProductRepos.GetAll();
        }

        public async Task<IEnumerable<CategoryProduct>> GetByIndex(int index, int manyInPage)
        {
            return await categoryProductRepos.GetByIndex(index, manyInPage);    
        }

        public async Task<CategoryProduct> Insert(CategoryProduct item)
        {
            return await categoryProductRepos.Insert(item);
        }

        public async Task<bool> Update(CategoryProduct item)
        {
            return await categoryProductRepos.Update(item);
        }
    }
}
