using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository) => 
                        this.productRepository = productRepository;
        public Task<bool> Delete(int? id) => productRepository.Delete(id);

        public async Task<Product> Get(int? id) => await productRepository.Get(id);

        public async Task<IEnumerable<Product>> GetAll() => await productRepository.GetAll();

        public async Task<IEnumerable<Product>> GetByIndex(int index, int manyInPage) => await productRepository.GetByIndex(index, manyInPage);

        public async Task<Product> Insert(Product item) => await productRepository.Insert(item);

        public Task<bool> Update(Product item) => productRepository.Update(item);
    }
}
