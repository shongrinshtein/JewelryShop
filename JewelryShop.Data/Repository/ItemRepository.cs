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
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<Item> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var item = await contextDB.Items.FirstOrDefaultAsync(itema => itema.Id == id);
            if (item == null) throw new ArgumentNullException("photo URI is null"); ;
            return item;
        }

        public async Task<IEnumerable<Item>> GetAll() => await contextDB.Items.ToListAsync();
        public async Task<int> Insert(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item is null");
            await contextDB.Items.AddAsync(item);
            await contextDB.SaveChangesAsync();
            return item.Id;
        }

        public async Task<bool> Update(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("item is null");
            contextDB.Items.Update(item);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}