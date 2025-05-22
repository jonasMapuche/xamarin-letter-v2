using Android.Icu.Text;
using Javax.Security.Auth;
using Letter.Models;
using Letter.ViewModel;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Android.Content.ClipData;
using static Android.Provider.UserDictionary;

namespace Letter.ViewsModels
{
    public class MainViewModel
    {
        //---
        public static readonly LetterViewModel _lettersViewModel = new LetterViewModel();
        public static readonly PronounViewModel _pronounsViewModel = new PronounViewModel();
        public static readonly VerbViewModel _verbsViewModel = new VerbViewModel();
        public static readonly SentenceViewModel _sentencesViewModel = new SentenceViewModel();
        //---
        private string ENGLISH = "english";
        private string DEUTSCH = "deutsch";
        private string ITALIANO = "italiano";
        private string FRANCAIS = "français";
        private string ESPANOL = "espanõl";
        //---
        private List<EstoutroModel> _pronoun_english = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_english = new List<DitadoModel>();
        private List<EstoutroModel> _pronoun_deutsch = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_deutsch = new List<DitadoModel>();
        private List<EstoutroModel> _pronoun_italiano = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_italiano = new List<DitadoModel>();
        private List<EstoutroModel> _pronoun_francais = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_francais = new List<DitadoModel>();
        private List<EstoutroModel> _pronoun_espanol = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_espanol = new List<DitadoModel>();
        //---
        public int VIEW_TYPE_SEND = 1;
        public int VIEW_TYPE_RECEIVED = 2;
        //---
        private string url = "http://api.stomach.com.br:8885/";
        HttpClient client = new HttpClient();
        //---
        private string SUBJECT = "sujeito";
        private string PREDICATE = "predicado";
        private string PRONOUN = "pronome";
        private string NOUN = "substantivo";
        private string VERB = "verb";
        private string PESSOAL = "pessoal";
        //---
        private List<LicaoModel> _lesson_english;
        private List<LicaoModel> _lesson_deutsch;
        private List<LicaoModel> _lesson_italiano;
        private List<LicaoModel> _lesson_francais;
        private List<LicaoModel> _lesson_espanol;

        public MainViewModel()
        {
            //---
            _pronoun_english = GetPronoun(ENGLISH, PESSOAL).Distinct().ToList();
            _sentence_english = GetSentence(ENGLISH).Distinct().ToList();
            _pronoun_deutsch = GetPronoun(DEUTSCH).Distinct().ToList();
            _sentence_deutsch = GetSentence(DEUTSCH).Distinct().ToList();
            _pronoun_italiano = GetPronoun(ITALIANO).Distinct().ToList();
            _sentence_italiano = GetSentence(ITALIANO).Distinct().ToList();
            _pronoun_francais = GetPronoun(FRANCAIS).Distinct().ToList();
            _sentence_francais = GetSentence(FRANCAIS).Distinct().ToList();
            _pronoun_espanol = GetPronoun(ESPANOL).Distinct().ToList();
            _sentence_espanol = GetSentence(ESPANOL).Distinct().ToList();
        }

