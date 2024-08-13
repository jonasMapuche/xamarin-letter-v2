using CRUD.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class NumeralService
    {
        public static string ConnectionNumeral { get; set; }
        public static string ConnectionPeriodic { get; set; }
        public static string ConnectionActivity { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionNumeral { get; set; }

        private readonly IMongoCollection<Algarismo> _adverbsCollection;

        public NumeralService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "activity":
                    mongoClient = new MongoClient(ConnectionActivity);
                    break;
                case "periodic":
                    mongoClient = new MongoClient(ConnectionPeriodic);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionNumeral);
                    break;
            }
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<Algarismo> ConfigurationValue = mongoDatabase.GetCollection<Algarismo>(CollectionNumeral);

            _adverbsCollection = ConfigurationValue;
        }

        public async Task<List<Algarismo>> GetAsync() =>
            await _adverbsCollection.Find(_ => true).ToListAsync();

        public async Task<Algarismo> GetAsync(string id) =>
            await _adverbsCollection.Find(index => index.Id == id).FirstOrDefaultAsync();

        public async Task<Algarismo> GetSentenceSimpleAsync(string name) =>
            await _adverbsCollection.Find(index => index.nome == name).FirstOrDefaultAsync();

        public async Task CreateAsync(Algarismo algarismo) =>
            await _adverbsCollection.InsertOneAsync(algarismo);

        public async Task UpdateAsync(Algarismo algarismo) =>
            await _adverbsCollection.ReplaceOneAsync(index => index.Id == algarismo.Id, algarismo);

        public async Task RemoveAsync(string id) =>
            await _adverbsCollection.DeleteOneAsync(index => index.Id == id);

    }
}
