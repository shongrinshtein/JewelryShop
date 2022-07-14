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
    public class MaterialRepository:IMaterialRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public MaterialRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var material = await contextDB.Materials.FindAsync(id);
            if (material == null) return false;
            contextDB.Materials.Remove(material);
            return true;
        }

        public async Task<Material> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var material = await contextDB.Materials.FirstOrDefaultAsync(cat => cat.Id == id);
            if (material == null) throw new ArgumentNullException("material is null"); ;
            return material;
        }

        public async Task<IEnumerable<Material>> GetAll() => await contextDB.Materials.ToListAsync();

        public async Task<IEnumerable<Material>> GetByIndex(int index, int manyInPage)
        {
            Range range = new Range((index - 1) * manyInPage, index * (manyInPage));
            return contextDB.Materials.Take<Material>(range);
        }

        public async Task<Material> Insert(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("Material is null");
            await contextDB.Materials.AddAsync(material);
            return material;
        }

        public async Task<bool> Update(Material material)
        {
            if (material == null)
                throw new ArgumentNullException("Material is null");
            contextDB.Materials.Update(material);
            return true;
        }
    }
}
