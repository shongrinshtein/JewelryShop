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
    public class CategoryItemRepository : ICategoryItemRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public CategoryItemRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;
        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var category = await contextDB.CategoryItems.FindAsync(id);
            if (category == null) return false;
            contextDB.CategoryItems.Remove(category);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryItem> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var category = await contextDB.CategoryItems.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category == null) throw new ArgumentNullException("category item product is null"); ;
            return category;
        }

        public async Task<IEnumerable<CategoryItem>> GetAll() => await contextDB.CategoryItems.ToListAsync();

        public async Task<IEnumerable<CategoryItem>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.CategoryItems.Take<CategoryItem>(range);
        }

        public async Task<CategoryItem> Insert(CategoryItem category)
        {
            if (category == null)
                throw new ArgumentNullException("category item product is null");
            await contextDB.CategoryItems.AddAsync(category);
            await contextDB.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Update(CategoryItem category)
        {
            if (category == null)
                throw new ArgumentNullException("category item product is null");
            contextDB.CategoryItems.Update(category);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}
