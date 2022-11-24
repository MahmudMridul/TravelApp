using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace TravelAppApi.Models
{
    public class Spot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double Rating { get; set; }
        public string? ImagePath { get; set; }
        public string Category { get; set; } = null!;
        public string District { get; set; } = null!;

    }
}
