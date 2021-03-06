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
    public class SizeItemRepository : ISizeItemRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public SizeItemRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var sizeItem = await contextDB.SizeItems.FindAsync(id);
            if (sizeItem == null) return false;
            contextDB.SizeItems.Remove(sizeItem);
            return true;
        }

        public async Task<SizeItem> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var sizeItem = await contextDB.SizeItems.FirstOrDefaultAsync(photo => photo.Id == id);
            if (sizeItem == null) throw new ArgumentNullException("SizeItems is null"); ;
            return sizeItem;
        }

        public async Task<IEnumerable<SizeItem>> GetAll() => await contextDB.SizeItems.ToListAsync();

        public async Task<IEnumerable<SizeItem>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.SizeItems.Take<SizeItem>(range);
        }

        public async Task<SizeItem> Insert(SizeItem sizeItem)
        {
            if (sizeItem == null)
                throw new ArgumentNullException("SizeItems is null");
            await contextDB.SizeItems.AddAsync(sizeItem);
            return sizeItem;
        }

        public async Task<bool> Update(SizeItem sizeItem)
        {
            if (sizeItem == null)
                throw new ArgumentNullException("SizeItems is null");
            contextDB.SizeItems.Update(sizeItem);
            return true;
        }
    }
}
