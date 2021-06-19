using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestWithMongo.Model
{
    public class CoverageArea
    {
        [BsonElement("type")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [BsonElement("coordinates")]
        [JsonPropertyName("coordinates")]
        public List<List<List<double[]>>> Coordinates { get; set; }

    }
}
