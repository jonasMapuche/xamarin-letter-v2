using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class AdverbService
    {
        public static string ConnectionAdverb { get; set; }
        public static string ConnectionPeriodic { get; set; }
        public static string ConnectionActivity { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionAdverb { get; set; }

        private readonly IMongoCollection<Modificador> _adverbsCollection;

        public AdverbService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "activity":
                    mongoClient = new MongoClient(ConnectionActivity);
                    break;
                case "periodic":
                    mongoClient = new MongoClient(ConnectionPeriodic);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionAdverb);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Modificador> ConfigurationValue = mongoDatabase.GetCollection<Modificador>(CollectionAdverb);

            _adverbsCollection = ConfigurationValue;
        }

        public async Task<List<Modificador>> GetAsync() =>
            await _adverbsCollection.Find(_ => true).ToListAsync();

        public async Task<Modificador> GetAsync(string id) =>
            await _adverbsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Modificador> GetSentenceSimpleAsync(string name) =>
            await _adverbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Modificador modificador) =>
            await _adverbsCollection.InsertOneAsync(modificador);

        public async Task UpdateAsync(Modificador ligacao) =>
            await _adverbsCollection.ReplaceOneAsync(index => index.Id == ligacao.Id, ligacao);

        public async Task RemoveAsync(string id) =>
            await _adverbsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
