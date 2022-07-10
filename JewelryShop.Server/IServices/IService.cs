using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Server.IServices
{
    public interface IService<T> where T : class
    {
        Task<T> Insert(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int? id);
        Task<T> Get(int? id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByIndex(int index, int manyInPage);
    }
}
