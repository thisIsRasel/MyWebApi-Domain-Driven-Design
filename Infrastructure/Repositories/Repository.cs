using Domain;
using Infrastructure.DbContext;
using MongoDB.Bson;
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

        public void Delete(TEntity entity)
        {
            var document = entity.ToBsonDocument();
            var filter = Builders<TEntity>.Filter.Eq("_id", document.GetElement("_id").Value);
            _collection.DeleteOne(filter);
        }

        public void Insert(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            var document = entity.ToBsonDocument();
            var filter = Builders<TEntity>.Filter.Eq("_id", document.GetElement("_id").Value);
            var option = new ReplaceOptions { IsUpsert = true };
            _collection.ReplaceOne(filter, entity, option);
        }
    }
}