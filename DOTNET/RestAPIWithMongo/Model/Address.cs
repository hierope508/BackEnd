using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestWithMongo.Model
{
    public class Address
    {
        [JsonPropertyName("type"), BsonElement("type"), Required]
        public string Type { get; set; }

        [JsonPropertyName("coordinates"), BsonElement("coordinates"), Required]
        public double[] Coordinates { get; set; }

    }
}
