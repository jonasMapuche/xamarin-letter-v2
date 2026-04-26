using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class ConjunctionService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionConjunction { get; set; }

        private readonly IMongoCollection<Ligacao> _conjunctionsCollection;

        public ConjunctionService(string connection)
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
            IMongoCollection<Ligacao> ConfigurationValue = mongoDatabase.GetCollection<Ligacao>(CollectionConjunction);

            _conjunctionsCollection = ConfigurationValue;
        }

        public async Task<List<Ligacao>> GetAsync() =>
            await _conjunctionsCollection.Find(_ => true).ToListAsync();

        public async Task<Ligacao> GetAsync(string id) =>
            await _conjunctionsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Ligacao> GetSentenceSimpleAsync(string name) =>
            await _conjunctionsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Ligacao ligacao) =>
            await _conjunctionsCollection.InsertOneAsync(ligacao);

        public async Task UpdateAsync(Ligacao ligacao) =>
            await _conjunctionsCollection.ReplaceOneAsync(index => index.Id == ligacao.Id, ligacao);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Ligacao> filter = Builders<Ligacao>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Ligacao> update = Builders<Ligacao>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _conjunctionsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _conjunctionsCollection.DeleteOneAsync(index => index.Id == id);
    }
}
