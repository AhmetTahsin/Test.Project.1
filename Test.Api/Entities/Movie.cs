using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Test.Api.Entities
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public string ImageUrl { get; set; }

    }
}
