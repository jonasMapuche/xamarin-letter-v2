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
        private string VAR_SUBJECT = "sujeito";
        private string VAR_PREDICATE = "predicado";
        private string VAR_PRONOUN = "pronome";
        private string VAR_NOUN = "substantivo";
        private string VAR_VERB = "verbo";
        private string VAR_PESSOAL = "pessoal";
        //---
        private int VAR_QUANTITY_3 = 3;
        private int VAR_QUANTITY_2 = 2;
        //---
        private List<LicaoModel> _lesson_english;
        private List<LicaoModel> _lesson_deutsch;
        private List<LicaoModel> _lesson_italiano;
        private List<LicaoModel> _lesson_francais;
        private List<LicaoModel> _lesson_espanol;

        public MainViewModel()
        {
            //---
            _pronoun_english = GetPronoun(ENGLISH, VAR_PESSOAL).Distinct().ToList();
            _sentence_english = GetSentence(ENGLISH).Distinct().ToList();
            _pronoun_deutsch = GetPronoun(DEUTSCH, VAR_PESSOAL).Distinct().ToList();
            _sentence_deutsch = GetSentence(DEUTSCH).Distinct().ToList();
            _pronoun_italiano = GetPronoun(ITALIANO, VAR_PESSOAL).Distinct().ToList();
            _sentence_italiano = GetSentence(ITALIANO).Distinct().ToList();
            _pronoun_francais = GetPronoun(FRANCAIS, VAR_PESSOAL).Distinct().ToList();
            _sentence_francais = GetSentence(FRANCAIS).Distinct().ToList();
            _pronoun_espanol = GetPronoun(ESPANOL, VAR_PESSOAL).Distinct().ToList();
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
                word.kind = VAR_VERB;
                word.sentense = VAR_PREDICATE;
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
                word.kind = VAR_NOUN;
                word.sentense = VAR_PREDICATE;
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
                word.kind = VAR_PRONOUN;
                word.sentense = VAR_SUBJECT;
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
                ditado = ditado.Replace("'", " ' ");
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
                if ((pair.Item1 == "'") || (pair.Item2 == "'")) continue;
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

        public async Task<ResponseModel> GetHttp(string pronoun, string verb, string language)
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

        private List<EstoutroModel> SetSort(List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                List<EstoutroModel> order = new List<EstoutroModel>();
                order = pronoun;
                //---
                int count_pronoun = pronoun.Count();
                for (int num_first = 0; num_first < count_pronoun - 1; num_first++)
                {
                    //---
                    int min_index = num_first;
                    //---
                    for (int num_second = num_first + 1; num_second < count_pronoun; num_second++)
                    {
                        //---
                        int index_second = 0;
                        order[num_second].contento.ForEach(index =>
                        {
                            index_second = index.pessoa[0];
                        });
                        int index_first = 0;
                        order[min_index].contento.ForEach(index =>
                        {
                            index_first = index.pessoa[0];
                        });
                        //---
                        if (index_second < index_first)
                        {
                            //---
                            min_index = num_second;
                        }
                    }
                    //---
                    EstoutroModel temp = order[num_first];
                    order[num_first] = order[min_index];
                    order[min_index] = temp;
                }
                //---
                return order;
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
                lesson.conteudo.verbo.ForEach(model =>
                {
                    //---
                    List<ElocucaoModel> elocucao = GetModel(language, model.ToString());
                    elocucao.ForEach(verb =>
                    {
                        //---
                        list_verb.Add(verb);
                    });
                });
                //---
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
                foreach (FraseModel lecture in book.OrderBy(index => index.ordem).ToList())
                {
                    //---
                    if (lecture.ordem <= lesson.ordem)
                    {
                        //---
                        lecture.conteudo.substantivo.ForEach(noun =>
                        {
                            list_noun.Add(noun.ToString());
                        });
                    }
                }
                //---
                list_noun.Distinct();
                return list_noun;
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
                List<EstoutroModel> single_pronoun = new List<EstoutroModel>();
                pronouns.ForEach(estoutro =>
                {
                    estoutro.contento.ForEach(contento =>
                    {
                        if (contento.numero.Contains("singular"))
                            single_pronoun.Add(estoutro);
                    });
                });
                single_pronoun = SetSort(single_pronoun);
                //---
                List<EstoutroModel> plural_pronoun = new List<EstoutroModel>();
                pronouns.ForEach(estoutro =>
                {
                    estoutro.contento.ForEach(contento =>
                    {
                        if (contento.numero.Contains("plural"))
                            plural_pronoun.Add(estoutro);
                    });
                });
                plural_pronoun = SetSort(plural_pronoun);
                //---
                single_pronoun.ForEach(estrouto => list_pronoun.Add(estrouto));
                plural_pronoun.ForEach(estrouto => list_pronoun.Add(estrouto));
                //---
                return list_pronoun;
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
                List<LicaoModel> lesson_word = SetLesson(list_noun, list_verb, list_pronoun);
                SetLesson(language, lesson_word);
                //---
                foreach (LicaoModel phrase in lesson_word)
                {
                    //---
                    new_word = Authenticate(language, phrase.lecture, VAR_QUANTITY_3);
                    if (new_word.Count == 3) break;
                }
                //---
                if (new_word.Count == 0)
                {
                    //---
                    foreach (LicaoModel phrase in lesson_word)
                    {
                        //---
                        new_word = Authenticate(language, phrase.lecture, VAR_QUANTITY_2);
                        if (new_word.Count == 2) break;
                    }
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
                WordModel pronoun = word_model.Find(index => index.kind == VAR_PRONOUN && index.sentense == VAR_SUBJECT);
                WordModel verb = word_model.Find(index => index.kind == VAR_VERB && index.sentense == VAR_PREDICATE);
                WordModel noun = word_model.Find(index => index.kind == VAR_NOUN && index.sentense == VAR_PREDICATE);
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<LicaoModel> lesson_word = SelectLesson(language);
                //---
                if (!reverse) lesson_word.Reverse();
                //---
                bool last = false;
                if (word_model.Count == 3)
                {
                    //---
                    bool next = false;
                    int count_foreach = 0;
                    foreach (LicaoModel lesson in lesson_word)
                    {
                        //---
                        WordModel iten_pronoun = lesson.lecture.Find(index => index.kind == VAR_PRONOUN && index.sentense == VAR_SUBJECT);
                        WordModel iten_verb = lesson.lecture.Find(index => index.kind == VAR_VERB && index.sentense == VAR_PREDICATE);
                        WordModel iten_noun = lesson.lecture.Find(index => index.kind == VAR_NOUN && index.sentense == VAR_PREDICATE);
                        //---
                        if (!next)
                        {
                            if ((iten_pronoun.term == pronoun.term) && (iten_verb.term == verb.term) && (iten_noun.term == noun.term))
                                next = true;
                        }
                        else
                        {
                            new_word = Authenticate(language, lesson.lecture, VAR_QUANTITY_3);
                            if (new_word.Count == 3) break;
                        }
                        //---
                        count_foreach++;
                        if (lesson_word.Count == count_foreach)
                        {
                            last = true;
                            new_word = word_model;
                            break;
                        }
                    }
                }
                //---
                if (last)
                {
                    //---
                    if (!reverse) lesson_word.Reverse();
                    return new_word;
                }
                //---
                if ((word_model.Count == 2) || (new_word.Count == 0))
                {
                    //---
                    bool next = false;
                    int count_foreach = 0;
                    foreach (LicaoModel lesson in lesson_word)
                    {
                        //---
                        WordModel iten_pronoun = lesson.lecture.Find(index => index.kind == VAR_PRONOUN && index.sentense == VAR_SUBJECT);
                        WordModel iten_verb = lesson.lecture.Find(index => index.kind == VAR_VERB && index.sentense == VAR_PREDICATE);
                        //---
                        if (!next)
                        {
                            if ((iten_pronoun.term == pronoun.term) && (iten_verb.term == verb.term))
                                next = true;
                        }
                        else
                        {
                            new_word = Authenticate(language, lesson.lecture, VAR_QUANTITY_2);
                            if (new_word.Count == 2) break;
                        }
                        //---
                        count_foreach++;
                        if (lesson_word.Count == count_foreach) 
                        {
                            new_word = word_model;
                            break;
                        }
                    }
                }
                //---
                if (!reverse) lesson_word.Reverse();
                //---
                return new_word;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> Authenticate (string language, List<WordModel> lesson, int quantity)
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
                WordModel pronoun = lesson.Find(index => index.kind == VAR_PRONOUN && index.sentense == VAR_SUBJECT);
                WordModel verb = lesson.Find(index => index.kind == VAR_VERB && index.sentense == VAR_PREDICATE);
                WordModel noun = lesson.Find(index => index.kind == VAR_NOUN && index.sentense == VAR_PREDICATE);
                if (quantity == 3)
                {
                    //---
                    bool similarity_predicative = Similarity(word_2_vec, vocabulary, verb.term.ToLower(), noun.term.ToLower());
                    //---
                    bool similarity_subject = Similarity(word_2_vec, vocabulary, pronoun.term.ToLower(), verb.term.ToLower());
                    //---
                    List<WordModel> iten_word = new List<WordModel>();
                    if (similarity_predicative) iten_word = Predicate(verb.term, verb.term, noun.term);
                    iten_word.ForEach(index =>
                    {
                        new_word.Add(index);
                    });
                    //---
                    iten_word = new List<WordModel>();
                    if (similarity_subject) iten_word = Subject(pronoun.term);
                    iten_word.ForEach(index =>
                    {
                        new_word.Add(index);
                    });
                }
                if (quantity == 2)
                {
                    //---
                    bool similarity_subject = Similarity(word_2_vec, vocabulary, pronoun.term.ToLower(), verb.term.ToLower());
                    //---
                    List<WordModel> iten_word = new List<WordModel>();
                    if (similarity_subject)
                        iten_word = Subject(pronoun.term, verb.term, verb.model);
                    iten_word.ForEach(index =>
                    {
                        new_word.Add(index);
                    });
                }
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