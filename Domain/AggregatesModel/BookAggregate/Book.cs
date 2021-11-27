using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.AggregatesModel.BookAggregate
{
    public class Book
    {
        [BsonId]
        public string ItemId { get; set; }

        public string Title { get; set; }
    }
}
