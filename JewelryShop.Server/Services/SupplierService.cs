using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository) => 
                            this.supplierRepository = supplierRepository;
        public async Task<bool> Delete(int? id) => await supplierRepository.Delete(id);

        public async Task<Supplier> Get(int? id) => await supplierRepository.Get(id);

        public async Task<IEnumerable<Supplier>> GetAll() => await supplierRepository.GetAll();

        public async Task<IEnumerable<Supplier>> GetByIndex(int index, int manyInPage) => 
                    await supplierRepository.GetByIndex(index, manyInPage);

        public async Task<Supplier> Insert(Supplier item) => 
                    await supplierRepository.Insert(item);

        public async Task<bool> Update(Supplier item) => 
                    await supplierRepository.Update(item);
    }
}
