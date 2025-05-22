using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewModel
{
    public class PronounViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionPronoun { get; set; }

        private readonly IMongoCollection<EstoutroModel> _pronounsCollection;

        public PronounViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@ac-4droh61-shard-00-00.trwpuy0.mongodb.net:27017,ac-4droh61-shard-00-01.trwpuy0.mongodb.net:27017,ac-4droh61-shard-00-02.trwpuy0.mongodb.net:27017/?ssl=true&replicaSet=atlas-xrl9qi-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusterpronoun";
            DatabaseName = "stomach";
            CollectionPronoun = "pronoun";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<EstoutroModel> ConfigurationValue = mongoDatabase.GetCollection<EstoutroModel>(CollectionPronoun);

            _pronounsCollection = ConfigurationValue;
        }

        public EstoutroModel GetName(string name) => _pronounsCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<EstoutroModel> GetLanguage(string language) => _pronounsCollection.Find(index => index.linguagem == language).ToList<EstoutroModel>();

        public List<EstoutroModel> GetLanguage(string language, string type) => _pronounsCollection.Find(index => index.linguagem == language && index.tipo.Contains(type)).ToList<EstoutroModel>();

        public async Task<EstoutroModel> GetPronounAsync(string name) => await _pronounsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}