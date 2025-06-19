using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Letter.Models
{
    public class CircunstanciaModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string nome { get; set; }
        public string linguagem { get; set; }
        public List<string> tipo { get; set; }
    }
}
