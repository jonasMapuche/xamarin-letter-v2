using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class DigitViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionDigit { get; set; }

        private readonly IMongoCollection<AlgarismoModel> _digitsCollection;

        public DigitViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@clusternumeral-shard-00-00.m6ca3.mongodb.net:27017,clusternumeral-shard-00-01.m6ca3.mongodb.net:27017,clusternumeral-shard-00-02.m6ca3.mongodb.net:27017/?ssl=true&replicaSet=atlas-zqs044-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusternumeral";
            DatabaseName = "stomach";
            CollectionDigit = "numeral";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<AlgarismoModel> ConfigurationValue = mongoDatabase.GetCollection<AlgarismoModel>(CollectionDigit);

            _digitsCollection = ConfigurationValue;
        }

        public AlgarismoModel GetName(string name) => _digitsCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<AlgarismoModel> GetLanguage(string language) => _digitsCollection.Find(index => index.linguagem == language).ToList<AlgarismoModel>();

        public async Task<AlgarismoModel> GetPronounAsync(string name) => await _digitsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}