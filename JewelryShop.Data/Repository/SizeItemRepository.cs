﻿using JewelryShop.Data.Models;
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
            var photoURI = await contextDB.PhotoURIs.FindAsync(id);
            if (photoURI == null) return false;
            contextDB.PhotoURIs.Remove(photoURI);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<SizeItem> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var category = await contextDB.SizeItems.FirstOrDefaultAsync(photo => photo.Id == id);
            if (category == null) throw new ArgumentNullException("SizeItems is null"); ;
            return category;
        }

        public async Task<IEnumerable<SizeItem>> GetAll() => await contextDB.SizeItems.ToListAsync();
        public async Task<int> Insert(SizeItem sizeItem)
        {
            if (sizeItem == null)
                throw new ArgumentNullException("SizeItems is null");
            await contextDB.SizeItems.AddAsync(sizeItem);
            await contextDB.SaveChangesAsync();
            return sizeItem.Id;
        }

        public async Task<bool> Update(SizeItem sizeItem)
        {
            if (sizeItem == null)
                throw new ArgumentNullException("SizeItems is null");
            contextDB.SizeItems.Update(sizeItem);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}