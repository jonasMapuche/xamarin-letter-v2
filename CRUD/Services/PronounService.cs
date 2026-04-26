using CRUD.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class PronounService
    {
        public static string ConnectionDevelopment { get; set; }
        public static string ConnectionTest { get; set; }
        public static string ConnectionProduction { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionPronoun { get; set; }

        private readonly IMongoCollection<Estoutro> _pronounsCollection;

        public PronounService(string connection)
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
            IMongoCollection<Estoutro> ConfigurationValue = mongoDatabase.GetCollection<Estoutro>(CollectionPronoun);

            _pronounsCollection = ConfigurationValue;
        }

        public async Task<List<Estoutro>> GetAsync() =>
            await _pronounsCollection.Find(_ => true).ToListAsync();

        public async Task<Estoutro> GetAsync(string id) =>
            await _pronounsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Estoutro> GetSentenceSimpleAsync(string name) =>
            await _pronounsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Estoutro estrouto) =>
            await _pronounsCollection.InsertOneAsync(estrouto);

        public async Task UpdateAsync(Estoutro estrouto) =>
            await _pronounsCollection.ReplaceOneAsync(index => index.Id == estrouto.Id, estrouto);

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            FilterDefinition<Estoutro> filter = Builders<Estoutro>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Estoutro> update = Builders<Estoutro>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _pronounsCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount;
        }

        public async Task RemoveAsync(string id) =>
            await _pronounsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
