using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Models.Interfaces
{
    public interface ISupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? URL { get; set; }

    }
}
