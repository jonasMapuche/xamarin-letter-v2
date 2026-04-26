using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class LetterService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionLetter { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Aula> _lettersCollection;

        public LetterService(string connection)
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
            IMongoCollection<Aula> ConfigurationValue = mongoDatabase.GetCollection<Aula>(CollectionLetter);

            _lettersCollection = ConfigurationValue;
        }

        public async Task<List<Aula>> GetAsync() =>
            await _lettersCollection.Find(_ => true).ToListAsync();

        public async Task<Aula> GetAsync(string id) =>
            await _lettersCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Aula> GetSentenceSimpleAsync(string lesson) =>
            await _lettersCollection.Find(index => index.nome == lesson).FirstOrDefaultAsync();

        public async Task CreateAsync(Aula aula) =>
            await _lettersCollection.InsertOneAsync(aula);

        public async Task UpdateAsync(Aula aula) =>
            await _lettersCollection.ReplaceOneAsync(index => index.Id == aula.Id, aula);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Aula> filter = Builders<Aula>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Aula> update = Builders<Aula>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _lettersCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _lettersCollection.DeleteOneAsync(index => index.Id == id);

    }
}
