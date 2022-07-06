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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public CategoryRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;
        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var category = await contextDB.Categories.FindAsync(id);
            if (category == null) return false;
            contextDB.Categories.Remove(category);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<Category> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var category = await contextDB.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category == null) throw new ArgumentNullException("category is null"); ;
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll() => await contextDB.Categories.ToListAsync();


        public async Task<int> Insert(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("category is null");
            await contextDB.Categories.AddAsync(category);
            await contextDB.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> Update(Category category)
        {
            if (category == null)
                throw new ArgumentNullException("Animal is null");
            contextDB.Categories.Update(category);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}
