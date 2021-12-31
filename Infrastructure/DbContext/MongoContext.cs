using Domain.AppSettings;
using MongoDB.Driver;

namespace Infrastructure.DbContext
{
    internal class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(AppSettings appSettings)
        {
            var client = new MongoClient(appSettings.DbSettings.ConnectionString);
            _database = client.GetDatabase(appSettings.DbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name + "s");
        }
    }
}
