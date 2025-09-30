using CRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace CRUD.Services
{
    public class PostmanService
    {
        private readonly HttpClient _httpClient;
        private readonly string _postman_api_key = "PMAK-68d97172c1a8c10001cf7c95-e081e4e950dcada5d69c721fa9ba134875";
        private readonly string _postman_api_url = "https://api.getpostman.com/collections";
        public PostmanService()
        {
            HttpClient httpClient = new HttpClient();
            _httpClient = httpClient;
        }

        public async Task<List<PostmanCollection>> GetAsync(List<string> collections, List<string> folders)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("X-API-Key", _postman_api_key);
                var response = await _httpClient.GetAsync(_postman_api_url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    PostmanCollections postman = new PostmanCollections();
                    postman = JsonConvert.DeserializeObject<PostmanCollections>(result);
                    List<PostmanCollection> postmans = new List<PostmanCollection>();
                    foreach (PostmanCollection item in postman.collections)
                    {
                        foreach (string collection in collections)
                        {
                            if (item.name == collection)
                            {
                                List<PostmanCollection> local = new List<PostmanCollection>();
                                local = await GetFolderAsync(item.id, folders);
                                foreach (PostmanCollection value in local)
                                {
                                    PostmanCollection local_collection = new PostmanCollection();
                                    local_collection = value;
                                    local_collection.id_collection = item.id;
                                    postmans.Add(local_collection);
                                }
                            }
                        }
                    }
                    return postmans;
                }
                return new List<PostmanCollection>();
            }
            catch (Exception ex)
            {
                return new List<PostmanCollection>();
            }
        }

        public async Task<List<PostmanCollection>> GetFolderAsync(string id, List<string> folders)
        {
            try
            {
                string url = _postman_api_url + "/" + id;
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    PostmanFolders postman_folders = new PostmanFolders();
                    postman_folders = JsonConvert.DeserializeObject<PostmanFolders>(result);
                    List<PostmanCollection> words = new List<PostmanCollection>();
                    foreach (PostmanCollection item in postman_folders.collection.item)
                    {
                        foreach (string folder in folders)
                        {
                            if (item.name == folder)
                            {
                                List<PostmanCollection> request = new List<PostmanCollection>();
                                request = await GetItemAsync(item);
                                foreach (PostmanCollection collection in request)
                                {
                                    foreach (PostmanCollection word in collection.item)
                                    {
                                        words.Add(word);
                                    }
                                }
                            }
                        }
                    }
                    return words;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PostmanCollection>> GetItemAsync(PostmanCollection collection)
        {
            try
            {
                foreach (PostmanCollection item in collection.item)
                {
                    if ((item.name == "insertar") || (item.name == "1"))
                    {
                        List<PostmanCollection> request = new List<PostmanCollection>();
                        request = await GetItemAsync(item);
                        return request == null ? item.item : request;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PostmanRequest>> UpdateLanguageAsync(List<string> collections, List<string> folders, string value, string replace)
        {
            try
            {
                List<PostmanCollection> filter = await GetAsync(collections, folders);
                List<PostmanRequest> request = new List<PostmanRequest>();
                request = await UpdateAsync(filter, value, replace);

                return request;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<List<PostmanRequest>> UpdateAsync(List<PostmanCollection> collections, string value, string replace)
        {
            try
            {
                List<PostmanRequest> postman_requests = new List<PostmanRequest>();
                foreach (PostmanCollection item in collections)
                {
                    string url = _postman_api_url + "/" + item.id_collection + "/requests/" + item.id;
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        PostmanRequest request = new PostmanRequest();
                        request = JsonConvert.DeserializeObject<PostmanRequest>(result);
                        Elocucao elocucao = new Elocucao();
                        elocucao = JsonConvert.DeserializeObject<Elocucao>(request.data.rawModeData);
                        elocucao.Id = item.id;
                        if (elocucao.linguagem == value)
                        {
                            elocucao.linguagem = replace;
                            string raw_mode_data = JsonConvert.SerializeObject(elocucao);
                            request.data.rawModeData = raw_mode_data;
                            string serialize = JsonConvert.SerializeObject(request);
                            StringContent content = new StringContent(serialize, Encoding.UTF8, "application/json");
                            HttpResponseMessage update = await _httpClient.PutAsync(url, content);
                            if (update.IsSuccessStatusCode)
                            {
                                string responseBody = await update.Content.ReadAsStringAsync();
                                PostmanRequest request2 = new PostmanRequest();
                                request2 = JsonConvert.DeserializeObject<PostmanRequest>(responseBody);
                            }
                        }
                        postman_requests.Add(request);
                    }
                }
                return postman_requests;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
