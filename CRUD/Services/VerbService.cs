using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class VerbService
    {
        public static string ConnectionVerb { get; set; }
        public static string ConnectionConjunction { get; set; }
        public static string ConnectionValence { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionVerb { get; set; }

        private readonly IMongoCollection<Elocucao> _verbsCollection;

        public VerbService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "conjunction":
                    mongoClient = new MongoClient(ConnectionConjunction);
                    break;
                case "valence":
                    mongoClient = new MongoClient(ConnectionValence);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionVerb);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Elocucao> ConfigurationValue = mongoDatabase.GetCollection<Elocucao>(CollectionVerb);

            _verbsCollection = ConfigurationValue;
        }

        public async Task<List<Elocucao>> GetAsync() =>
            await _verbsCollection.Find(_ => true).ToListAsync();

        public async Task<Elocucao> GetAsync(string id) =>
            await _verbsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Elocucao> GetSentenceSimpleAsync(string name) =>
            await _verbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task<List<Elocucao>> GetLanguageAsync(string language) =>
            await _verbsCollection.Find(index => index.linguagem == language).ToListAsync();

        public async Task CreateAsync(Elocucao elocucao) =>
            await _verbsCollection.InsertOneAsync(elocucao);

        public async Task UpdateAsync(Elocucao elocucao) =>
            await _verbsCollection.ReplaceOneAsync(index => index.Id == elocucao.Id, elocucao);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Elocucao> filter = Builders<Elocucao>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Elocucao> update = Builders<Elocucao>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _verbsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _verbsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
