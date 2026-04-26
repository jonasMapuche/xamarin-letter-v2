using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class AuxiliaryService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionAuxiliary { get; set; }

        private readonly IMongoCollection<Assistant> _auxiliarysCollection;

        public AuxiliaryService(string connection)
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
            IMongoCollection<Assistant> ConfigurationValue = mongoDatabase.GetCollection<Assistant>(CollectionAuxiliary);

            _auxiliarysCollection = ConfigurationValue;
        }

        public async Task<List<Assistant>> GetAsync() =>
            await _auxiliarysCollection.Find(_ => true).ToListAsync();

        public async Task<Assistant> GetAsync(string id) =>
            await _auxiliarysCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Assistant> GetSentenceSimpleAsync(string name) =>
            await _auxiliarysCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Assistant assistent) =>
            await _auxiliarysCollection.InsertOneAsync(assistent);

        public async Task UpdateAsync(Assistant assistent) =>
            await _auxiliarysCollection.ReplaceOneAsync(index => index.Id == assistent.Id, assistent);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Assistant> filter = Builders<Assistant>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Assistant> update = Builders<Assistant>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _auxiliarysCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }
        public async Task RemoveAsync(string id) =>
            await _auxiliarysCollection.DeleteOneAsync(index => index.Id == id);
    }
}
