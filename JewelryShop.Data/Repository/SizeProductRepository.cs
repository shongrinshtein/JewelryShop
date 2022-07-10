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
    public class SizeProductRepository : ISizeProductRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public SizeProductRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var sizeProduct = await contextDB.SizeProducts.FindAsync(id);
            if (sizeProduct == null) return false;
            contextDB.SizeProducts.Remove(sizeProduct);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<SizeProduct> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var sizeProduct = await contextDB.SizeProducts.FirstOrDefaultAsync(sizeProduct => sizeProduct.Id == id);
            if (sizeProduct == null) throw new ArgumentNullException("sizeProduct is null"); ;
            return sizeProduct;
        }

        public async Task<IEnumerable<SizeProduct>> GetAll() => await contextDB.SizeProducts.ToListAsync();

        public async Task<SizeProduct> Insert(SizeProduct sizeProduct)
        {
            if (sizeProduct == null)
                throw new ArgumentNullException("sizeProduct is null");
            await contextDB.SizeProducts.AddAsync(sizeProduct);
            await contextDB.SaveChangesAsync();
            return sizeProduct;
        }

        public async Task<bool> Update(SizeProduct sizeProduct)
        {
            if (sizeProduct == null)
                throw new ArgumentNullException("sizeProduct is null");
            contextDB.SizeProducts.Update(sizeProduct);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}
