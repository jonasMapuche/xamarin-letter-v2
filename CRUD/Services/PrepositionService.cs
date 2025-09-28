using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class PrepositionService
    {
        public static string ConnectionPreposition { get; set; }
        public static string ConnectionArticle { get; set; }
        public static string ConnectionPronoun { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionPreposition { get; set; }

        private readonly IMongoCollection<Juncao> _prepositionsCollection;

        public PrepositionService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "article":
                    mongoClient = new MongoClient(ConnectionArticle);
                    break;
                case "pronoun":
                    mongoClient = new MongoClient(ConnectionPronoun);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionPreposition);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Juncao> ConfigurationValue = mongoDatabase.GetCollection<Juncao>(CollectionPreposition);

            _prepositionsCollection = ConfigurationValue;
        }

        public async Task<List<Juncao>> GetAsync() =>
            await _prepositionsCollection.Find(_ => true).ToListAsync();

        public async Task<Juncao> GetAsync(string id) =>
            await _prepositionsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Juncao> GetSentenceSimpleAsync(string name) =>
            await _prepositionsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Juncao juncao) =>
            await _prepositionsCollection.InsertOneAsync(juncao);

        public async Task UpdateAsync(Juncao juncao) =>
            await _prepositionsCollection.ReplaceOneAsync(index => index.Id == juncao.Id, juncao);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Juncao> filter = Builders<Juncao>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Juncao> update = Builders<Juncao>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _prepositionsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _prepositionsCollection.DeleteOneAsync(index => index.Id == id);
    }
}
