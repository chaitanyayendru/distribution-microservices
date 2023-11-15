using MongoDB.Driver;
using System.Threading.Tasks;
using System;

namespace ProductService.DataAccess.MongoPersistence
{
    public interface IMongoContext : IDisposable
    {
        Task AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
