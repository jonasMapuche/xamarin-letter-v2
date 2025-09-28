using CRUD.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CRUD.Services
{
    public class PostmanService
    {
        private readonly HttpClient _httpClient;
        private readonly string _postman_api_url = "https://api.getpostman.com/collections";
        private readonly string _postman_api_key = "PMAK-68d97172c1a8c10001cf7c95-e081e4e950dcada5d69c721fa9ba134875";

        public PostmanService()
        {
            HttpClient httpClient = new HttpClient();
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync()
        {
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", _postman_api_key);
            var response = await _httpClient.GetAsync(_postman_api_url);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            return string.Empty;
        }

        public async Task<long> UpdateLanguageAsync(string language, string new_language)
        {
            /*
            FilterDefinition<Ligacao> filter = Builders<Ligacao>.Filter.Eq(index => index.linguagem, language);
            UpdateDefinition<Ligacao> update = Builders<Ligacao>.Update.Set(doc => doc.linguagem, new_language);
            UpdateResult result = await _conjunctionsCollection.UpdateManyAsync(filter, update);
            */
            return 0;
        }
    }
}
