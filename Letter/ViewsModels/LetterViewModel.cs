using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
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
            ConnectionName = "mongodb://labrouste:freedown@ac-jiagffd-shard-00-00.hh85dxs.mongodb.net:27017,ac-jiagffd-shard-00-01.hh85dxs.mongodb.net:27017,ac-jiagffd-shard-00-02.hh85dxs.mongodb.net:27017/?ssl=true&replicaSet=atlas-ryd5gy-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusterletter";
            DatabaseName = "stomach";
            CollectionLetter = "letter";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<FraseModel> ConfigurationValue = mongoDatabase.GetCollection<FraseModel>(CollectionLetter);

            _lettersCollection = ConfigurationValue;
        }

        public FraseModel GetSentenceSimple(string lesson) => _lettersCollection.Find(index => index.nome == lesson).FirstOrDefault();

        public List<FraseModel> GetLessonSimple(bool lesson, string language) => _lettersCollection.Find(index => index.licao == lesson && index.linguagem == language).ToList<FraseModel>();

        public async Task<FraseModel> GetSentenceSimpleAsync(string lesson) => await _lettersCollection.Find(index => index.nome == lesson).FirstOrDefaultAsync();
    }
}