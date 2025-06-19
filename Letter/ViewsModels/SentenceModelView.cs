using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class SentenceViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionSentence { get; set; }

        private readonly IMongoCollection<DitadoModel> _sentencesCollection;

        public SentenceViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@ac-3y1axe2-shard-00-00.n5y9bze.mongodb.net:27017,ac-3y1axe2-shard-00-01.n5y9bze.mongodb.net:27017,ac-3y1axe2-shard-00-02.n5y9bze.mongodb.net:27017/?replicaSet=atlas-ifgens-shard-0&ssl=true&authSource=admin&retryWrites=true&w=majority&appName=clustersentence";
            DatabaseName = "stomach";
            CollectionSentence = "sentence";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<DitadoModel> ConfigurationValue = mongoDatabase.GetCollection<DitadoModel>(CollectionSentence);

            _sentencesCollection = ConfigurationValue;
        }

        public DitadoModel GetName(string name) => _sentencesCollection.Find(index => index.impulso == name).FirstOrDefault();

        public List<DitadoModel> GetLanguage(string language) => _sentencesCollection.Find(index => index.linguagem == language).ToList<DitadoModel>();

        public async Task<DitadoModel> GetPronounAsync(string name) => await _sentencesCollection.Find(index => index.impulso == name).FirstOrDefaultAsync();
    }
}