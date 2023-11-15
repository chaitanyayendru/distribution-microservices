using MongoDB.Driver;
using ProductService.DataAccess.MongoPersistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ProductService.Domain;

namespace ProductService.DataAccess
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<T> DbSet;

        protected GenericRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<T>(typeof(T).Name);
        }

        public virtual async Task Add(T obj)
        {
            await Context.AddCommand(async () => await DbSet.InsertOneAsync(obj));
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<T> GetByCode(string code)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("code", code));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(T obj)
        {
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.Id), obj));
        }

        public virtual void Remove(Guid id)
        {
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
