using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class AdverbService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionAdverb { get; set; }

        private readonly IMongoCollection<Circustancia> _adverbsCollection;

        public AdverbService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "test":
                    mongoClient = new MongoClient(ConnectionTest);
                    break;
                case "production":
                    mongoClient = new MongoClient(ConnectionProduction);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionDevelopment);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Circustancia> ConfigurationValue = mongoDatabase.GetCollection<Circustancia>(CollectionAdverb);

            _adverbsCollection = ConfigurationValue;
        }

        public async Task<List<Circustancia>> GetAsync() =>
            await _adverbsCollection.Find(_ => true).ToListAsync();

        public async Task<Circustancia> GetAsync(string id) =>
            await _adverbsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Circustancia> GetSentenceSimpleAsync(string name) =>
            await _adverbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Circustancia circunstancia) =>
            await _adverbsCollection.InsertOneAsync(circunstancia);

        public async Task UpdateAsync(Circustancia circunstancia) =>
            await _adverbsCollection.ReplaceOneAsync(index => index.Id == circunstancia.Id, circunstancia);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Circustancia> filter = Builders<Circustancia>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Circustancia> update = Builders<Circustancia>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _adverbsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _adverbsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
