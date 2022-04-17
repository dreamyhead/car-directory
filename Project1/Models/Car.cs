using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Brand")]
        [StringLength(50, MinimumLength = 1)]
        public string Brand { get; set; } = "";

        [StringLength(50, MinimumLength = 1)]
        public string Color { get; set; } = "";

        public string PlateNumber { get; set; } = "";

        [Range(1, 10000)]
        public int ProductYear { get; set; }
    }
}