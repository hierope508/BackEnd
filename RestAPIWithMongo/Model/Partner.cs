using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestWithMongo.Model
{
    public class Partner

    {
        [JsonPropertyName("id"), BsonId, Required]
        public string Id { get; set; }

        [JsonPropertyName("tradingName"), BsonElement("tradingName"), Required]
        public string TradingName { get; set; }

        [JsonPropertyName("ownerName"), BsonElement("ownerName"), Required]
        public string OwnerName { get; set; }

        [JsonPropertyName("document"), BsonElement("document"), Required]
        public string Document { get; set; }

        [JsonPropertyName("coverageArea"), BsonElement("coverageArea"), Required]
        public CoverageArea CoverageArea { get; set; }

        [JsonPropertyName("address"), BsonElement("address"), Required]
        public Address Address { get; set; }

    }
}
