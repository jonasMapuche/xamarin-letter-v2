using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD.Models
{
    public class AtribuirEstoutro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Preceito chave {  get; set; }
        public Preceito atualizar { get; set; }
    }
}
