using JewelryShop.Data.Models;
using JewelryShop.Data.Repository;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ISizeProductRepository sizeProductRepos;
        private readonly IPhotoURIRepository photoURIRepository;
        private readonly SaveRepository saveRepository;
        private readonly IItemService itemService;

        public ProductService(IProductRepository productRepository, ISizeProductRepository sizeProductRepos, IPhotoURIRepository photoURIRepository, SaveRepository saveRepository, IItemService itemService)
        {
            this.itemService = itemService;
            this.saveRepository = saveRepository;
            this.sizeProductRepos = sizeProductRepos;
            this.productRepository = productRepository;
            this.photoURIRepository = photoURIRepository;
        }
        public Task<bool> Delete(int? id)
        {
            try
            {
                var tempProduct = productRepository.Get(id);
                if (tempProduct == null) throw new NullReferenceException();
                var product = tempProduct.Result;
                foreach (var size in product.Sizes)
                {
                    sizeProductRepos.Delete(size.Id);
                }
                foreach (var photo in product.PhotosURI)
                {
                    //left to delete photo memory
                    photoURIRepository.Delete(photo.Id);
                }
                return productRepository.Delete(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<Product> Get(int? id) => await productRepository.Get(id);

        public async Task<IEnumerable<Product>> GetAll() => await productRepository.GetAll();

        public async Task<IEnumerable<Product>> GetByIndex(int index, int manyInPage) => await productRepository.GetByIndex(index, manyInPage);

        //need to work on insert
        public async Task<Product> Insert(Product productInsert)
        {
            foreach (var size in productInsert.Sizes)
            {
                if (size is SizeItem sizeItem)
                {
                    //itemService.ProduceWithitem(size.)
                }
            }
            var product= await productRepository.Insert(productInsert);
            await saveRepository.SaveChanges();
            return product;
        }

        public Task<bool> Update(Product item) => productRepository.Update(item);
    }
}
