using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class SizeProductService:ISizeProductService
    {
        private readonly ISizeProductRepository sizeProductRepos;
        public SizeProductService(ISizeProductRepository sizeProductRepos) => this.sizeProductRepos = sizeProductRepos;

        public async Task<bool> Delete(int? id) => await sizeProductRepos.Delete(id);

        public async Task<SizeProduct> Get(int? id) => await sizeProductRepos.Get(id);

        public async Task<IEnumerable<SizeProduct>> GetAll() => await sizeProductRepos.GetAll();

        public async Task<IEnumerable<SizeProduct>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return await sizeProductRepos.GetByIndex(index, manyInPage);
        }

        public async Task<SizeProduct> Insert(SizeProduct sizeProduct) => await sizeProductRepos.Insert(sizeProduct);

        public async Task<bool> Update(SizeProduct sizeProduct) => await sizeProductRepos.Update(sizeProduct);

    }
}
