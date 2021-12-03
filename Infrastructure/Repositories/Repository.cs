using Domain;
using Infrastructure.DbContext;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private IMongoCollection<TEntity> _collection;

        public Repository(IMongoContext context)
        {
            _collection = context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity obj)
        {
            _collection.InsertOne(obj);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}