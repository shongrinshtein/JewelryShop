using JewelryShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<int> Insert(T item);
        Task<bool> Update(T animal);
        Task<bool> Delete(int? id);
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
    }
    public interface ISupplierRepository : IRepository<Supplier> { }
    public interface IMaterialRepository : IRepository<Material> { }
    public interface ICategoryRepository : IRepository<Category> { }
    public interface IPhotoURIRepository : IRepository<PhotoURI> { }
    public interface IProductBaseRepository : IRepository<ProductBase> { }
    public interface ISizeRepository : IRepository<Size> { }

}
