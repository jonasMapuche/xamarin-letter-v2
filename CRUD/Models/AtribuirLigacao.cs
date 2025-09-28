using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirLigacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Ligacao chave {  get; set; }
        public Ligacao atualizar { get; set; }
    }
}
