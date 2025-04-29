using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Letter.Models
{
    public class ElocucaoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string nome { get; set; }
        public string linguagem { get; set; }
        public string modelo { get; set; }
        public List<Teor> teor { get; set; }
    }
}