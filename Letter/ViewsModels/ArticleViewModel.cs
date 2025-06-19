using Letter.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class ArticleViewModel
    {
        private static string ConnectionName { get; set; }
        private static string DatabaseName { get; set; }
        private static string CollectionArticle { get; set; }

        private readonly IMongoCollection<PreceitoModel> _articlesCollection;

        public ArticleViewModel()
        {
            ConnectionName = "mongodb://labrouste:freedown@ac-dzsg50m-shard-00-00.brox8ik.mongodb.net:27017,ac-dzsg50m-shard-00-01.brox8ik.mongodb.net:27017,ac-dzsg50m-shard-00-02.brox8ik.mongodb.net:27017/?ssl=true&replicaSet=atlas-143za4-shard-0&authSource=admin&retryWrites=true&w=majority&appName=clusterarticle";
            DatabaseName = "stomach";
            CollectionArticle = "article";

            var mongoClient = new MongoClient(ConnectionName);
            var mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            IMongoCollection<PreceitoModel> ConfigurationValue = mongoDatabase.GetCollection<PreceitoModel>(CollectionArticle);

            _articlesCollection = ConfigurationValue;
        }

        public PreceitoModel GetName(string name) => _articlesCollection.Find(index => index.nome == name).FirstOrDefault();

        public List<PreceitoModel> GetLanguage(string language) => _articlesCollection.Find(index => index.linguagem == language).ToList<PreceitoModel>();

        public async Task<PreceitoModel> GetPronounAsync(string name) => await _articlesCollection.Find(index => index.nome == name).FirstOrDefaultAsync();
    }
}