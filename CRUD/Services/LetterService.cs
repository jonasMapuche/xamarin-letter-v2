using CRUD.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class LetterService
    {
        public static string ConnectionLetter { get; set; }
        public static string ConnectionChord { get; set; }
        public static string ConnectionValence { get; set; }
        public static string DatabaseName { get; set; }
        public static string CollectionLetter { get; set; }
        public static string JsonFile { get; set; }

        private readonly IMongoCollection<Aula> _lettersCollection;

        public LetterService(string connection)
        {
            MongoClient mongoClient;
            switch (connection)
            {
                case "valence":
                    mongoClient = new MongoClient(ConnectionValence);
                    break;
                case "chord":
                    mongoClient = new MongoClient(ConnectionChord);
                    break;
                default:
                    mongoClient = new MongoClient(ConnectionLetter);
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

        public async Task RemoveAsync(string id) =>
            await _lettersCollection.DeleteOneAsync(index => index.Id == id);

    }
}
