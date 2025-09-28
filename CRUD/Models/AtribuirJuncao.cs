using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirJuncao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Juncao chave {  get; set; }
        public Juncao atualizar { get; set; }
    }
}
