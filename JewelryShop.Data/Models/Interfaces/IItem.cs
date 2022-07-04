using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Models.Interfaces
{
    public interface IItem : IProductBase
    {
        public int? SupplierId { get; set; }

    }
}
