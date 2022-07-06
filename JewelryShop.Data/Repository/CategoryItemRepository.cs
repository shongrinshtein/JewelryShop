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
    public class CategoryItemRepository : ICategoryProductRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public CategoryItemRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;
        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var category = await contextDB.CategoryProducts.FindAsync(id);
            if (category == null) return false;
            contextDB.CategoryProducts.Remove(category);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryProduct> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var category = await contextDB.CategoryProducts.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category == null) throw new ArgumentNullException("category product is null"); ;
            return category;
        }

        public async Task<IEnumerable<CategoryProduct>> GetAll() => await contextDB.CategoryProducts.ToListAsync();


        public async Task<int> Insert(CategoryProduct category)
        {
            if (category == null)
                throw new ArgumentNullException("category product is null");
            await contextDB.CategoryProducts.AddAsync(category);
            await contextDB.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> Update(CategoryProduct category)
        {
            if (category == null)
                throw new ArgumentNullException("category product is null");
            contextDB.CategoryProducts.Update(category);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}
