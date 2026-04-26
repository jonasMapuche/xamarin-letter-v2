using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class NumeralService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionNumeral { get; set; }

        private readonly IMongoCollection<Algarismo> _numeralsCollection;

        public NumeralService(string connection)
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
            IMongoCollection<Algarismo> ConfigurationValue = mongoDatabase.GetCollection<Algarismo>(CollectionNumeral);

            _numeralsCollection = ConfigurationValue;
        }

        public async Task<List<Algarismo>> GetAsync() =>
            await _numeralsCollection.Find(_ => true).ToListAsync();

        public async Task<Algarismo> GetAsync(string id) =>
            await _numeralsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Algarismo> GetSentenceSimpleAsync(string name) =>
            await _numeralsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Algarismo algarismo) =>
            await _numeralsCollection.InsertOneAsync(algarismo);

        public async Task UpdateAsync(Algarismo algarismo) =>
            await _numeralsCollection.ReplaceOneAsync(index => index.Id == algarismo.Id, algarismo);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Algarismo> filter = Builders<Algarismo>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Algarismo> update = Builders<Algarismo>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _numeralsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _numeralsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
