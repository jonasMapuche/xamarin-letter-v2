using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class AdverbViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionArticle { get; set; }

        private readonly IMongoCollection<CircunstanciaModel> _adverbsCollection;

        public AdverbViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@ac-qs3nere-shard-00-00.twimpt2.mongodb.net:27017,ac-qs3nere-shard-00-01.twimpt2.mongodb.net:27017,ac-qs3nere-shard-00-02.twimpt2.mongodb.net:27017/?ssl=true&replicaSet=atlas-a5rh82-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusteradverb";
            DatabaseName = "stomach";
            CollectionArticle = "adverb";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<CircunstanciaModel> ConfigurationValue = mongoDatabase.GetCollection<CircunstanciaModel>(CollectionArticle);

            _adverbsCollection = ConfigurationValue;
        }

        public CircunstanciaModel GetName(string name) => _adverbsCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<CircunstanciaModel> GetLanguage(string language) => _adverbsCollection.Find(index => index.linguagem == language).ToList<CircunstanciaModel>();

        public async Task<CircunstanciaModel> GetPronounAsync(string name) => await _adverbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}