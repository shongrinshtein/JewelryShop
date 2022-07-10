using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ISizeProductRepository sizeProductRepos;
        private readonly IPhotoURIRepository photoURIRepository;
        public ProductService(IProductRepository productRepository, ISizeProductRepository sizeProductRepos, IPhotoURIRepository photoURIRepository)
        {
            this.sizeProductRepos = sizeProductRepos;
            this.productRepository = productRepository;
            this.photoURIRepository = photoURIRepository;
        }
        public Task<bool> Delete(int? id)
        {
            try
            {
                var product = productRepository.Get(id).Result;
                foreach (var size in product.Sizes)
                {
                    sizeProductRepos.Delete(size.Id);
                }
                foreach (var photo in product.PhotosURI)
                {
                    photoURIRepository.Delete(photo.Id);
                }
                return productRepository.Delete(id);


            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Product> Get(int? id) => await productRepository.Get(id);

        public async Task<IEnumerable<Product>> GetAll() => await productRepository.GetAll();

        public async Task<IEnumerable<Product>> GetByIndex(int index, int manyInPage) => await productRepository.GetByIndex(index, manyInPage);

        public async Task<Product> Insert(Product item) => await productRepository.Insert(item);

        public Task<bool> Update(Product item) => productRepository.Update(item);
    }
}
