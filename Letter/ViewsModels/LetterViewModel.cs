using Letter.Models;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewModel
{
    public class LetterViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionLetter { get; set; }

        private readonly IMongoCollection<FraseModel> _lettersCollection;

        public LetterViewModel()
        {
            ConnectionName = "mongodb://jonas:freedown@cluster0-shard-00-00.28oko.azure.mongodb.net:27017,cluster0-shard-00-01.28oko.azure.mongodb.net:27017,cluster0-shard-00-02.28oko.azure.mongodb.net:27017/?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
            DatabaseName = "letterDB";
            CollectionLetter = "letter";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<FraseModel> ConfigurationValue = mongoDatabase.GetCollection<FraseModel>(CollectionLetter);

            _lettersCollection = ConfigurationValue;
        }

        public FraseModel GetSentenceSimple(string lesson) => _lettersCollection.Find(index => index.nome == lesson).FirstOrDefault();

        public async Task<FraseModel> GetSentenceSimpleAsync(string lesson) => await _lettersCollection.Find(index => index.nome == lesson).FirstOrDefaultAsync();
    }
}