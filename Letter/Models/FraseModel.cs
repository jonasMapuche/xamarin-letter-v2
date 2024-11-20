using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Letter.Models
{
    public class FraseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string nome { get; set; }
        public string linguagem { get; set; }
        public bool licao { get; set; }
        public string titulo { get; set; }
        public int ordem { get; set; }
        public ConteudoModel conteudo { get; set; }
    }
}