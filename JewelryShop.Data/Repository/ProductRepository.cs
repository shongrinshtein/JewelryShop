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
    public class ProductRepository : IProductRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public ProductRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var product = await contextDB.Products.FindAsync(id);
            if (product == null) return false;
            contextDB.Products.Remove(product);
            return true;
        }        

        public async Task<Product> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var product = await contextDB.Products.FirstOrDefaultAsync(produc => produc.Id == id);
            if (product == null) throw new ArgumentNullException("product is null"); ;
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll() => await contextDB.Products.ToListAsync();

        public async Task<IEnumerable<Product>> GetByCategory(Category categoryProduct)=>
                                  await contextDB.Products.Where(product => product.Categories.Contains(categoryProduct)).ToListAsync();

        public async Task<IEnumerable<Product>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.Products.Take<Product>(range);
        }

        public async Task<Product> Insert(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product is null");
            await contextDB.Products.AddAsync(product);
            return product;
        }

        public async Task<bool> Update(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product is null");
            contextDB.Products.Update(product);
            return true;
        }
    }
}
