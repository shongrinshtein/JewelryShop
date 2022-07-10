using JewelryShop.Data.Models;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class SizeProductService
    {
        private readonly ISizeProductService sizeProductService;
        public SizeProductService(ISizeProductService sizeProductService) => this.sizeProductService = sizeProductService;

        public async Task<bool> Delete(int? id) => await sizeProductService.Delete(id);

        public async Task<SizeProduct> Get(int? id) => await sizeProductService.Get(id);

        public async Task<IEnumerable<SizeProduct>> GetAll() => await sizeProductService.GetAll();

        public async Task<IEnumerable<SizeProduct>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return await sizeProductService.GetByIndex(index, manyInPage);
        }

        public async Task<SizeProduct> Insert(SizeProduct sizeProduct) => await sizeProductService.Insert(sizeProduct);

        public async Task<bool> Update(SizeProduct sizeProduct) => await sizeProductService.Update(sizeProduct);

    }
}
