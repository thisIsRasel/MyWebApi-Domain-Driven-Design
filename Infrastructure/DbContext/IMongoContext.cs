using MongoDB.Driver;

namespace Infrastructure.DbContext
{
    public interface IMongoContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
