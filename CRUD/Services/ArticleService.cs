using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class ArticleService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionArticle { get; set; }

        private readonly IMongoCollection<Preceito> _articlesCollection;

        public ArticleService(string connection)
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
            IMongoCollection<Preceito> ConfigurationValue = mongoDatabase.GetCollection<Preceito>(CollectionArticle);

            _articlesCollection = ConfigurationValue;
        }

        public async Task<List<Preceito>> GetAsync() =>
            await _articlesCollection.Find(_ => true).ToListAsync();

        public async Task<Preceito> GetAsync(string id) =>
            await _articlesCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Preceito> GetSentenceSimpleAsync(string name) =>
            await _articlesCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Preceito preceito) =>
            await _articlesCollection.InsertOneAsync(preceito);

        public async Task UpdateAsync(Preceito preceito) =>
            await _articlesCollection.ReplaceOneAsync(index => index.Id == preceito.Id, preceito);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Preceito> filter = Builders<Preceito>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Preceito> update = Builders<Preceito>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _articlesCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _articlesCollection.DeleteOneAsync(index => index.Id == id);
    }
}
