using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> Insert(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int? id);
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
    }

}
