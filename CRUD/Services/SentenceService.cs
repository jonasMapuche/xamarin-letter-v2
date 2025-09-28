using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class SentenceService
    {
        public static string ConnectionSentence { get; set; }
        public static string ConnectionVerb { get; set; }
        public static string ConnectionChord { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionSentence { get; set; }

        private readonly IMongoCollection<Ditado> _sentencesCollection;

        public SentenceService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "verb":
                    mongoClient = new MongoClient(ConnectionVerb);
                    break;
                case "chord":
                    mongoClient = new MongoClient(ConnectionChord);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionSentence);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Ditado> ConfigurationValue = mongoDatabase.GetCollection<Ditado>(CollectionSentence);

            _sentencesCollection = ConfigurationValue;
        }

        public async Task<List<Ditado>> GetAsync() =>
            await _sentencesCollection.Find(_ => true).ToListAsync();

        public async Task<Ditado> GetAsync(string id) =>
            await _sentencesCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Ditado> GetSentenceSimpleAsync(string impulso) =>
            await _sentencesCollection.Find(index => index.impulso == impulso).FirstOrDefaultAsync();

        public async Task CreateAsync(Ditado ditado) =>
            await _sentencesCollection.InsertOneAsync(ditado);

        public async Task UpdateAsync(Ditado ditado) =>
            await _sentencesCollection.ReplaceOneAsync(index => index.Id == ditado.Id, ditado);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Ditado> filter = Builders<Ditado>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Ditado> update = Builders<Ditado>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _sentencesCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _sentencesCollection.DeleteOneAsync(index => index.Id == id);
    }
}
