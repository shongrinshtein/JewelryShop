using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Models.Interfaces
{
    public interface ISize
    {
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Caliber { get; set; }

    }
}
