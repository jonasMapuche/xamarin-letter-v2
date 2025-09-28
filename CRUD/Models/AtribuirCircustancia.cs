using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirCircustancia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Circustancia chave {  get; set; }
        public Circustancia atualizar { get; set; }
    }
}
