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
    public class ItemRepository : IItemRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public ItemRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var item = await contextDB.Items.FindAsync(id);
            if (item == null) return false;
            contextDB.Items.Remove(item);
            return true;
        }

        public async Task<Item> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var item = await contextDB.Items.FirstOrDefaultAsync(itema => itema.Id == id);
            if (item == null) throw new ArgumentNullException("item is null"); ;
            return item;
        }

        public async Task<IEnumerable<Item>> GetAll() => throw new NotImplementedException();

        public async Task<IEnumerable<Item>> GetByCategory(Category categoryItem)
        {
            return await contextDB.Items.Where(item => item.Categories.Contains(categoryItem)).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.Items.Take<Item>(range);
        }

        public async Task<Item> Insert(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item is null");
            await contextDB.Items.AddAsync(item);
            return item;
        }

        public async Task<bool> Update(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item is null");
            contextDB.Items.Update(item);
            return true;
        }
    }
}
