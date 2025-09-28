using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirAssistente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Assistant chave {  get; set; }
        public Assistant atualizar { get; set; }
    }
}
