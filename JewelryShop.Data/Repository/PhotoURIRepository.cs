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
    public class PhotoURIRepository : IPhotoURIRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public PhotoURIRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task<bool> Delete(int? id)
        {
            if (id == null) return false;
            var photoURI = await contextDB.PhotoURIs.FindAsync(id);
            if (photoURI == null) return false;
            contextDB.PhotoURIs.Remove(photoURI);
            await contextDB.SaveChangesAsync();
            return true;
        }

        public async Task<PhotoURI> Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException("id is null"); ;
            var category = await contextDB.PhotoURIs.FirstOrDefaultAsync(photo => photo.Id == id);
            if (category == null) throw new ArgumentNullException("photo URI is null"); ;
            return category;
        }

        public async Task<IEnumerable<PhotoURI>> GetAll() => await contextDB.PhotoURIs.ToListAsync();

        public async Task<PhotoURI> Insert(PhotoURI photoURI)
        {
            if (photoURI == null)
                throw new ArgumentNullException("photoURI is null");
            await contextDB.PhotoURIs.AddAsync(photoURI);
            await contextDB.SaveChangesAsync();
            return photoURI;
        }

        public async Task<bool> Update(PhotoURI photoURI)
        {
            if (photoURI == null)
                throw new ArgumentNullException("PhotoURI is null");
            contextDB.PhotoURIs.Update(photoURI);
            await contextDB.SaveChangesAsync();
            return true;
        }
    }
}
