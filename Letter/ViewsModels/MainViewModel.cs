using Android.Test.Suitebuilder.Annotation;
using Android.Text;
using Letter.Models;
using Letter.ViewModel;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
        public static readonly ArticleViewModel _articlesViewModel = new ArticleViewModel();
        public static readonly VerbViewModel _verbsViewModel = new VerbViewModel();
        public static readonly SentenceViewModel _sentencesViewModel = new SentenceViewModel();
        public static readonly DigitViewModel _digitsViewModel = new DigitViewModel();
        public static readonly PrepositionViewModel _prepositionsViewModel = new PrepositionViewModel();
        //---
        private string ENGLISH = "english";
        private string DEUTSCH = "deutsch";
        private string ITALIANO = "italiano";
        private string FRANCAIS = "français";
        private string ESPANOL = "espanõl";
        //---
        private List<EstoutroModel> _pronoun_english = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_english = new List<DitadoModel>();
        private List<EstoutroModel> _adjective_english = new List<EstoutroModel>();
        private List<PreceitoModel> _article_english = new List<PreceitoModel>();
        private List<AlgarismoModel> _digit_english = new List<AlgarismoModel>();
        private List<JuncaoModel> _preposition_english = new List<JuncaoModel>();
        //---
        private List<EstoutroModel> _pronoun_deutsch = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_deutsch = new List<DitadoModel>();
        private List<EstoutroModel> _adjective_deutsch = new List<EstoutroModel>();
        private List<PreceitoModel> _article_deutsch = new List<PreceitoModel>();
        private List<AlgarismoModel> _digit_deutsch = new List<AlgarismoModel>();
        private List<JuncaoModel> _preposition_deutsch = new List<JuncaoModel>();
        //---
        private List<EstoutroModel> _pronoun_italiano = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_italiano = new List<DitadoModel>();
        private List<EstoutroModel> _adjective_italiano = new List<EstoutroModel>();
        private List<PreceitoModel> _article_italiano = new List<PreceitoModel>();
        private List<AlgarismoModel> _digit_italiano = new List<AlgarismoModel>();
        private List<JuncaoModel> _preposition_italiano = new List<JuncaoModel>();
        //---
        private List<EstoutroModel> _pronoun_francais = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_francais = new List<DitadoModel>();
        private List<EstoutroModel> _adjective_francais = new List<EstoutroModel>();
        private List<PreceitoModel> _article_francais = new List<PreceitoModel>();
        private List<AlgarismoModel> _digit_francais = new List<AlgarismoModel>();
        private List<JuncaoModel> _preposition_francais = new List<JuncaoModel>();
        //---
        private List<EstoutroModel> _pronoun_espanol = new List<EstoutroModel>();
        private List<DitadoModel> _sentence_espanol = new List<DitadoModel>();
        private List<EstoutroModel> _adjective_espanol = new List<EstoutroModel>();
        private List<PreceitoModel> _article_espanol = new List<PreceitoModel>();
        private List<AlgarismoModel> _digit_espanol = new List<AlgarismoModel>();
        private List<JuncaoModel> _preposition_espanol = new List<JuncaoModel>();
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
        private string VAR_PERSONAL = "pessoal";
        private string VAR_ADJECTIVE = "adjetivo";
        private string VAR_ARTICLE = "article";
        private string VAR_DIGIT = "numeral";
        private string VAR_PREPOSITION = "preposicao";
        private string VAR_POSSESSIVE = "possessivo";
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
            _pronoun_english = GetPronoun(ENGLISH).Distinct().ToList();
            _sentence_english = GetSentence(ENGLISH).Distinct().ToList();
            _digit_english = GetDigit(ENGLISH).Distinct().ToList();
            _article_english = GetArticle(ENGLISH).Distinct().ToList();
            _preposition_english = GetPreposition(ENGLISH).Distinct().ToList();
            //---
            _pronoun_deutsch = GetPronoun(DEUTSCH).Distinct().ToList();
            _sentence_deutsch = GetSentence(DEUTSCH).Distinct().ToList();
            _digit_deutsch = GetDigit(DEUTSCH).Distinct().ToList();
            _article_deutsch = GetArticle(DEUTSCH).Distinct().ToList();
            _preposition_deutsch = GetPreposition(DEUTSCH).Distinct().ToList();
            //---
            _pronoun_italiano = GetPronoun(ITALIANO).Distinct().ToList();
            _sentence_italiano = GetSentence(ITALIANO).Distinct().ToList();
            _digit_italiano = GetDigit(ITALIANO).Distinct().ToList();
            _article_italiano = GetArticle(ITALIANO).Distinct().ToList();
            _preposition_italiano = GetPreposition(ITALIANO).Distinct().ToList();
            //---
            _pronoun_francais = GetPronoun(FRANCAIS).Distinct().ToList();
            _sentence_francais = GetSentence(FRANCAIS).Distinct().ToList();
            _digit_francais = GetDigit(FRANCAIS).Distinct().ToList();
            _article_francais = GetArticle(FRANCAIS).Distinct().ToList();
            _preposition_francais = GetPreposition(FRANCAIS).Distinct().ToList();
            //---
            _pronoun_espanol = GetPronoun(ESPANOL).Distinct().ToList();
            _sentence_espanol = GetSentence(ESPANOL).Distinct().ToList();
            _digit_espanol = GetDigit(ESPANOL).Distinct().ToList();
            _article_espanol = GetArticle(ESPANOL).Distinct().ToList();
            _preposition_espanol = GetPreposition(ESPANOL).Distinct().ToList();
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

        private List<EstoutroModel> SelectAdjective(string language)
        {
            try
            {
                if (language == ENGLISH) return _adjective_english;
                if (language == DEUTSCH) return _adjective_deutsch;
                if (language == ITALIANO) return _adjective_italiano;
                if (language == FRANCAIS) return _adjective_francais;
                if (language == ESPANOL) return _adjective_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<PreceitoModel> SelectArticle(string language)
        {
            try
            {
                if (language == ENGLISH) return _article_english;
                if (language == DEUTSCH) return _article_deutsch;
                if (language == ITALIANO) return _article_italiano;
                if (language == FRANCAIS) return _article_francais;
                if (language == ESPANOL) return _article_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<AlgarismoModel> SelectDigit(string language)
        {
            try
            {
                if (language == ENGLISH) return _digit_english;
                if (language == DEUTSCH) return _digit_deutsch;
                if (language == ITALIANO) return _digit_italiano;
                if (language == FRANCAIS) return _digit_francais;
                if (language == ESPANOL) return _digit_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<JuncaoModel> SelectPreposition(string language)
        {
            try
            {
                if (language == ENGLISH) return _preposition_english;
                if (language == DEUTSCH) return _preposition_deutsch;
                if (language == ITALIANO) return _preposition_italiano;
                if (language == FRANCAIS) return _preposition_francais;
                if (language == ESPANOL) return _preposition_espanol;
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

        public List<PreceitoModel> GetArticle(string language)
        {
            try
            {
                return _articlesViewModel.GetLanguage(language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlgarismoModel> GetDigit(string language)
        {
            try
            {
                return _digitsViewModel.GetLanguage(language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JuncaoModel> GetPreposition(string language)
        {
            try
            {
                return _prepositionsViewModel.GetLanguage(language);
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

        private List<WordModel> Word(string term, string type, string sentence, string model)
        {
            try
            {
                //---
                List<WordModel> word_model = new List<WordModel>();
                //---
                WordModel word = new WordModel();
                term = RemoveAccent(term.ToLower());
                word.term = term;
                word.kind = type;
                if (sentence != null) word.sentense = sentence;
                if (model != null)
                {
                    model = RemoveAccent(model.ToLower());
                    word.model = model;
                }
                word_model.Add(word);
                //---
                return word_model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<WordModel> ArticleNoun(string noun, string article)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = new List<WordModel>();
                iten_word = Word(article, VAR_ARTICLE, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(noun, VAR_NOUN, null, null);
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

        private List<WordModel> DigitNoun(string noun, string digit)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = new List<WordModel>();
                iten_word = Word(digit, VAR_DIGIT, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(noun, VAR_NOUN, null, null);
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

        private List<WordModel> AdjectiveNoun(string noun, string adjective)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adjective, VAR_PRONOUN, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(noun, VAR_NOUN, null, null);
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
                            //---
                            string value = RemoveAccent(noun.ToString());
                            list_noun.Add(value);
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

        private List<LicaoModel> SetNounArticle(string language, List<string> noun)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                List<PreceitoModel> articles = SelectArticle(language).Distinct().ToList();
                //---
                articles = FilterArticle(language, articles).ToList();
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    articles.ForEach(preceito =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> iten_word = new List<WordModel>();
                        iten_word = ArticleNoun(substantive, preceito.nome);
                        iten_word.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_iten = new LicaoModel();
                        lesson_iten.lecture = new_word;
                        lesson.Add(lesson_iten);
                    });
                });
                //---
                return lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> SetNounPronoun(string language, List<string> noun)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_ADJECTIVE);
                List<EstoutroModel> pronoun = SetPronoun(language, type_pronoun);
                //---
                pronoun = FilterPronoun(language, pronoun);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    pronoun.ForEach(estoutro =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> iten_word = new List<WordModel>();
                        iten_word = AdjectiveNoun(substantive, estoutro.nome);
                        iten_word.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_iten = new LicaoModel();
                        lesson_iten.lecture = new_word;
                        lesson.Add(lesson_iten);
                    });
                });
                //---
                return lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> SetNounDigit(string language, List<string> noun)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                List<AlgarismoModel> digit = SelectDigit(language).Distinct().ToList();
                //---
                digit = FilterDigit(language, digit);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    digit.ForEach(algarismo =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> iten_word = new List<WordModel>();
                        iten_word = DigitNoun(substantive, algarismo.nome);
                        iten_word.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_iten = new LicaoModel();
                        lesson_iten.lecture = new_word;
                        lesson.Add(lesson_iten);
                    });
                });
                //---
                return lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<EstoutroModel> SetPronoun(string language, List<string> type)
        {
            try
            {
                //---
                List<EstoutroModel> list_pronoun = new List<EstoutroModel>();
                List<EstoutroModel> pronouns = SelectPronoun(language).Distinct().ToList();
                //---
                List<EstoutroModel> single_pronoun = new List<EstoutroModel>();
                pronouns = FilterType(pronouns, type);
                //---
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

        private List<EstoutroModel> FilterType(List<EstoutroModel> pronouns, List<string> type)
        {
            try
            {
                //---
                List<EstoutroModel> list_pronoun = new List<EstoutroModel>();
                //---
                for (int quantity = 0; quantity < pronouns.Count() - 1; quantity++)
                {
                    type.ForEach(index =>
                    {
                        if (pronouns[quantity].tipo.Contains(index)) 
                            list_pronoun.Add(pronouns[quantity]);
                    });
                }
                //---
                return list_pronoun;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<ElocucaoModel> FilterVerb(string language, List<ElocucaoModel> verb)
        {
            try
            {
                //---
                List<ElocucaoModel> verb_word = new List<ElocucaoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                verb.ForEach(elocucao =>
                {
                    //---
                    item = RemoveAccent(elocucao.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        verb_word.Add(elocucao);
                    }
                });
                //---
                return verb_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<EstoutroModel> FilterPronoun(string language, List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                List<EstoutroModel> pronoun_word = new List<EstoutroModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                pronoun.ForEach(estoutro =>
                {
                    //---
                    item = RemoveAccent(estoutro.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        pronoun_word.Add(estoutro);
                    }
                });
                //---
                return pronoun_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<string> FilterNoun(string language, List<string> noun)
        {
            try
            {
                //---
                List<string> noun_word = new List<string>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                noun.ForEach(substantive =>
                {
                    //---
                    item = RemoveAccent(substantive.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        noun_word.Add(substantive);
                    }
                });
                //---
                return noun_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<JuncaoModel> FilterPreposition(string language, List<JuncaoModel> preposition)
        {
            try
            {
                //---
                List<JuncaoModel> preposition_word = new List<JuncaoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                preposition.ForEach(preceito =>
                {
                    //---
                    item = RemoveAccent(preceito.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        preposition_word.Add(preceito);
                    }
                });
                //---
                return preposition_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<PreceitoModel> FilterArticle(string language, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<PreceitoModel> article_word = new List<PreceitoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                article.ForEach(preceito =>
                {
                    //---
                    item = RemoveAccent(preceito.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        article_word.Add(preceito);
                    }
                });
                //---
                return article_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<AlgarismoModel> FilterDigit(string language, List<AlgarismoModel> digit)
        {
            try
            {
                //---
                List<AlgarismoModel> digit_word = new List<AlgarismoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string item = null;
                digit.ForEach(algarismo =>
                {
                    //---
                    item = RemoveAccent(algarismo.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        digit_word.Add(algarismo);
                    }
                });
                //---
                return digit_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> FilterSubject(string language, List<LicaoModel> lesson)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                HashSet<string> vocabulary = Vocabulary(sentences);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                //---
                lesson.ForEach(instruction =>
                {
                    //---
                    List<WordModel> iten_word = new List<WordModel>();
                    //---
                    string word_first = null;
                    string word_last = null;
                    //---
                    instruction.lecture.ForEach(word =>
                    {
                        //---
                        if (word.kind != VAR_NOUN) word_first = word.term;
                        if (word.kind == VAR_NOUN) word_last = word.term;
                        //---
                        iten_word.Add(word);
                    });
                    //---
                    bool similarity = Similarity(word_2_vec, vocabulary, word_first, word_last);
                    //---
                    if (similarity)
                    {
                        LicaoModel lesson_iten = new LicaoModel();
                        lesson_iten.lecture = iten_word;
                        lesson_word.Add(lesson_iten);
                    }
                });
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> UnionNoun(List<LicaoModel> list_first, List<LicaoModel> list_second)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                list_first.ForEach(first =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = first.lecture;
                    lesson_word.Add(item);
                });
                //---
                list_second.ForEach(second =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = second.lecture;
                    lesson_word.Add(item);
                });
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> UnionNoun(List<string> list_string, List<LicaoModel> list_second)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                list_string.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = Word(value, VAR_NOUN, null, null);
                    lesson_word.Add(item);
                });
                //---
                list_second.ForEach(second =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = second.lecture;
                    lesson_word.Add(item);
                });
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> SetLessonPronoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                foreach (ElocucaoModel verb in list_verb)
                {
                    //---
                    List<string> type_pronoun = new List<string>();
                    type_pronoun.Add(VAR_PERSONAL);
                    //---
                    List<EstoutroModel> filter_pronoun = new List<EstoutroModel>();
                    filter_pronoun = SetPronoun(language, type_pronoun);
                    foreach (EstoutroModel pronoun in filter_pronoun)
                    {
                        //---
                        List<WordModel> phrase = new List<WordModel>();
                        List<WordModel> item;
                        //---
                        item = new List<WordModel>();
                        item = Word(pronoun.nome, VAR_PRONOUN, VAR_SUBJECT, null);
                        item.ForEach(value =>
                        {
                            phrase.Add(value);
                        });
                        //---
                        item = new List<WordModel>();
                        item = Word(verb.nome, VAR_VERB, VAR_PREDICATE, verb.modelo);
                        item.ForEach(value =>
                        {
                            phrase.Add(value);
                        });
                        //---
                        bool similarity = Similarity(word_2_vec, vocabulary, pronoun.nome.ToLower(), verb.nome.ToLower());
                        if (!similarity) continue;
                        //---
                        LicaoModel lesson = new LicaoModel();
                        lesson.lecture = phrase;
                        lesson_word.Add(lesson);
                        //---
                        list_noun.ForEach(noun =>
                        {
                            //---
                            List<WordModel> item_noun = new List<WordModel>();
                            phrase.ForEach(value =>
                            {
                                item_noun.Add(value);
                            });
                            //---
                            noun.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                item_noun.Add(word);
                            });
                            //---
                            LicaoModel lesson_two = new LicaoModel();
                            lesson_two.lecture = item_noun;
                            lesson_word.Add(lesson_two);
                            //---
                            list_preposition.ForEach(preceito =>
                            {
                                //---
                                List<WordModel> item_preposition = new List<WordModel>();
                                item_noun.ForEach(value =>
                                {
                                    item_preposition.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                item = Word(preceito.nome, VAR_PREPOSITION, VAR_PREDICATE, null);
                                item.ForEach(value =>
                                {
                                    item_preposition.Add(value);
                                });
                                //---
                                LicaoModel lesson_tree = new LicaoModel();
                                lesson_tree.lecture = item_preposition;
                                lesson_word.Add(lesson_tree);
                            });
                        });
                    }
                }
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<LicaoModel> SetLessonNoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition)
        {
            try
            {
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                List<LicaoModel> list_noun_one = new List<LicaoModel>();
                List<LicaoModel> list_noun_two = new List<LicaoModel>();
                list_noun.ForEach(value =>
                {
                    list_noun_one.Add(value);
                    list_noun_two.Add(value);
                });
                //---
                foreach (ElocucaoModel verb in list_verb)
                {
                    //---
                    foreach (LicaoModel noun in list_noun_one)
                    {
                        //---
                        List<WordModel> phrase = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        item = Word(verb.nome, VAR_VERB, VAR_PREDICATE, verb.modelo);
                        item.ForEach(value =>
                        {
                            phrase.Add(value);
                        });
                        //---
                        string substantive = null;
                        //---
                        noun.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            phrase.Add(word);
                            if (value.kind == VAR_NOUN) substantive = value.term;
                        });
                        //---
                        bool similarity = Similarity(word_2_vec, vocabulary, substantive.ToLower(), verb.nome.ToLower());
                        if (!similarity) continue;
                        //---
                        LicaoModel lesson = new LicaoModel();
                        lesson.lecture = phrase;
                        lesson_word.Add(lesson);
                        //---
                        List<string> type_pronoun = new List<string>();
                        type_pronoun.Add(VAR_POSSESSIVE);
                        //---
                        List<EstoutroModel> filter_pronoun = new List<EstoutroModel>();
                        filter_pronoun = SetPronoun(language, type_pronoun);
                        //---
                        filter_pronoun.ForEach(pronoun =>
                        {
                            //---
                            List<WordModel> item_pronoun = new List<WordModel>();
                            phrase.ForEach(value =>
                            {
                                item_pronoun.Add(value);
                            });
                            //---
                            List<WordModel> item = new List<WordModel>();
                            item = Word(pronoun.nome, VAR_PRONOUN, VAR_PREDICATE, null);
                            item.ForEach(value =>
                            {
                                item_pronoun.Add(value);
                            });
                            //---
                            LicaoModel lesson_two = new LicaoModel();
                            lesson_two.lecture = item_pronoun;
                            lesson_word.Add(lesson_two);
                            //---
                            list_preposition.ForEach(preceito =>
                            {
                                //---
                                List<WordModel> item_preposition = new List<WordModel>();
                                item_pronoun.ForEach(value =>
                                {
                                    item_preposition.Add(value);
                                });
                                //---
                                List<WordModel> item = new List<WordModel>();
                                item = Word(preceito.nome, VAR_PREPOSITION, VAR_PREDICATE, null);
                                item.ForEach(value =>
                                {
                                    item_preposition.Add(value);
                                });
                                //---
                                LicaoModel lesson_tree = new LicaoModel();
                                lesson_tree.lecture = item_preposition;
                                lesson_word.Add(lesson_tree);
                            });
                        });
                        //---
                        list_noun_two.ForEach(noun_two =>
                        {
                            //---
                            List<WordModel> item_noun_two = new List<WordModel>();
                            phrase.ForEach(value =>
                            {
                                item_noun_two.Add(value);
                            });
                            //---
                            noun_two.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                item_noun_two.Add(word);
                            });
                            //---
                            LicaoModel lesson_four = new LicaoModel();
                            lesson_four.lecture = item_noun_two;
                            lesson_word.Add(lesson_four);
                            //---
                            list_preposition.ForEach(preceito =>
                            {
                                //---
                                List<WordModel> item_preposition_two = new List<WordModel>();
                                item_noun_two.ForEach(value =>
                                {
                                    item_preposition_two.Add(value);
                                });
                                //---
                                List<WordModel> item = new List<WordModel>();
                                item = Word(preceito.nome, VAR_PREPOSITION, VAR_PREDICATE, null);
                                item.ForEach(value =>
                                {
                                    item_preposition_two.Add(value);
                                });
                                //---
                                LicaoModel lesson_five = new LicaoModel();
                                lesson_five.lecture = item_preposition_two;
                                lesson_word.Add(lesson_five);
                            });
                        });
                    }
                };
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<WordModel> GetPrevious(string language, FraseModel lesson, List<FraseModel> book)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<string> list_noun = SetNoun(language, lesson, book);
                List<ElocucaoModel> list_verb = SetVerb(language, lesson);
                List<JuncaoModel> list_preposition = SelectPreposition(language);
                List<PreceitoModel> list_article = SelectArticle(language);
                List<AlgarismoModel> list_digit = SelectDigit(language);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_POSSESSIVE);
                List<EstoutroModel> list_pronoun = SetPronoun(language, type_pronoun);
                //---
                list_noun = FilterNoun(language, list_noun);
                list_preposition = FilterPreposition(language, list_preposition);
                list_verb = FilterVerb(language, list_verb);
                //---
                List<LicaoModel> noun_article = SetNounArticle(language, list_noun);
                List<LicaoModel> noun_pronoun = SetNounPronoun(language, list_noun);
                List<LicaoModel> noun_digit = SetNounDigit(language, list_noun);
                //---
                List<LicaoModel> list_substantive = UnionNoun(noun_article, noun_pronoun);
                list_substantive = UnionNoun(list_substantive, noun_digit);
                //---
                List<LicaoModel> filter_subject = FilterSubject(language, list_substantive);
                //---
                List<LicaoModel> list_subject = UnionNoun(list_noun, filter_subject);
                //---
                List<LicaoModel> word_pronoun = SetLessonPronoun(language, list_subject, list_verb, list_preposition);
                List<LicaoModel> word_noun = SetLessonNoun(language, list_subject, list_verb, list_preposition);
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                int order = 0;
                //---
                word_pronoun.ForEach(value =>
                {
                    //---
                    order++;
                    LicaoModel item = new LicaoModel();
                    item.order = order;
                    item.lecture = value.lecture;
                    //---
                    lesson_word.Add(item);
                });
                //---
                word_noun.ForEach(value =>
                {
                    //---
                    order++;
                    LicaoModel item = new LicaoModel();
                    item.order = order;
                    item.lecture = value.lecture;
                    //---
                    lesson_word.Add(value);
                });
                //---
                SetLesson(language, lesson_word);
                //---
                foreach (LicaoModel phrase in lesson_word)
                {
                    //---
                    new_word = Authenticate(language, phrase.lecture);
                    if (new_word.Count() > 0) break;
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

        public List<WordModel> GetUp(string language, List<WordModel> word_model, bool reverse)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<LicaoModel> lesson_word = SelectLesson(language).OrderBy(index => index.order).ToList();
                //---
                if (reverse) lesson_word.Reverse();
                //---
                bool next = false;
                int count_foreach = 0;
                foreach (LicaoModel lesson in lesson_word)
                {
                    //---
                    if (!next)
                    {
                        string word = MountPhrase(word_model);
                        string word_lesson = MountPhrase(lesson.lecture);
                        if (word == word_lesson)
                            next = true;
                    }
                    else
                    {
                        new_word = Authenticate(language, lesson.lecture);
                        if (new_word != null) break;
                    }
                    //---
                    count_foreach++;
                    if (lesson_word.Count == count_foreach)
                    {
                        new_word = word_model;
                        break;
                    }
                }
                //---
                if (reverse) lesson_word.Reverse();
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public string MountPhrase(List<WordModel> word_model)
        {
            try
            {
                //---
                string pronoun_subject = null;
                string pronoun_predicate = null;
                string article_subject = null;
                string article_predicate = null;
                string digit_subject = null;
                string digit_predicate = null;
                string noun_subject = null;
                string noun_predicate = null;
                string verb = null;
                string model = null;
                string preposition = null;
                //---
                word_model.ForEach(word =>
                {
                    //---
                    if ((word.sentense == VAR_SUBJECT) && (word.kind == VAR_PRONOUN)) pronoun_subject = word.term;
                    if ((word.sentense == VAR_SUBJECT) && (word.kind == VAR_DIGIT)) digit_subject = word.term;
                    if ((word.sentense == VAR_SUBJECT) && (word.kind == VAR_ARTICLE)) article_subject = word.term;
                    if ((word.sentense == VAR_SUBJECT) && (word.kind == VAR_NOUN)) noun_subject = word.term;
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_VERB))
                    {
                        verb = word.term;
                        model = word.term;
                    }
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_PREPOSITION)) preposition = word.term;
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_PRONOUN)) pronoun_predicate = word.term;
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_DIGIT)) digit_predicate = word.term;
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_ARTICLE)) article_predicate = word.term;
                    if ((word.sentense == VAR_PREDICATE) && (word.kind == VAR_NOUN)) noun_predicate = word.term;
                });
                //---
                string term = null;
                //---
                if ((pronoun_subject != null) && (noun_subject == null)) term = pronoun_subject + " " + verb;
                if ((noun_subject != null) && (pronoun_subject == null) && (digit_subject == null) && (article_subject == null)) term = noun_subject + " " + verb;
                if ((noun_subject != null) && (digit_subject != null)) term = digit_subject + " " + pronoun_subject + " " + verb;
                if ((noun_subject != null) && (article_subject != null)) term = article_subject + " " + pronoun_subject + " " + verb;
                if (preposition != null) term = term + " " + preposition;
                if ((pronoun_predicate != null) && (noun_predicate == null)) term = term + " " + pronoun_predicate;
                if ((pronoun_predicate != null) && (noun_predicate != null)) term = term + " " + pronoun_predicate + " " + noun_predicate;
                if ((noun_predicate != null) && (pronoun_predicate == null) && (article_predicate == null) && (digit_predicate == null)) term = term + " " + noun_predicate;
                if ((noun_predicate != null) && (article_predicate != null)) term = term + " " + article_predicate + " " + noun_predicate;
                if ((noun_predicate != null) && (digit_predicate != null)) term = term + " " + digit_predicate + " " + noun_predicate;
                //---
                return term;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        private List<WordModel> Authenticate(string language, List<WordModel> lesson)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<DitadoModel> sentences = SelectSentence(language).Distinct().ToList();
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentences);
                HashSet<string> vocabulary = Vocabulary(sentences);
                //---
                string pronoun_subject = null;
                string pronoun_predicate = null;
                string article_subject = null;
                string article_predicate = null;
                string digit_subject = null;
                string digit_predicate = null;
                string noun_subject = null;
                string noun_predicate = null;
                string verb = null;
                string model = null;
                string preposition = null;
                foreach (WordModel word in lesson)
                {
                    if ((word.kind == VAR_PRONOUN) && (word.sentense == VAR_SUBJECT)) pronoun_subject = word.term;
                    if ((word.kind == VAR_ARTICLE) && (word.sentense == VAR_SUBJECT)) article_subject = word.term;
                    if ((word.kind == VAR_DIGIT) && (word.sentense == VAR_SUBJECT)) digit_subject = word.term;
                    if ((word.kind == VAR_NOUN) && (word.sentense == VAR_SUBJECT)) noun_subject = word.term;
                    if (word.kind == VAR_VERB)
                    {
                        verb = word.term;
                        model = word.model;
                    }
                    if ((word.kind == VAR_PREPOSITION) && (word.sentense == VAR_PREDICATE)) preposition = word.term;
                    if ((word.kind == VAR_PRONOUN) && (word.sentense == VAR_PREDICATE)) pronoun_predicate = word.term;
                    if ((word.kind == VAR_DIGIT) && (word.sentense == VAR_PREDICATE)) digit_predicate = word.term;
                    if ((word.kind == VAR_ARTICLE) && (word.sentense == VAR_PREDICATE)) article_predicate = word.term;
                    if ((word.kind == VAR_NOUN) && (word.sentense == VAR_PREDICATE)) noun_predicate = word.term;
                }
                //---
                bool similarity = false;
                if ((pronoun_subject != null) && (noun_subject == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, pronoun_subject, verb);
                }
                if ((noun_subject != null) && (digit_subject == null) && (pronoun_subject == null) && (article_subject == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, noun_subject, verb);
                }
                if ((noun_subject != null) && (digit_subject != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, digit_subject, noun_subject);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, noun_subject, verb);
                }
                if ((noun_subject != null) && (pronoun_subject != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, pronoun_subject, noun_subject);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, noun_subject, verb);
                }
                if ((noun_subject != null) && (article_subject != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, article_subject, noun_subject);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, noun_subject, verb);
                }
                //---
                if (!similarity) return new_word;
                else
                {
                    if ((preposition == null) && (pronoun_predicate == null) && (digit_predicate == null) && (article_predicate == null) && (noun_predicate == null))
                    {
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WriteSampleOration(pronoun_subject, noun_subject, article_subject, digit_subject, verb, model);
                        //---
                        item.ForEach(index => 
                        {
                            new_word.Add(index);
                        });
                        //---
                        return new_word;
                    }
                }
                //---
                if ((pronoun_predicate != null) && (noun_predicate == null) && (preposition == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, pronoun_predicate);
                }
                //---
                if ((pronoun_predicate != null) && (noun_predicate == null) && (preposition != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, preposition);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, preposition, pronoun_predicate);
                }
                //---
                if ((pronoun_predicate != null) && (noun_predicate != null) && (preposition == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, pronoun_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, pronoun_predicate, noun_predicate);
                }
                //---
                if ((pronoun_predicate != null) && (noun_predicate != null) && (preposition != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, preposition);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, preposition, pronoun_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, pronoun_predicate, noun_predicate);
                }
                //---
                if ((article_predicate != null) && (noun_predicate != null) && (preposition == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, article_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, article_predicate, noun_predicate);
                }
                //---
                if ((article_predicate != null) && (noun_predicate != null) && (preposition != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, preposition);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, preposition, article_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, article_predicate, noun_predicate);
                }
                //---
                if ((digit_predicate != null) && (noun_predicate != null) && (preposition == null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, digit_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, digit_predicate, noun_predicate);
                }
                //---
                if ((digit_predicate != null) && (noun_predicate != null) && (preposition != null))
                {
                    similarity = Similarity(word_2_vec, vocabulary, verb, preposition);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, preposition, digit_predicate);
                    if (similarity) similarity = Similarity(word_2_vec, vocabulary, digit_predicate, noun_predicate);
                }
                //---
                if (similarity)
                {
                    //---
                    List<WordModel> item_two = new List<WordModel>();
                    item_two = WritePredicateOration(pronoun_predicate, noun_predicate, article_predicate, digit_predicate, preposition);
                    item_two.ForEach(index =>
                    {
                        new_word.Add(index);
                    });
                    //---
                    item_two = new List<WordModel>();
                    item_two = WriteSampleOration(pronoun_subject, noun_subject, article_subject, digit_subject, verb, model);
                    //---
                    item_two.ForEach(index =>
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

        private List<WordModel> WriteSampleOration(string pronoun_subject, string noun_subject, string article_subject, string digit_subject, string verb, string model)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                List<WordModel> iten_word = new List<WordModel>();
                //---
                if (pronoun_subject != null) iten_word = Word(pronoun_subject, VAR_PRONOUN, VAR_SUBJECT, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                if (noun_subject != null) iten_word = Word(noun_subject, VAR_NOUN, VAR_SUBJECT, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                if (digit_subject != null) iten_word = Word(digit_subject, VAR_DIGIT, VAR_SUBJECT, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                if (article_subject != null) iten_word = Word(article_subject, VAR_ARTICLE, VAR_SUBJECT, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                if (verb != null) iten_word = Word(verb, VAR_VERB, VAR_PREDICATE, model);
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

        private List<WordModel> WritePredicateOration(string pronoun_predicate, string noun_predicate, string article_predicate, string digit_predicate, string preposition)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                List<WordModel> item_word = new List<WordModel>();
                //---
                if (pronoun_predicate != null) item_word = Word(pronoun_predicate, VAR_PRONOUN, VAR_PREDICATE, null);
                item_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                item_word = new List<WordModel>();
                if (article_predicate != null) item_word = Word(article_predicate, VAR_ARTICLE, VAR_PREDICATE, null);
                item_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                item_word = new List<WordModel>();
                if (digit_predicate != null) item_word = Word(digit_predicate, VAR_DIGIT, VAR_PREDICATE, null);
                item_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                item_word = new List<WordModel>();
                if (noun_predicate != null) item_word = Word(noun_predicate, VAR_NOUN, VAR_PREDICATE, null);
                item_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                item_word = new List<WordModel>();
                if (preposition != null) item_word = Word(preposition, VAR_PREPOSITION, VAR_PREDICATE, null);
                item_word.ForEach(index =>
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