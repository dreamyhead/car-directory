using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project1.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Brand")]
        public string Brand { get; set; } = "";

        public string Color { get; set; } = "";

        public string PlateNumber { get; set; } = "";

        public int ProductYear { get; set; }
    }
}