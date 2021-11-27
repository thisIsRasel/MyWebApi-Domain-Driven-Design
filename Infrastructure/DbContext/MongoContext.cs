using MongoDB.Driver;

namespace Infrastructure.DbContext
{
    internal class MongoContext : IMongoContext
    {
        private string ConnectionString = "mongodb://localhost:27017";
        private string DatabaseName = "BookstoreDb";

        private readonly IMongoDatabase _database;

        public MongoContext()
        {
            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase(DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
