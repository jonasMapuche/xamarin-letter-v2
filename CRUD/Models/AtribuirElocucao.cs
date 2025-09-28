using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirElocucao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Elocucao chave {  get; set; }
        public Elocucao atualizar { get; set; }
    }
}
