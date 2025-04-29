using Javax.Security.Auth;
using Letter.Models;
using Letter.ViewModel;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Letter.ViewsModels
{
    public class MainViewModel
    {
        public static readonly LetterViewModel _lettersViewModel = new LetterViewModel();
        public static readonly PronounViewModel _pronounsViewModel = new PronounViewModel();
        public static readonly VerbViewModel _verbsViewModel = new VerbViewModel();
        public static readonly SentenceViewModel _sentencesViewModel = new SentenceViewModel();

        public int VIEW_TYPE_SEND = 1;
        public int VIEW_TYPE_RECEIVED = 2;
        private int EMBEDDED_DIM = 5;

        private string url = "http://api.stomach.com.br:8885/";

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
            try
            {
                return _lettersViewModel.GetLessonSimple(true, language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ElocucaoModel> GetModel(string language, string model)
        {
            try
            {
                return _verbsViewModel.GetModel(language, model);
            }
            catch (Exception)
            {
                throw;
            }
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

        public List<DitadoModel> GetSentence(string language)
        {
            try
            {
                return _sentencesViewModel.GetLanguage(language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WordModel> GetPhrase(FraseModel lesson, string verb, string language)
        {
            try
            {
                //---
                List<ElocucaoModel> verbs = GetModel(language, verb).Distinct().ToList();
                List<EstoutroModel> pronouns = GetPronoun(language).Distinct().ToList();
                List<DitadoModel> sentences = GetSentence(language).Distinct().ToList();
                //---
                double[][] embeddedMatrix = Word2Vec(sentences);
                //---
                List<WordModel> wordModel = new List<WordModel>();
                //---
                List<WordModel> itenWordModel = new List<WordModel>();
                itenWordModel = Predicate(embeddedMatrix, sentences, verbs, lesson.conteudo.substantivo[0].ToString());
                itenWordModel.ForEach(index =>
                {
                    wordModel.Add(index);
                });
                //---
                itenWordModel = new List<WordModel>();
                itenWordModel = Subject(embeddedMatrix, sentences, pronouns, verbs);
                itenWordModel.ForEach(index =>
                {
                    wordModel.Add(index);
                });
                //---
                return wordModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Predicate(double[][] embeddedMatrix, List<DitadoModel> sentences, List<ElocucaoModel> verbs, string noun)
        {
            try
            {
                //---
                List<WordModel> wordModel = new List<WordModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentences);
                verbs.ForEach(index =>
                {
                    bool similarity = Similarity(embeddedMatrix, vocabulary, index.nome, noun);
                    if (similarity)
                    {
                        WordModel word = new WordModel();
                        word.Term = index.nome;
                        word.Class = "verbo";
                        word.Sentense = "predicado";
                        wordModel.Add(word);
                        word = new WordModel();
                        word.Term = index.nome;
                        word.Class = "substantivo";
                        word.Sentense = "predicado";
                        wordModel.Add(word);
                    }
                });
                //---
                return wordModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Subject(double[][] embeddedMatrix, List<DitadoModel> sentences, List<EstoutroModel> pronouns, List<ElocucaoModel> verbs)
        {
            try
            {
                //---
                List<WordModel> wordModel = new List<WordModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentences);
                verbs.ForEach(index =>
                {
                    pronouns.ForEach(index2 =>
                    {
                        bool similarity = Similarity(embeddedMatrix, vocabulary, index.nome, index2.nome);
                        if (similarity) 
                        {
                            WordModel word = new WordModel();
                            word.Term = index2.nome;
                            word.Class = "pronome";
                            word.Sentense = "sujeito";
                            wordModel.Add(word);
                        }
                    });

                });
                //---
                return wordModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Similarity(double[][] embeddedMatrix, HashSet<string> vocabulary, string similary, string target)
        {
            try
            {
                //---
                int targetIndex = Array.IndexOf(vocabulary.ToArray(), target);
                //---
                if (targetIndex == -1)
                {
                    return false;
                }
                //---
                int embeddedDim = EMBEDDED_DIM;
                double similarity = double.MinValue;
                int similarityIndex = -1;
                //---
                for (int i = 0; i < vocabulary.Count; i++)
                {
                    //---
                    if (i == targetIndex) continue;
                    //---
                    double likeness = 0;
                    for (int j = 0; j < embeddedDim; j++)
                    {
                        likeness += embeddedMatrix[targetIndex][j] * embeddedMatrix[i][j];
                    }
                    //---
                    if (likeness > similarity)
                    {
                        similarity = likeness;
                        similarityIndex = i;
                    }
                }
                string similarityWord = vocabulary.ElementAt(similarityIndex);
                //---
                return similary == similarityWord ? true: false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string Saw(List<DitadoModel> sentences)
        {
            try
            {
                //---
                string ditado = "";
                sentences.ForEach(index =>
                {
                    ditado = ditado + index.impulso;
                });
                ditado = ditado.ToLower();
                ditado = ditado.Replace(".", " . ");
                ditado = RemoveAccent(ditado);
                return ditado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HashSet<string> Vocabulary(List<DitadoModel> sentences)
        {
            try
            {
                //---
                string ditado = Saw(sentences);
                //---
                HashSet<string> vocabulary = new HashSet<string>(ditado.Split(' '));
                //---
                return vocabulary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private double[][] Word2Vec (List<DitadoModel> sentences)
        {
            //---
            HashSet<string> vocabulary = Vocabulary(sentences);
            //---
            int embeddedDim = EMBEDDED_DIM;
            double[][] embeddedMatrix = new double[vocabulary.Count][];
            Random rand = new Random();
            List<EmbeddedModel> embedded = new List<EmbeddedModel>();
            for (int i = 0; i < vocabulary.Count; i++)
            {
                embeddedMatrix[i] = new double[embeddedDim];
                //---
                EmbeddedModel item = new EmbeddedModel();
                item.Line = new double[embeddedDim];
                //---
                for (int j = 0; j < embeddedDim; j++)
                {
                    embeddedMatrix[i][j] = rand.NextDouble();
                    item.Column = i;
                    item.Line[j] = embeddedMatrix[i][j];
                }
                embedded.Add(item);
            }
            //---
            Dictionary<(string, string), int> wordPairs = new Dictionary<(string, string), int>();
            string[] words = Saw(sentences).Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                var pair = (words[i], words[i + 1]);
                if ((pair.Item1 == ".") || (pair.Item2 == ".")) continue;
                if (wordPairs.TryGetValue(pair, out int value))
                {
                    wordPairs[pair] = ++value;
                }
                else
                {
                    wordPairs[pair] = 1;
                }
            }
            //---
            foreach (var pair in wordPairs.Keys)
            {
                //---
                String[] stringArray = new String[vocabulary.Count];
                vocabulary.CopyTo(stringArray);
                //---
                int indexWord1 = Array.IndexOf(stringArray, pair.Item1);
                int indexWord2 = Array.IndexOf(stringArray, pair.Item2);
                for (int j = 0; j < embeddedDim; j++)
                {
                    embeddedMatrix[indexWord1][j] += embeddedMatrix[indexWord2][j] * wordPairs[pair];
                }
            }
            //---
            for (int i = 0; i < vocabulary.Count; i++)
            {
                double norm = Math.Sqrt(embeddedMatrix[i].Sum(x => x * x));
                for (int j = 0; j < embeddedDim; j++)
                {
                    embeddedMatrix[i][j] /= norm;
                }
            }
            //---
            return embeddedMatrix;
        }

        private static string RemoveAccent(string input) 
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char i in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(i) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(i);
                }
            }
            return builder.ToString();
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