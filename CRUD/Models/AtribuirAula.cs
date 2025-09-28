using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirAula
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Aula chave {  get; set; }
        public Aula atualizar { get; set; }
    }
}
