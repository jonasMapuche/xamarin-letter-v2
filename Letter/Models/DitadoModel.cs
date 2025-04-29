using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Letter.Models
{
    public class DitadoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string linguagem { get; set; }
        public string impulso { get; set; }
        public List<string> repouso { get; set; }
    }
}