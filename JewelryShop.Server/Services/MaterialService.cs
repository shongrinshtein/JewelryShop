using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository materialRepository;
        public MaterialService(IMaterialRepository materialRepository) => this.materialRepository = materialRepository;
        public Task<bool> Delete(int? id) => materialRepository.Delete(id);

        public async Task<Material> Get(int? id) => await materialRepository.Get(id);

        public async Task<IEnumerable<Material>> GetAll() => await materialRepository.GetAll();

        public async Task<IEnumerable<Material>> GetByIndex(int index, int manyInPage) => 
                            await materialRepository.GetByIndex(index, manyInPage);

        public async Task<Material> Insert(Material item) => await materialRepository.Insert(item);

        public async Task ProduceWithMaterial(Material material)
        {
            var materialInDB = await Get(material.Id);
            if (materialInDB == null) throw new NullReferenceException();
            if (materialInDB.Quantity<material.Quantity) throw new Exception($" {material} is trying to produce {material.Quantity} which is bigger than in the database {materialInDB.Quantity}");
            materialInDB.Quantity-=material.Quantity;
            await materialRepository.Update(materialInDB);
        }

        public async Task<bool> Update(Material item) => 
                            await materialRepository.Update(item);
    }
}