        private List<EstoutroModel> SelectPronoun(string language)
        {
            try
            {
                if (language == ENGLISH) return _pronoun_english;
                if (language == DEUTSCH) return _pronoun_deutsch;
                if (language == ITALIANO) return _pronoun_italiano;
                if (language == FRANCAIS) return _pronoun_francais;
                if (language == ESPANOL) return _pronoun_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<DitadoModel> SelectSentence(string language)
        {
            try
            {
                if (language == ENGLISH) return _sentence_english;
                if (language == DEUTSCH) return _sentence_deutsch;
                if (language == ITALIANO) return _sentence_italiano;
                if (language == FRANCAIS) return _sentence_francais;
                if (language == ESPANOL) return _sentence_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetLesson(string language, List<LicaoModel> lesson_word)
        {
            try
            {
                if (language == ENGLISH) _lesson_english = lesson_word;
                if (language == DEUTSCH) _lesson_deutsch = lesson_word;
                if (language == ITALIANO) _lesson_italiano = lesson_word;
                if (language == FRANCAIS) _lesson_francais = lesson_word;
                if (language == ESPANOL) _lesson_espanol = lesson_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<LicaoModel> SelectLesson(string language)
        {
            try
            {
                if (language == ENGLISH) return _lesson_english;
                if (language == DEUTSCH) return _lesson_deutsch;
                if (language == ITALIANO) return _lesson_italiano;
                if (language == FRANCAIS) return _lesson_francais;
                if (language == ESPANOL) return _lesson_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
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

        public ElocucaoModel GetVerb(string language, string verb)
        {
            try
            {
                return _verbsViewModel.GetVerb(language, verb);
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

        public List<EstoutroModel> GetPronoun(string language, string type)
        {
            try
            {
                return _pronounsViewModel.GetLanguage(language, type);
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

        public List<WordModel> GetNext(FraseModel lesson, string language)
        {
            try
            {
                //---
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word2Vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                List<WordModel> word_model = new List<WordModel>();
                //---
                foreach (var noun in lesson.conteudo.substantivo)
                {
                    //---
                    foreach (var elocucao in lesson.conteudo.verbo)
                    {
                        //---
                        List<ElocucaoModel> verbs = GetModel(language, elocucao).Distinct().ToList();
                        foreach (var verb in verbs)
                        {
                            //---
                            bool similarityPredicative = Similarity(word2Vec, vocabulary, verb.nome.ToLower(), noun.ToLower());
                            //---
                            List<WordModel> iten_word = new List<WordModel>();
                            if (similarityPredicative) iten_word = Predicate(verb.nome, verb.modelo, noun);
                            iten_word.ForEach(index =>
                            {
                                word_model.Add(index);
                            });
                            //---
                            if (word_model.Count == 0) continue;
                            //---
                            foreach (var pronoun in pronouns)
                            {
                                //---
                                bool similaritySubject = Similarity(word2Vec, vocabulary, pronoun.nome.ToLower(), verb.nome.ToLower());
                                //---
                                iten_word = new List<WordModel>();
                                if (similaritySubject) iten_word = Subject(pronoun.nome);
                                iten_word.ForEach(index =>
                                {
                                    word_model.Add(index);
                                });
                                //---
                                if (word_model.Count == 3) goto EndOfLesson;
                            }
                        }
                    }
                }
            //---
            EndOfLesson:
                //---
                if (word_model.Count == 0) word_model = GetNextSample(lesson, language);
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> GetNextSample(FraseModel lesson, string language)
        {
            try
            {
                //---
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                List<WordModel> word_model = new List<WordModel>();
                //---
                foreach (var elocucao in lesson.conteudo.verbo)
                {
                    //---
                    List<ElocucaoModel> verbs = GetModel(language, elocucao).Distinct().ToList();
                    foreach (var verb in verbs)
                    {
                        foreach (var pronoun in pronouns)
                        {
                            //---
                            bool similarity_subject = Similarity(word_2_vec, vocabulary, pronoun.nome.ToLower(), verb.nome.ToLower());
                            //---
                            List<WordModel> iten_word = new List<WordModel>();
                            iten_word = new List<WordModel>();
                            //---
                            if (similarity_subject) iten_word = Subject(pronoun.nome, verb.nome, verb.modelo);
                            iten_word.ForEach(index =>
                            {
                                word_model.Add(index);
                            });
                            //---
                            if (word_model.Count == 2) goto EndOfLesson;
                        }
                    }
                }
            //---
            EndOfLesson:
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Predicate(string verb, string model, string noun)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = new List<WordModel>();
                iten_word = PredicateVerb(verb, model);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = PredicateNoun(noun);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Subject(string pronoun)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                new_word = SubjectPronoun(pronoun);
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Subject(string pronoun, string verb, string model)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = new List<WordModel>();
                iten_word = SubjectPronoun(pronoun);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = PredicateVerb(verb, model);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> PredicateVerb(string verb, string model)
        {
            try
            {
                //---
                List<WordModel> word_model = new List<WordModel>();
                //---
                WordModel word = new WordModel();
                word.term = verb.ToLower();
                word.kind = "verbo";
                word.sentense = "predicado";
                word.model = model.ToLower();
                word_model.Add(word);
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> PredicateNoun(string noun)
        {
            try
            {
                //---
                List<WordModel> word_model = new List<WordModel>();
                WordModel word = new WordModel();
                word.term = noun.ToLower();
                word.kind = "substantivo";
                word.sentense = "predicado";
                word_model.Add(word);
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private List<WordModel> SubjectPronoun(string pronoun)
        {
            try
            {
                //---
                List<WordModel> word_model = new List<WordModel>();
                //---
                WordModel word = new WordModel();
                word.term = pronoun.ToLower();
                word.kind = "pronone";
                word.sentense = "sujeito";
                word_model.Add(word);
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool Similarity(Dictionary<(string, string), int> word_2_vec, HashSet<string> vocabulary, string target, string target1)
        {
            try
            {
                //---
                if ((Array.IndexOf(vocabulary.ToArray(), target) == -1) || (Array.IndexOf(vocabulary.ToArray(), target1) == -1))
                {
                    return false;
                }
                //---
                bool similarity = false;
                foreach (KeyValuePair<(string, string), int> value in word_2_vec)
                {
                    if ((value.Key.Item1 == target) && (value.Key.Item2 == target1))
                    {
                        similarity = true;
                        break;
                    }
                    ;
                }
                //---
                return similarity;
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
                ditado = ditado.Replace("!", " ! ");
                ditado = ditado.Replace("?", " ? ");
                ditado = ditado.Replace("¿", " ¿ ");
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

        private Dictionary<(string, string), int> Word2Vec(List<DitadoModel> sentences)
        {
            //---
            Dictionary<(string, string), int> word_pairs = new Dictionary<(string, string), int>();
            string[] words = Saw(sentences).Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                var pair = (words[i], words[i + 1]);
                if ((pair.Item1 == ".") || (pair.Item2 == ".")) continue;
                if ((pair.Item1 == "!") || (pair.Item2 == "!")) continue;
                if ((pair.Item1 == "?") || (pair.Item2 == "?")) continue;
                if ((pair.Item1 == "¿") || (pair.Item2 == "¿")) continue;
                if (word_pairs.TryGetValue(pair, out int value))
                {
                    word_pairs[pair] = ++value;
                }
                else
                {
                    word_pairs[pair] = 1;
                }
            }
            //---
            return word_pairs;
        }

        private static string RemoveAccent(string input)
        {
            string normalized_string = input.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char i in normalized_string)
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

        public List<WordModel> GetDefault(List<FraseModel> book, FraseModel lesson, string language, List<WordModel> word_model)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word2Vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string pronoun = word_model.Find(index => index.kind == PRONOUN && index.sentense == SUBJECT).ToString();
                string verb = word_model.Find(index => index.kind == VERB && index.sentense == PREDICATE).ToString();
                string noun = word_model.Find(index => index.kind == NOUN && index.sentense == PREDICATE).ToString();
                //---
                List<WordModel> phrase = new List<WordModel>();
                //---
                string model = GetVerb(language, verb).modelo;
                //---
                int count_elocution = 0;
                foreach (var elocution in lesson.conteudo.verbo.OrderBy(index => index).ToList())
                {
                    //---
                    if (count_elocution++ < elocution.IndexOf(model)) continue;
                    //---
                    List<ElocucaoModel> verbs = GetModel(language, elocution).Distinct().OrderBy(index => index).ToList();
                    int count_diction = 0;
                    foreach (var diction in verbs.OrderBy(index => index).ToList())
                    {
                        //---
                        if (count_diction++ < diction.nome.IndexOf(verb)) continue;
                        //---
                        int count_estrouto = 0;
                        foreach (var estrouto in pronouns.OrderBy(index => index.nome).ToList())
                        {
                            //---
                            if (count_estrouto++ < estrouto.nome.IndexOf(pronoun)) continue;
                            //---
                            foreach (var item in diction.teor)
                            {
                                //---
                                if (item.pronome.Contains(estrouto.nome))
                                {
                                    //---
                                    List<WordModel> iten_word = new List<WordModel>();
                                    iten_word = Subject(item.pronome.ToString(), diction.nome.ToString(), diction.modelo.ToString());
                                    iten_word.ForEach(index =>
                                    {
                                        new_word.Add(index);
                                    });
                                    break;
                                }
                            }
                            if (new_word.Count > 0)
                            {
                                //---
                                int count_noun = 0;
                                foreach (var fame in lesson.conteudo.substantivo.OrderBy(index => index).ToList())
                                {
                                    //---
                                    if (count_noun++ < fame.IndexOf(noun)) continue;
                                    //---
                                }
                            }
                        }
                    }
                }
                //---
                return phrase;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> GetLoopVerb(List<ElocucaoModel> list_verb, WordModel verb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                int count_elocution = 0;
                foreach (var elocucao in list_verb.OrderBy(index => index).ToList())
                {
                    //---
                    if (count_elocution++ <= elocucao.nome.IndexOf(verb.term)) continue;
                    //---
                    new_word = PredicateVerb(verb.term, verb.model);
                    if (new_word.Count > 0) break;
                }
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<WordModel> GetLoopPronoun(List<EstoutroModel> list_pronoun, WordModel pronoun)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                int count_estrouto = 0;
                foreach (var estrouto in list_pronoun.OrderBy(index => index.nome).ToList())
                {
                    //---
                    if (count_estrouto++ <= estrouto.nome.IndexOf(pronoun.term)) continue;
                    //---
                    new_word = SubjectPronoun(estrouto.nome);
                    if (new_word.Count() > 0) break;
                }
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<WordModel> GetLoopNoun(List<String> list_noun, WordModel noun)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                int count_substantive = 0;
                foreach (var substantive in list_noun.OrderBy(index => index).ToList())
                {
                    //---
                    if (count_substantive++ <= substantive.IndexOf(noun.term)) continue;
                    //---
                    new_word = PredicateNoun(substantive);
                    if (new_word.Count > 0) break;
                }
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<WordModel> GetPronoun(string language, WordModel pronoun, ElocucaoModel verb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                //---
                int count_estrouto = 0;
                foreach (var estrouto in pronouns.OrderBy(index => index.nome).ToList())
                {
                    //---
                    if (count_estrouto++ <= estrouto.nome.IndexOf(pronoun.term)) continue;
                    //---
                    foreach (var elocucao in verb.teor)
                    {
                        //---
                        if (elocucao.pronome.Contains(estrouto.nome))
                        {
                            //---
                            new_word = SubjectPronoun(estrouto.nome);
                        }
                        //---
                        if (new_word.Count() > 0) break;
                    }
                    if (new_word.Count() > 0) break;
                }
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<EstoutroModel> SetPronoun(string language)
        {
            try
            {
                //---
                List<EstoutroModel> list_pronoun = new List<EstoutroModel>();
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                //---
                foreach (var estrouto in pronouns.OrderBy(index => index.nome).ToList())
                {
                    //---
                    list_pronoun.Add(estrouto);
                }
                return list_pronoun;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<ElocucaoModel> SetVerb(string language, FraseModel lesson)
        {
            try
            {
                //---
                List<ElocucaoModel> list_verb = new List<ElocucaoModel>();
                //---
                foreach (var model in lesson.conteudo.verbo.OrderBy(index => index).ToList())
                {
                    //---
                    List<ElocucaoModel> verbs = GetModel(language, model).Distinct().OrderBy(index => index).ToList();
                    foreach (var elocution in verbs.OrderBy(index => index).ToList())
                    {
                        //---
                        list_verb.Add(elocution);
                    }
                }
                return list_verb;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<String> SetNoun(string language, FraseModel lesson, List<FraseModel> book)
        {
            try
            {
                //---
                List<String> list_noun = new List<String>();
                //---
                foreach (var substantive in book.Find(index => index.ordem < lesson.ordem).conteudo.substantivo.Distinct().OrderBy(index => index).ToList())
                {
                    //---
                    list_noun.Add(substantive.ToString());
                }
                return list_noun;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> SetLesson(List<string> list_noun, List<ElocucaoModel> list_verb, List<EstoutroModel> list_pronoun)
        {
            try 
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                foreach (var verb in list_verb)
                {
                    foreach (var pronoun in list_pronoun)
                    {
                        foreach (var noun in list_noun)
                        {
                            //---
                            List<WordModel> new_word = new List<WordModel>();
                            List<WordModel> iten_word = new List<WordModel>();
                            iten_word = Predicate(verb.nome, verb.modelo, noun);
                            iten_word.ForEach(index =>
                            {
                                new_word.Add(index);
                            });
                            //---
                            iten_word = new List<WordModel>();
                            iten_word = Subject(pronoun.nome);
                            iten_word.ForEach(index =>
                            {
                                new_word.Add(index);
                            });
                            LicaoModel lesson_iten = new LicaoModel();
                            lesson_iten.lecture = new_word;
                            lesson_word.Add(lesson_iten);
                        }
                    }
                }
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<WordModel> GetNext(string language, FraseModel lesson, List<FraseModel> book)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<string> list_noun = SetNoun(language, lesson, book);
                List<ElocucaoModel> list_verb = SetVerb(language, lesson);
                List<EstoutroModel> list_pronoun = SetPronoun(language);
                //---
                List <LicaoModel> lesson_word = SetLesson(list_noun, list_verb, list_pronoun);
                SetLesson(language, lesson_word);
                //---
                foreach (LicaoModel phrase in lesson_word)
                {
                    //---
                    new_word = Authenticate(language, phrase);
                    if (new_word.Count == 3) break;
                }
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<WordModel> GetDown(string language, List<WordModel> word_model, bool reverse)
        {
            try
            {
                //---
                WordModel word_pronoun = word_model.Find(index => index.kind == PRONOUN && index.sentense == SUBJECT);
                WordModel word_verb = word_model.Find(index => index.kind == VERB && index.sentense == PREDICATE);
                WordModel word_noun = word_model.Find(index => index.kind == NOUN && index.sentense == PREDICATE);
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<LicaoModel> lesson_word = SelectLesson(language);
                //---
                if (!reverse) lesson_word.Reverse();
                //---
                bool next = false;
                foreach (LicaoModel lesson in lesson_word)
                {
                    WordModel iten_pronoun = lesson.lecture.Find(index => index.kind == PRONOUN && index.sentense == SUBJECT);
                    WordModel iten_verb = lesson.lecture.Find(index => index.kind == VERB && index.sentense == PREDICATE);
                    WordModel iten_noun = lesson.lecture.Find(index => index.kind == NOUN && index.sentense == PREDICATE);

                    if (!next)
                    {
                        if ((iten_pronoun.term == word_pronoun.term) && (iten_verb.term == word_verb.term) && (iten_noun.term == word_noun.term))
                        {
                            next = true;
                        }
                    } else
                    {
                        new_word = Authenticate(language, lesson);
                        if (new_word.Count == 3) break;
                    }
                }
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Authenticate (string language, LicaoModel lesson)
        {
            try
            {
                //---
                List <WordModel> new_word = new List<WordModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string pronoun = lesson.lecture.Find(index => index.kind == PRONOUN && index.sentense == SUBJECT).ToString();
                string verb = lesson.lecture.Find(index => index.kind == VERB && index.sentense == PREDICATE).ToString();
                string noun = lesson.lecture.Find(index => index.kind == NOUN && index.sentense == PREDICATE).ToString();
                //---
                bool similarity_predicative = Similarity(word_2_vec, vocabulary, verb.ToLower(), noun.ToLower());
                //---
                bool similarity_subject = Similarity(word_2_vec, vocabulary, pronoun.ToLower(), verb.ToLower());
                //---
                List<WordModel> iten_word = new List<WordModel>();
                if (similarity_predicative) iten_word = Predicate(verb, verb, noun);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                if (similarity_subject) iten_word = Subject(pronoun);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}