using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProductService.Domain;

namespace ProductService.DataAccess
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        Task Add(T obj);
        Task<T> GetById(Guid id);
        Task<T> GetByCode(string code);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(Guid id);
    }
}
