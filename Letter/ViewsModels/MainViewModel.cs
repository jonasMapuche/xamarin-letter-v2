using CRUD.Models;
using Letter.Models;
using Letter.ViewModel;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class MainViewModel
    {
        public static readonly LetterViewModel _lettersViewModel = new LetterViewModel();
        public static readonly PronounViewModel _pronounsViewModel = new PronounViewModel();

        public int VIEW_TYPE_SEND = 1;
        public int VIEW_TYPE_RECEIVED = 2;

        private string url = "http://www.stomach.com.br:8885/";

        HttpClient client = new HttpClient();

        public List<String> GetSentenceSimple(string lesson)
        {
            FraseModel aula = _lettersViewModel.GetSentenceSimple(lesson);
            List<string> saida = new List<string>();
            if (aula != null)
            {
                saida.Add(aula.conteudo.pronome[0].ToString());
                saida.Add(aula.conteudo.verbo[0].ToString());
                saida.Add(aula.conteudo.substantivo[0].ToString());
            }
            else saida = null;
            return saida;
        }

        public List<FraseModel> GetLessonSimple(string language)
        {
            return _lettersViewModel.GetLessonSimple(true, language);
        }

        public List<EstoutroModel> GetPronoun(string language)
        {
            try
            {
                return _pronounsViewModel.GetLanguage(language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseModel> AgreePronome(string pronoun, string verb, string language)
        {
            try
            {
                //---            
                PronounModel message = new PronounModel();
                message.pronoun = pronoun;
                message.verb = verb;
                message.sender = VIEW_TYPE_SEND;
                message.language = language;
                //---
                string json = JsonConvert.SerializeObject(message);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                //---
                ResponseModel request = new ResponseModel();
                request = JsonConvert.DeserializeObject<ResponseModel>(result);
                return request;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

    }
}