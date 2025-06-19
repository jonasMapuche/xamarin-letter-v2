using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class VerbViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionVerb { get; set; }

        private readonly IMongoCollection<ElocucaoModel> _verbsCollection;

        public VerbViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@clusterverb-shard-00-00.yhx9b.mongodb.net:27017,clusterverb-shard-00-01.yhx9b.mongodb.net:27017,clusterverb-shard-00-02.yhx9b.mongodb.net:27017/?replicaSet=atlas-bgtfxu-shard-0&ssl=true&authSource=admin&retryWrites=true&w=majority&appName=clusterverb";
            DatabaseName = "stomach";
            CollectionVerb = "verb";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<ElocucaoModel> ConfigurationValue = mongoDatabase.GetCollection<ElocucaoModel>(CollectionVerb);

            _verbsCollection = ConfigurationValue;
        }

        public ElocucaoModel GetName(string name) => _verbsCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<ElocucaoModel> GetLanguage(string language) => _verbsCollection.Find(index => index.linguagem == language).ToList<ElocucaoModel>();

        public List<ElocucaoModel> GetModel(string language, string model) => _verbsCollection.Find(index => index.linguagem == language && index.modelo == model).ToList<ElocucaoModel>();

        public ElocucaoModel GetVerb(string language, string verb) => _verbsCollection.Find(index => index.linguagem == language && index.nome == verb).FirstOrDefault();

        public async Task<ElocucaoModel> GetVerbAsync(string name) => await _verbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}