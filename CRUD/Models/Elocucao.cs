using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CRUD.Models
{
    public class Elocucao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string nome { get; set; }
        public string linguagem { get; set; }
        public string modelo { get; set; }
        public List<Teor> teor {  get; set; }
    }
}
