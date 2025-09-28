using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirDitado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Ditado chave {  get; set; }
        public Ditado atualizar { get; set; }
    }
}
