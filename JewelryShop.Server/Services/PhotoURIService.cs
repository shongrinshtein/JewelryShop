using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class PhotoURIService : IPhotoURIService
    {
        private readonly IPhotoURIRepository photoURIRepository;
        public PhotoURIService(IPhotoURIRepository photoURIRepository) => 
                                this.photoURIRepository = photoURIRepository;
        public Task<bool> Delete(int? id) => photoURIRepository.Delete(id);

        public async Task<PhotoURI> Get(int? id) => await photoURIRepository.Get(id);

        public async Task<IEnumerable<PhotoURI>> GetAll() => await photoURIRepository.GetAll();

        public async Task<IEnumerable<PhotoURI>> GetByIndex(int index, int manyInPage) => 
            await photoURIRepository.GetByIndex(index, manyInPage);

        public async Task<PhotoURI> Insert(PhotoURI item) => 
            await photoURIRepository.Insert(item);

        public async Task<bool> Update(PhotoURI item) => 
            await photoURIRepository.Update(item);
    }
}
