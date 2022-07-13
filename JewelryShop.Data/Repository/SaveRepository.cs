using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Repository
{
    public class SaveRepository
    {
        private readonly JewelryShopContextDB contextDB;
        public SaveRepository(JewelryShopContextDB contextDB) => this.contextDB = contextDB;

        public async Task SaveChanges() => await contextDB.SaveChangesAsync();



    }
}
