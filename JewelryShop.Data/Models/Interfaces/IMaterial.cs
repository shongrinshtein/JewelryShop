using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Models.Interfaces
{
    public interface IMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public string Color { get; set; }
        public string MaterialName { get; set; }
        public string[] PhotosURI { get; set; }
        public string? OrderURL { get; set; } // url for the supplier of this specific material

    }
}
