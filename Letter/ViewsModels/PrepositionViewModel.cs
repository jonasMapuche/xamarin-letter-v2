using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class PrepositionViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionArticle { get; set; }

        private readonly IMongoCollection<JuncaoModel> _prepositionsCollection;

        public PrepositionViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@ac-qbpfxxr-shard-00-00.hjeuzew.mongodb.net:27017,ac-qbpfxxr-shard-00-01.hjeuzew.mongodb.net:27017,ac-qbpfxxr-shard-00-02.hjeuzew.mongodb.net:27017/?ssl=true&replicaSet=atlas-ket9j8-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusterpreposition";
            DatabaseName = "stomach";
            CollectionArticle = "preposition";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<JuncaoModel> ConfigurationValue = mongoDatabase.GetCollection<JuncaoModel>(CollectionArticle);

            _prepositionsCollection = ConfigurationValue;
        }

        public JuncaoModel GetName(string name) => _prepositionsCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<JuncaoModel> GetLanguage(string language) => _prepositionsCollection.Find(index => index.linguagem == language).ToList<JuncaoModel>();

        public async Task<JuncaoModel> GetPronounAsync(string name) => await _prepositionsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}