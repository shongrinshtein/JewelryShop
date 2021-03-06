using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public SupplierRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var supplier = await contextDB.Suppliers.FindAsync(id);
            if (supplier == null) return false;
            contextDB.Suppliers.Remove(supplier);
            return true;
        }

        public async Task<Supplier> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var supplier = await contextDB.Suppliers.FirstOrDefaultAsync(supplier => supplier.Id == id);
            if (supplier == null) throw new ArgumentNullException("supplier is null"); ;
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAll() => await contextDB.Suppliers.ToListAsync();

        public async Task<IEnumerable<Supplier>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.Suppliers.Take<Supplier>(range);
        }

        public async Task<Supplier> Insert(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier is null");
            await contextDB.Suppliers.AddAsync(supplier);
            return supplier;
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier is null");
            contextDB.Suppliers.Update(supplier);
            return true;
        }
    }
}
