using Letter.Helpers;
using Letter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static Android.Provider.UserDictionary;
using static Android.Renderscripts.Sampler;

namespace Letter.ViewsModels
{
    public class GrammarViewModel : WordEmbedding, IMorphology, ISyntax
    {
        //---
        protected string VAR_SUBJECT = "sujeito";
        protected string VAR_PREDICATE = "predicado";
        protected string VAR_PRONOUN = "pronome";
        protected string VAR_NOUN = "substantivo";
        protected string VAR_VERB = "verbo";
        protected string VAR_PERSONAL = "pessoal";
        protected string VAR_ADJECTIVE = "adjetivo";
        protected string VAR_ARTICLE = "article";
        protected string VAR_DIGIT = "numeral";
        protected string VAR_PREPOSITION = "preposicao";
        protected string VAR_POSSESSIVE = "possessivo";
        protected string VAR_DEMONSTRATIVE = "demonstrativo";
        protected string VAR_ADVERB = "adverbio";
        protected string VAR_ADVERB_ADVERB = "adverbio adverbio";
        protected string VAR_ADJECTIVE_NOUN = "adjetivo substantivo";
        //---
        public static readonly SentenceViewModel _sentencesViewModel = new SentenceViewModel();
        public static readonly DigitViewModel _digitsViewModel = new DigitViewModel();
        public static readonly ArticleViewModel _articlesViewModel = new ArticleViewModel();
        public static readonly PronounViewModel _pronounsViewModel = new PronounViewModel();
        public static readonly PrepositionViewModel _prepositionsViewModel = new PrepositionViewModel();
        public static readonly VerbViewModel _verbsViewModel = new VerbViewModel();
        public static readonly AdverbViewModel _adverbsViewModel = new AdverbViewModel();
        //---
        protected List<DitadoModel> _sentence_english = new List<DitadoModel>();
        protected List<DitadoModel> _sentence_deutsch = new List<DitadoModel>();
        protected List<DitadoModel> _sentence_italiano = new List<DitadoModel>();
        protected List<DitadoModel> _sentence_francais = new List<DitadoModel>();
        protected List<DitadoModel> _sentence_espanol = new List<DitadoModel>();
        //---
        protected List<AlgarismoModel> _digit_english = new List<AlgarismoModel>();
        protected List<AlgarismoModel> _digit_deutsch = new List<AlgarismoModel>();
        protected List<AlgarismoModel> _digit_italiano = new List<AlgarismoModel>();
        protected List<AlgarismoModel> _digit_francais = new List<AlgarismoModel>();
        protected List<AlgarismoModel> _digit_espanol = new List<AlgarismoModel>();
        //---
        protected List<PreceitoModel> _article_english = new List<PreceitoModel>();
        protected List<PreceitoModel> _article_deutsch = new List<PreceitoModel>();
        protected List<PreceitoModel> _article_italiano = new List<PreceitoModel>();
        protected List<PreceitoModel> _article_francais = new List<PreceitoModel>();
        protected List<PreceitoModel> _article_espanol = new List<PreceitoModel>();
        //---
        protected List<EstoutroModel> _pronoun_english = new List<EstoutroModel>();
        protected List<EstoutroModel> _pronoun_deutsch = new List<EstoutroModel>();
        protected List<EstoutroModel> _pronoun_italiano = new List<EstoutroModel>();
        protected List<EstoutroModel> _pronoun_francais = new List<EstoutroModel>();
        protected List<EstoutroModel> _pronoun_espanol = new List<EstoutroModel>();
        //---
        protected List<JuncaoModel> _preposition_english = new List<JuncaoModel>();
        protected List<JuncaoModel> _preposition_deutsch = new List<JuncaoModel>();
        protected List<JuncaoModel> _preposition_italiano = new List<JuncaoModel>();
        protected List<JuncaoModel> _preposition_francais = new List<JuncaoModel>();
        protected List<JuncaoModel> _preposition_espanol = new List<JuncaoModel>();
        //---
        protected List<CircunstanciaModel> _adverb_english = new List<CircunstanciaModel>();
        protected List<CircunstanciaModel> _adverb_deutsch = new List<CircunstanciaModel>();
        protected List<CircunstanciaModel> _adverb_italiano = new List<CircunstanciaModel>();
        protected List<CircunstanciaModel> _adverb_francais = new List<CircunstanciaModel>();
        protected List<CircunstanciaModel> _adverb_espanol = new List<CircunstanciaModel>();
        //---
        protected List<ElocucaoModel> _verb_english = new List<ElocucaoModel>();
        protected List<ElocucaoModel> _verb_deutsch = new List<ElocucaoModel>();
        protected List<ElocucaoModel> _verb_italiano = new List<ElocucaoModel>();
        protected List<ElocucaoModel> _verb_francais = new List<ElocucaoModel>();
        protected List<ElocucaoModel> _verb_espanol = new List<ElocucaoModel>();
        //---
        protected string ENGLISH = "english";
        protected string DEUTSCH = "deutsch";
        protected string ITALIANO = "italiano";
        protected string FRANCAIS = "français";
        protected string ESPANOL = "espanõl";

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

        public List<ElocucaoModel> GetVerb(string language)
        {
            try
            {
                return _verbsViewModel.GetLanguage(language);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CircunstanciaModel> GetAdverb(string language)
        {
            try
            {
                return _adverbsViewModel.GetLanguage(language);
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

        public List<DitadoModel> SelectSentence(string language)
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

        public List<AlgarismoModel> SelectDigit(string language)
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

        public List<PreceitoModel> SelectArticle(string language)
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

        public List<JuncaoModel> SelectPreposition(string language)
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

        public List<EstoutroModel> SelectPronoun(string language)
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

        public List<CircunstanciaModel> SelectAdverb(string language)
        {
            try
            {
                if (language == ENGLISH) return _adverb_english;
                if (language == DEUTSCH) return _adverb_deutsch;
                if (language == ITALIANO) return _adverb_italiano;
                if (language == FRANCAIS) return _adverb_francais;
                if (language == ESPANOL) return _adverb_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ElocucaoModel> SelectVerb(string language)
        {
            try
            {
                if (language == ENGLISH) return _verb_english;
                if (language == DEUTSCH) return _verb_deutsch;
                if (language == ITALIANO) return _verb_italiano;
                if (language == FRANCAIS) return _verb_francais;
                if (language == ESPANOL) return _verb_espanol;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WordModel> Word(string term, string type, string sentence, string model)
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

        public List<WordModel> WordArticleNoun(string noun, string article)
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

        public List<WordModel> WordDigitNoun(string noun, string digit)
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

        public List<WordModel> WordPronounNoun(string noun, string pronoun)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(pronoun, VAR_PRONOUN, null, null);
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

        public List<WordModel> WordAdjectiveNoun(string noun, string adjective)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adjective, VAR_ADJECTIVE, null, null);
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

        public List<WordModel> WordAdjectiveNoun(string noun, string adjective, string adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb, VAR_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = WordArticleNoun(noun, adjective);
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

        public List<WordModel> WordAdjectiveNounArticle(string noun, string adjective, string article)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(article, VAR_ARTICLE, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = WordArticleNoun(noun, adjective);
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

        public List<WordModel> WordAdjectiveNounArticle(string noun, string adjective, string adverb, string article)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb, VAR_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = WordAdjectiveNounArticle(noun, adjective, article);
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

        public List<WordModel> WordVerbAdverb(string verb, string adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(verb, VAR_VERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(adverb, VAR_ADVERB, null, null);
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

        public List<WordModel> WordVerbAdverb(string verb, string adverb, string adverb_adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb_adverb, VAR_ADVERB_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = WordVerbAdverb(verb, adverb);
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

        public List<WordModel> WordAdjectiveAdverb(string adjective, string adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb, VAR_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(adjective, VAR_ADJECTIVE, null, null);
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

        public List<WordModel> WordAdjectiveAdverb(string adjective, string adverb, string adverb_adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb_adverb, VAR_ADVERB_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = WordAdjectiveAdverb(adjective, adverb);
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

        public List<WordModel> WordAdverbAdverb(string adverb_main, string adverb)
        {
            try
            {
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<WordModel> iten_word = new List<WordModel>();
                iten_word = Word(adverb, VAR_ADVERB_ADVERB, null, null);
                iten_word.ForEach(index =>
                {
                    new_word.Add(index);
                });
                //---
                iten_word = new List<WordModel>();
                iten_word = Word(adverb_main, VAR_ADVERB, null, null);
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

        public List<LicaoModel> UnionNoun(List<LicaoModel> list_first, List<LicaoModel> list_second)
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

        public List<LicaoModel> UnionNoun(List<string> list_string, List<LicaoModel> list_second)
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

        public List<LicaoModel> UnionVerb(List<ElocucaoModel> verb, List<LicaoModel> verb_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                verb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = Word(value.nome, VAR_VERB, null, null);
                    lesson_word.Add(item);
                });
                //---
                verb_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
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

        public List<LicaoModel> UnionVerb(List<LicaoModel> verb_adverb, List<LicaoModel> verb_adverb_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                verb_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
                    lesson_word.Add(item);
                });
                //---
                verb_adverb_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
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

        public List<LicaoModel> UnionAdjective(List<string> adjective, List<LicaoModel> adjective_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                adjective.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = Word(value, VAR_ADJECTIVE, null, null);
                    lesson_word.Add(item);
                });
                //---
                adjective_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
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

        public List<LicaoModel> UnionAdjective(List<LicaoModel> adjective_adverb, List<LicaoModel> adjective_adverb_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                adjective_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
                    lesson_word.Add(item);
                });
                //---
                adjective_adverb_adverb.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
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

        public List<LicaoModel> UnionMorphology(List<LicaoModel> list_fist, List<LicaoModel> list_last)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                list_fist.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
                    item.team = value.team;
                    lesson_word.Add(item);
                });
                //---
                list_last.ForEach(value =>
                {
                    //---
                    LicaoModel item = new LicaoModel();
                    item.lecture = value.lecture;
                    item.team = value.team;
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

        public List<EstoutroModel> SetSortPronoun(List<EstoutroModel> pronoun)
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

        public HashSet<string> MountArticle(List<PreceitoModel> article)
        {
            try
            {
                //---
                HashSet<string> precept = new HashSet<string>();
                //---
                article.ForEach(index =>
                {
                    precept.Add(index.nome);
                });
                //---
                return precept;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> MountNoun(string language, FraseModel lesson, List<FraseModel> book)
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
                            if (noun.Trim().Length > 0) 
                            {
                                //---
                                string value = RemoveAccent(noun.ToString());
                                list_noun.Add(value);
                            }
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

        public List<LicaoModel> MountNounDigit(List<string> noun, List<AlgarismoModel> digit, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                HashSet<string> precept = new HashSet<string>();
                //---
                precept = MountArticle(article);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    digit.ForEach(number =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        HashSet<string> word = new HashSet<string>(substantive.Split(' '));
                        if (word.Count > 1)
                        {
                            //---
                            if (Array.IndexOf(precept.ToArray(), word.First()) != -1)
                                item = WordDigitNoun(word.Last(), number.nome);
                        }
                        else item = WordDigitNoun(word.First(), number.nome);
                        //---
                        item.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<LicaoModel> MountNounArticle(List<string> noun, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                HashSet<string> precept = new HashSet<string>();
                //---
                precept = MountArticle(article);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    article.ForEach(norm =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        HashSet<string> word = new HashSet<string>(substantive.Split(' '));
                        if (word.Count > 1)
                        {
                            //---
                            if (Array.IndexOf(precept.ToArray(), word.First()) != -1)
                                item = WordArticleNoun(word.Last(), word.First());
                        }
                        else item = WordArticleNoun(word.First(), norm.nome);
                        //---
                        item.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<LicaoModel> MountNounPronoun(List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                HashSet<string> precept = new HashSet<string>();
                //---
                precept = MountArticle(article);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    pronoun.ForEach(estoutro =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        HashSet<string> word = new HashSet<string>(substantive.Split(' '));
                        if (word.Count > 1)
                        {
                            //---
                            if (Array.IndexOf(precept.ToArray(), word.First()) != -1) 
                                item = WordPronounNoun(word.Last(), estoutro.nome);
                        }
                        else item = WordPronounNoun(word.First(), estoutro.nome);
                        //---
                        item.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<EstoutroModel> MountPronoun(List<string> type, List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                List<EstoutroModel> list_pronoun = new List<EstoutroModel>();
                //---
                List<EstoutroModel> single_pronoun = new List<EstoutroModel>();
                List<EstoutroModel> type_pronoun = FilterTypePronoun(pronoun, type);
                //---
                type_pronoun.ForEach(estoutro =>
                {
                    estoutro.contento.ForEach(contento =>
                    {
                        if (contento.numero.Contains("singular"))
                            single_pronoun.Add(estoutro);
                    });
                });
                single_pronoun = SetSortPronoun(single_pronoun);
                //---
                List<EstoutroModel> plural_pronoun = new List<EstoutroModel>();
                type_pronoun.ForEach(estoutro =>
                {
                    estoutro.contento.ForEach(contento =>
                    {
                        if (contento.numero.Contains("plural"))
                            plural_pronoun.Add(estoutro);
                    });
                });
                plural_pronoun = SetSortPronoun(plural_pronoun);
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

        public List<ElocucaoModel> MountVerb(string language, FraseModel lesson)
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

        public List<ElocucaoModel> MountVerb(List<string> model, List<ElocucaoModel> verb)
        {
            try
            {
                //---
                List<ElocucaoModel> list_verb = new List<ElocucaoModel>();
                //---
                for (int quantity = 0; quantity < verb.Count() - 1; quantity++)
                {
                    model.ForEach(index =>
                    {
                        string value = verb[quantity].modelo.ToString().ToLower();
                        value = RemoveAccent(value);
                        if (value.Contains(index))
                            list_verb.Add(verb[quantity]);
                    });
                }
                //---
                return list_verb;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> MountModel(FraseModel lesson)
        {
            try
            {
                //---
                List<String> list_model = new List<String>();
                //---
                lesson.conteudo.verbo.ForEach(model => 
                {
                    //---
                    if (model.Trim().Length > 0)
                    {
                        //---
                        string value = RemoveAccent(model.ToString());
                        list_model.Add(value);
                    }
                });
                //---
                list_model.Distinct();
                return list_model;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> MountAdjective(FraseModel lesson, List<FraseModel> book)
        {
            try
            {
                //---
                List<String> list_adjective = new List<String>();

                //---
                foreach (FraseModel lecture in book.OrderBy(index => index.ordem).ToList())
                {
                    //---
                    if (lecture.ordem <= lesson.ordem)
                    {
                        //---
                        lecture.conteudo.adjetivo.ForEach(adjective =>
                        {
                            //---
                            if (adjective.Trim().Length > 0)
                            {
                                //---
                                string value = RemoveAccent(adjective.ToString());
                                list_adjective.Add(value);
                            }
                        });
                    }
                }
                //---
                list_adjective.Distinct();
                return list_adjective;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> MountAdjectivePronoun(List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                HashSet<string> precept = new HashSet<string>();
                //---
                precept = MountArticle(article);
                //---
                noun.ForEach(substantive =>
                {
                    //---
                    pronoun.ForEach(thisother =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        HashSet<string> word = new HashSet<string>(substantive.Split(' '));
                        if (word.Count > 1)
                        {
                            //---
                            if (Array.IndexOf(precept.ToArray(), word.First()) != -1)
                                item = WordPronounNoun(word.Last(), thisother.nome);
                        }
                        else item = WordPronounNoun(word.First(), thisother.nome);
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<LicaoModel> MountVerbAdverb(List<ElocucaoModel> verb, List<CircunstanciaModel> adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                //---
                verb.ForEach(elocution =>
                {
                    //---
                    adverb.ForEach(circumstance =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WordVerbAdverb(elocution.nome, circumstance.nome);
                        item.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<LicaoModel> MountVerbAdverb(List<ElocucaoModel> verb, List<LicaoModel> adverb_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                //---
                verb.ForEach(verb =>
                {
                    //---
                    adverb_adverb.ForEach(circumstance =>
                    {
                        //---
                        List<WordModel> word_model = new List<WordModel>();
                        //---
                        string adverb = null;
                        string adverb_adverb = null;
                        //---
                        circumstance.lecture.ForEach(value =>
                        {
                            //---
                            if (value.kind == VAR_ADVERB) adverb = value.term;
                            if (value.kind == VAR_ADVERB_ADVERB) adverb_adverb = value.term;
                        });
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WordVerbAdverb(verb.nome, adverb, adverb_adverb);
                        item.ForEach(item =>
                        {
                            word_model.Add(item);
                        });
                        //---
                        LicaoModel item_lesson = new LicaoModel();
                        item_lesson.lecture = word_model;
                        lesson.Add(item_lesson);
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

        public List<LicaoModel> MountAdverbAdverb(List<CircunstanciaModel> adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                List<CircunstanciaModel> last_adverb = new List<CircunstanciaModel>();
                //---
                adverb.ForEach(value =>
                {
                    last_adverb.Add(value);
                });
                //---
                adverb.ForEach(first_adverb =>
                {
                    //---
                    last_adverb.ForEach(last_adverb =>
                    {
                        //---
                        List<WordModel> new_word = new List<WordModel>();
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WordAdverbAdverb(first_adverb.nome, last_adverb.nome);
                        item.ForEach(index =>
                        {
                            new_word.Add(index);
                        });
                        //---
                        LicaoModel lesson_item = new LicaoModel();
                        lesson_item.lecture = new_word;
                        lesson.Add(lesson_item);
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

        public List<LicaoModel> MountAdjectiveAdverb(List<string> adjective, List<CircunstanciaModel> adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                //---
                adjective.ForEach(quality =>
                {
                    //---
                    adverb.ForEach(circumstance =>
                    {
                        //---
                        List<WordModel> word_model = new List<WordModel>();
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WordAdjectiveAdverb(quality, circumstance.nome);
                        item.ForEach(item =>
                        {
                            word_model.Add(item);
                        });
                        //---
                        LicaoModel item_lesson = new LicaoModel();
                        item_lesson.lecture = word_model;
                        lesson.Add(item_lesson);
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

        public List<LicaoModel> MountAdjectiveAdverb(List<string> adjective, List<LicaoModel> adverb_adverb)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                //---
                adjective.ForEach(quality =>
                {
                    //---
                    adverb_adverb.ForEach(circumstance =>
                    {
                        //---
                        List<WordModel> word_model = new List<WordModel>();
                        //---
                        string adverb = null;
                        string adverb_adverb = null;
                        //---
                        circumstance.lecture.ForEach(value =>
                        {
                            //---
                            if (value.kind == VAR_ADVERB) adverb = value.term;
                            if (value.kind == VAR_ADVERB_ADVERB) adverb_adverb = value.term;
                        });
                        //---
                        List<WordModel> item = new List<WordModel>();
                        item = WordAdjectiveAdverb(quality, adverb, adverb_adverb);
                        item.ForEach(item =>
                        {
                            word_model.Add(item);
                        });
                        //---
                        LicaoModel item_lesson = new LicaoModel();
                        item_lesson.lecture = word_model;
                        lesson.Add(item_lesson);
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

        public List<LicaoModel> MountAdjectiveNoun(List<string> noun, List<LicaoModel> adjective_adverb, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<LicaoModel> lesson = new List<LicaoModel>();
                HashSet<string> precept = new HashSet<string>();
                //---
                precept = MountArticle(article);
                //---
                noun.ForEach(value_noun =>
                {
                    //---
                    adjective_adverb.ForEach(value_adjective_adverb =>
                    {
                        //---
                        List<WordModel> word_model = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        HashSet<string> word = new HashSet<string>(value_noun.Split(' '));
                        if (word.Count > 1)
                        {
                            //---
                            if (Array.IndexOf(precept.ToArray(), word.First()) != -1)
                            {
                                //---
                                string item_adjective = null;
                                string item_adverb = null;
                                value_adjective_adverb.lecture.ForEach(value_lecture =>
                                {
                                    if (value_lecture.kind == VAR_ADJECTIVE) item_adjective = value_lecture.term;
                                    if (value_lecture.kind == VAR_ADVERB) item_adverb = value_lecture.term;
                                });
                                //---
                                if (item_adverb != null) item = WordAdjectiveNounArticle(word.Last(), item_adjective, item_adverb, word.First());
                                else item = WordAdjectiveNounArticle(word.Last(), item_adjective, word.First());
                            }
                        }
                        else 
                        {
                            //---
                            string item_adjective = null;
                            string item_adverb = null;
                            value_adjective_adverb.lecture.ForEach(value_lecture =>
                            {
                                if (value_lecture.kind == VAR_ADJECTIVE) item_adjective = value_lecture.term;
                                if (value_lecture.kind == VAR_ADVERB) item_adverb = value_lecture.term;
                            });
                            //---
                            if (item_adverb != null) item = WordAdjectiveNoun(word.First(), item_adjective, item_adverb);
                            else item = WordAdjectiveNoun(word.First(), item_adjective);
                        } 
                        //---
                        item.ForEach(item =>
                        {
                            word_model.Add(item);
                        });
                        //---
                        LicaoModel item_lesson = new LicaoModel();
                        item_lesson.lecture = word_model;
                        lesson.Add(item_lesson);
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

        public List<LicaoModel> MountMorphologyNoun(List<DitadoModel> sentence, List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article, List<AlgarismoModel> digit)
        {
            try
            {
                //---
                List<string> filter_noun = FilterList(noun, sentence);
                List<PreceitoModel> filter_article = FilterArticle(article, sentence);
                List<AlgarismoModel> filter_digit = FilterDigit(digit, sentence);
                //---
                List<string> type_adjective = new List<string>();
                List<string> type_demostrative = new List<string>();
                //---
                type_adjective.Add(VAR_ADJECTIVE);
                List<EstoutroModel> list_pronoun_adjective = MountPronoun(type_adjective, pronoun);
                //---
                type_demostrative.Add(VAR_DEMONSTRATIVE);
                List<EstoutroModel> list_pronoun_demostrative = MountPronoun(type_demostrative, pronoun);
                //---
                List<EstoutroModel> filter_pronoun_adjective = FilterPronoun(list_pronoun_adjective, sentence);
                List<EstoutroModel> filter_pronoun_demostrative = FilterPronoun(list_pronoun_demostrative, sentence);
                //---
                List<LicaoModel> noun_possessive = MountNounPronoun(filter_noun, filter_pronoun_adjective, filter_article);
                List<LicaoModel> noun_demostrative = MountAdjectivePronoun(filter_noun, filter_pronoun_demostrative, filter_article);
                //---
                List<LicaoModel> noun_digit = MountNounDigit(filter_noun, filter_digit, filter_article);
                List<LicaoModel> noun_article = MountNounArticle(filter_noun, filter_article);
                //---
                List<LicaoModel> union_substantive_one = UnionNoun(noun_article, noun_possessive);
                List<LicaoModel> union_substantive_two = UnionNoun(union_substantive_one, noun_digit);
                List<LicaoModel> union_substantive_three = UnionNoun(union_substantive_two, noun_demostrative);
                //---
                List<LicaoModel> verify_noun = VerifyNoun(union_substantive_three, sentence);
                //---
                List<LicaoModel> union_noun = UnionNoun(filter_noun, verify_noun);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                union_noun.ForEach(index =>
                {
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_NOUN;
                    item.lecture = index.lecture;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyAdjectiveNoun(List<DitadoModel> sentence, List<string> adjective, List<CircunstanciaModel> adverb, List<string> noun, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<string> filter_noun = FilterList(noun, sentence);
                List<string> filter_adjective = FilterList(adjective, sentence);
                List<PreceitoModel> filter_article = FilterArticle(article, sentence);
                List<CircunstanciaModel> filter_adverb = FilterAdverb(adverb, sentence);
                //---
                List<LicaoModel> adjective_adverb = MountAdjectiveAdverb(filter_adjective, filter_adverb);
                //---
                List<LicaoModel> adjective_noun = MountAdjectiveNoun(filter_noun, adjective_adverb, filter_article);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                adjective_noun.ForEach(index =>
                {
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_ADJECTIVE_NOUN;
                    item.lecture = index.lecture;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyVerb(List<DitadoModel> sentence, List<string> model, List<ElocucaoModel> verb, List<CircunstanciaModel> adverb)
        {
            try
            {
                //---
                List<ElocucaoModel> list_verb_model = MountVerb(model, verb);
                //---
                List<ElocucaoModel> filter_verb = FilterVerb(list_verb_model, sentence);
                List<CircunstanciaModel> filter_adverb = FilterAdverb(adverb, sentence);
                //---
                List<LicaoModel> verb_adverb = MountVerbAdverb(filter_verb, filter_adverb);
                List<LicaoModel> adverb_adverb = MountAdverbAdverb(filter_adverb);
                //---
                List<LicaoModel> verify_verb_adverb = VerifyVerb(verb_adverb, sentence);
                List<LicaoModel> verify_adverb_adverb = VerifyAdverb(adverb_adverb, sentence);
                //---
                List<LicaoModel> verb_adverb_adverb = MountVerbAdverb(filter_verb, verify_adverb_adverb);
                //---
                List<LicaoModel> union_verb_adverb = UnionVerb(filter_verb, verify_verb_adverb);
                List<LicaoModel> union_verb_adverb_adverb = UnionVerb(union_verb_adverb, verb_adverb_adverb);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                union_verb_adverb_adverb.ForEach(index =>
                {
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_VERB;
                    item.lecture = index.lecture;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyAdjective(List<DitadoModel> sentence, List<string> adjective, List<CircunstanciaModel> adverb)
        {
            try
            {
                //---
                List<string> filter_adjective = FilterList(adjective, sentence);
                List<CircunstanciaModel> filter_adverb = FilterAdverb(adverb, sentence);
                //---
                List<LicaoModel> adjective_adverb = MountAdjectiveAdverb(filter_adjective, filter_adverb);
                List<LicaoModel> adverb_adverb = MountAdverbAdverb(filter_adverb);
                //---
                List<LicaoModel> verify_adjective_adverb = VerifyAdjective(adjective_adverb, sentence);
                List<LicaoModel> verify_adverb_adverb = VerifyAdverb(adverb_adverb, sentence);
                //---
                List<LicaoModel> adjective_adverb_adverb = MountAdjectiveAdverb(filter_adjective, verify_adverb_adverb);
                //---
                List<LicaoModel> union_adjective_adverb = UnionAdjective(filter_adjective, verify_adjective_adverb);
                List<LicaoModel> union_adjective_adverb_adverb = UnionAdjective(union_adjective_adverb, adjective_adverb_adverb);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                union_adjective_adverb_adverb.ForEach(index =>
                {
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_ADJECTIVE;
                    item.lecture = index.lecture;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyArticle(List<DitadoModel> sentence, List<PreceitoModel> article)
        {
            try
            {
                //---
                List<PreceitoModel> filter_article = FilterArticle(article, sentence);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                filter_article.ForEach(index =>
                {
                    List<WordModel> item_article = new List<WordModel>();
                    item_article = Word(index.nome, VAR_ARTICLE, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_ARTICLE;
                    item.lecture = item_article;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyDigit(List<DitadoModel> sentence, List<AlgarismoModel> digit)
        {
            try
            {
                //---
                List<AlgarismoModel> filter_digit = FilterDigit(digit, sentence);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                filter_digit.ForEach(index =>
                {
                    List<WordModel> item_digit = new List<WordModel>();
                    item_digit = Word(index.nome, VAR_DIGIT, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_DIGIT;
                    item.lecture = item_digit;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyPreposition(List<DitadoModel> sentence, List<JuncaoModel> preposition)
        {
            try
            {
                //---
                List<JuncaoModel> filter_preposition = FilterPreposition(preposition, sentence);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                filter_preposition.ForEach(index =>
                {
                    List<WordModel> item_preposition = new List<WordModel>();
                    item_preposition = Word(index.nome, VAR_PREPOSITION, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_PREPOSITION;
                    item.lecture = item_preposition;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountMorphologyPronoun(List<DitadoModel> sentence, List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                //---
                List<string> type_personal = new List<string>();
                List<string> type_possessive = new List<string>();
                List<string> type_demostrative = new List<string>();
                //---
                type_personal.Add(VAR_PERSONAL);
                List<EstoutroModel> list_pronoun_personal = MountPronoun(type_personal, pronoun);
                //---
                type_possessive.Add(VAR_POSSESSIVE);
                List<EstoutroModel> list_pronoun_possessive = MountPronoun(type_possessive, pronoun);
                //---
                type_demostrative.Add(VAR_DEMONSTRATIVE);
                List<EstoutroModel> list_pronoun_demostrative = MountPronoun(type_demostrative, pronoun);
                //---
                List<EstoutroModel> filter_pronoun_personal = FilterPronoun(list_pronoun_personal, sentence);
                List<EstoutroModel> filter_pronoun_possessive = FilterPronoun(list_pronoun_possessive, sentence);
                List<EstoutroModel> filter_pronoun_demostrative = FilterPronoun(list_pronoun_demostrative, sentence);
                //---
                List<LicaoModel> new_syntax = new List<LicaoModel>();
                //---
                filter_pronoun_personal.ForEach(index =>
                {
                    List<WordModel> item_preposition = new List<WordModel>();
                    item_preposition = Word(index.nome, VAR_PRONOUN, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_PERSONAL;
                    item.lecture = item_preposition;
                    new_syntax.Add(item);
                });
                //---
                filter_pronoun_possessive.ForEach(index =>
                {
                    List<WordModel> item_preposition = new List<WordModel>();
                    item_preposition = Word(index.nome, VAR_PRONOUN, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_POSSESSIVE;
                    item.lecture = item_preposition;
                    new_syntax.Add(item);
                });
                //---
                filter_pronoun_demostrative.ForEach(index =>
                {
                    List<WordModel> item_preposition = new List<WordModel>();
                    item_preposition = Word(index.nome, VAR_PRONOUN, null, null);
                    LicaoModel item = new LicaoModel();
                    item.team = VAR_DEMONSTRATIVE;
                    item.lecture = item_preposition;
                    new_syntax.Add(item);
                });
                //---
                return new_syntax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<LicaoModel> MountLessonPronounVerbNoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition, List<DitadoModel> sentence, List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                foreach (ElocucaoModel verb in list_verb)
                {
                    //---
                    foreach (EstoutroModel thisother in pronoun)
                    {
                        //---
                        List<WordModel> phrase = new List<WordModel>();
                        List<WordModel> item;
                        //---
                        item = new List<WordModel>();
                        item = Word(thisother.nome, VAR_PRONOUN, VAR_SUBJECT, null);
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
                        bool similarity = Similarity(word_2_vec, vocabulary, thisother.nome.ToLower(), verb.nome.ToLower());
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

        public List<LicaoModel> MountLessonNounVerbNoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition, List<DitadoModel> sentence, List<EstoutroModel> pronoun)
        {
            try
            {
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
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
                        pronoun.ForEach(thisother =>
                        {
                            //---
                            List<WordModel> item_pronoun = new List<WordModel>();
                            phrase.ForEach(value =>
                            {
                                item_pronoun.Add(value);
                            });
                            //---
                            List<WordModel> item = new List<WordModel>();
                            item = Word(thisother.nome, VAR_PRONOUN, VAR_PREDICATE, null);
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
                }
                ;
                //---
                return lesson_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<AlgarismoModel> FilterDigit(List<AlgarismoModel> digit, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<AlgarismoModel> new_word = new List<AlgarismoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                digit.ForEach(number =>
                {
                    //---
                    item = RemoveAccent(number.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(number);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<string> FilterList(List<string> value, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<string> new_word = new List<string>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                value.ForEach(word =>
                {
                    //---
                    item = RemoveAccent(word.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(word);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<EstoutroModel> FilterTypePronoun(List<EstoutroModel> pronoun, List<string> type)
        {
            try
            {
                //---
                List<EstoutroModel> list_pronoun = new List<EstoutroModel>();
                //---
                for (int quantity = 0; quantity < pronoun.Count() - 1; quantity++)
                {
                    type.ForEach(index =>
                    {
                        if (pronoun[quantity].tipo.Contains(index))
                            list_pronoun.Add(pronoun[quantity]);
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


        public List<LicaoModel> FilterTypeMorphology(List<LicaoModel> lesson, List<string> type)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                for (int quantity = 0; quantity < lesson.Count(); quantity++)
                {
                    type.ForEach(index =>
                    {
                        if (lesson[quantity].team.Contains(index))
                            new_lesson.Add(lesson[quantity]);
                    });
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<ElocucaoModel> FilterVerb(List<ElocucaoModel> verb, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<ElocucaoModel> new_word = new List<ElocucaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                verb.ForEach(utterance =>
                {
                    //---
                    item = RemoveAccent(utterance.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(utterance);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<EstoutroModel> FilterPronoun(List<EstoutroModel> pronoun, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<EstoutroModel> new_word = new List<EstoutroModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                pronoun.ForEach(thisother =>
                {
                    //---
                    item = RemoveAccent(thisother.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(thisother);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<JuncaoModel> FilterPreposition(List<JuncaoModel> preposition, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<JuncaoModel> new_word = new List<JuncaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                preposition.ForEach(union =>
                {
                    //---
                    item = RemoveAccent(union.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(union);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<PreceitoModel> FilterArticle(List<PreceitoModel> article, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<PreceitoModel> new_word = new List<PreceitoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                article.ForEach(precept =>
                {
                    //---
                    item = RemoveAccent(precept.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(precept);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<CircunstanciaModel> FilterAdverb(List<CircunstanciaModel> adverb, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<CircunstanciaModel> new_word = new List<CircunstanciaModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                string item = null;
                adverb.ForEach(circumstance =>
                {
                    //---
                    item = RemoveAccent(circumstance.nome.ToLower());
                    if (Array.IndexOf(vocabulary.ToArray(), item) != -1)
                    {
                        new_word.Add(circumstance);
                    }
                });
                //---
                return new_word;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> VerifyNoun(List<LicaoModel> lesson, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                lesson.ForEach(instruction =>
                {
                    //---
                    List<WordModel> iten_word = new List<WordModel>();
                    //---
                    string word_first = null;
                    string word_middle = null;
                    string word_last = null;
                    bool three = false;
                    //---
                    if (instruction.lecture.Count > 2) three = true; 
                    instruction.lecture.ForEach(word =>
                    {
                        //---
                        if (three)
                        {
                            //---
                            if (word.kind == VAR_ARTICLE) word_first = word.term;
                            if ((word.kind != VAR_NOUN) && (word.kind != VAR_ARTICLE)) word_middle = word.term;
                            if (word.kind == VAR_NOUN) word_last = word.term;
                        } else
                        {
                            if (word.kind != VAR_NOUN) word_first = word.term;
                            if (word.kind == VAR_NOUN) word_last = word.term;
                        }

                        iten_word.Add(word);
                    });
                    //---
                    bool similarity = false;
                    if (three)
                    {
                        similarity = Similarity(word_2_vec, vocabulary, word_first, word_middle);
                        if (similarity)
                        {
                            similarity = Similarity(word_2_vec, vocabulary, word_middle, word_last);
                        }
                    }
                    else
                    {
                        similarity = Similarity(word_2_vec, vocabulary, word_first, word_last);
                    }
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

        public List<LicaoModel> VerifyVerb(List<LicaoModel> verb_adverb, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                verb_adverb.ForEach(instruction =>
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
                        if (word.kind == VAR_VERB) word_first = word.term;
                        if (word.kind != VAR_VERB) word_last = word.term;
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

        public List<LicaoModel> VerifyAdverb(List<LicaoModel> adverb_adverb, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                adverb_adverb.ForEach(instruction =>
                {
                    //---
                    List<WordModel> iten_word = new List<WordModel>();
                    //---
                    string word_adverb = null;
                    string word_adverb_adverb = null;
                    //---
                    instruction.lecture.ForEach(value =>
                    {
                        //---
                        if (value.kind == VAR_ADVERB) word_adverb = value.term;
                        if (value.kind == VAR_ADVERB_ADVERB) word_adverb_adverb = value.term;
                        //---
                        iten_word.Add(value);
                    });
                    //---
                    bool similarity = Similarity(word_2_vec, vocabulary, word_adverb, word_adverb_adverb);
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

        public List<LicaoModel> VerifyAdjective(List<LicaoModel> adjective_adverb, List<DitadoModel> sentence)
        {
            try
            {
                //---
                List<LicaoModel> lesson_word = new List<LicaoModel>();
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                adjective_adverb.ForEach(instruction =>
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
                        if (word.kind == VAR_ADJECTIVE) word_first = word.term;
                        if (word.kind != VAR_ADJECTIVE) word_last = word.term;
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

        public List<LicaoModel> MountOrder(List<LicaoModel> list_first)
        {
            try
            {
                //---
                List<LicaoModel> list_syntax = new List<LicaoModel>();
                int order = 0;
                //---
                list_first.ForEach(value =>
                {
                    //---
                    order++;
                    LicaoModel item = new LicaoModel();
                    item.order = order;
                    item.team = value.team;
                    item.lecture = value.lecture;
                    //---
                    list_syntax.Add(item);
                });
                //---
                return list_syntax;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> MountOrder(List<LicaoModel> list_first, List<LicaoModel> list_last)
        {
            try
            {
                //---
                List<LicaoModel> list_syntax = new List<LicaoModel>();
                int order = 0;
                //---
                list_first.ForEach(value =>
                {
                    //---
                    order = value.order;
                    //---
                    list_syntax.Add(value);
                });
                //---
                list_last.ForEach(value =>
                {
                    //---
                    order++;
                    LicaoModel item = new LicaoModel();
                    item.order = order;
                    item.lecture = value.lecture;
                    item.team = value.team;
                    //---
                    list_syntax.Add(item);
                });
                //---
                return list_syntax;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<WordModel> Authenticate(string language, List<WordModel> lesson)
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
                        item = WordSampleOration(pronoun_subject, noun_subject, article_subject, digit_subject, verb, model);
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
                    item_two = WordPredicateOration(pronoun_predicate, noun_predicate, article_predicate, digit_predicate, preposition);
                    item_two.ForEach(index =>
                    {
                        new_word.Add(index);
                    });
                    //---
                    item_two = new List<WordModel>();
                    item_two = WordSampleOration(pronoun_subject, noun_subject, article_subject, digit_subject, verb, model);
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

        public List<WordModel> WordSampleOration(string pronoun_subject, string noun_subject, string article_subject, string digit_subject, string verb, string model)
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

        public List<WordModel> WordPredicateOration(string pronoun_predicate, string noun_predicate, string article_predicate, string digit_predicate, string preposition)
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

        public List<LicaoModel> PeriodSS_V(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        LicaoModel lesson = new LicaoModel();
                        lesson.lecture = syntax;
                        new_lesson.Add(lesson);
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_possessive = new List<string>();
                type_verb.Add(VAR_POSSESSIVE);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_possessive = new List<LicaoModel>();
                list_possessive = FilterTypeMorphology(period, type_possessive);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel possessive_value in list_possessive)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value => 
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            possessive_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = possessive_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbOD(level_1, sentence, false)) continue;
                            //---
                            LicaoModel lesson = new LicaoModel();
                            lesson.lecture = level_1;
                            new_lesson.Add(lesson);
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_possessive = new List<string>();
                type_verb.Add(VAR_POSSESSIVE);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_possessive = new List<LicaoModel>();
                list_possessive = FilterTypeMorphology(period, type_possessive);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel preposition_value in list_preposition)
                        {
                            //---
                            foreach (LicaoModel possessive_value in list_possessive)
                            {
                                //---
                                List<WordModel> level_1 = new List<WordModel>();
                                syntax.ForEach(value =>
                                {
                                    //---
                                    level_1.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                possessive_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = possessive_value.team;
                                    level_1.Add(word);
                                });
                                //---
                                item = new List<WordModel>();
                                preposition_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = preposition_value.team;
                                    level_1.Add(word);
                                });
                                //---
                                if (!VerifyVerbOI(level_1, sentence)) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_1;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_noun = new List<LicaoModel>();
                list_noun = FilterTypeMorphology(period, type_noun);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel noun_value in list_noun)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            noun_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = noun_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbOD(level_1, sentence, true)) continue;
                            //---
                            LicaoModel lesson = new LicaoModel();
                            lesson.lecture = level_1;
                            new_lesson.Add(lesson);
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_noun = new List<LicaoModel>();
                list_noun = FilterTypeMorphology(period, type_noun);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel preposition_value in list_preposition)
                        {
                            //---
                            foreach (LicaoModel noun_value in list_noun)
                            {
                                //---
                                List<WordModel> level_1 = new List<WordModel>();
                                syntax.ForEach(value =>
                                {
                                    //---
                                    level_1.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                noun_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = noun_value.team;
                                    level_1.Add(word);
                                });
                                //---
                                item = new List<WordModel>();
                                preposition_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = preposition_value.team;
                                    level_1.Add(word);
                                });
                                //---
                                if (!VerifyVerbOI(level_1, sentence)) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_1;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective_noun = new List<string>();
                type_adjective_noun.Add(VAR_ADJECTIVE_NOUN);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective_noun = new List<LicaoModel>();
                list_adjective_noun = FilterTypeMorphology(period, type_adjective_noun);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team; 
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_noun_value in list_adjective_noun)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_noun_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_noun_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbODAA(level_1, sentence)) continue;
                            //---
                            LicaoModel lesson = new LicaoModel();
                            lesson.lecture = level_1;
                            new_lesson.Add(lesson);
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective_noun = new List<string>();
                type_adjective_noun.Add(VAR_ADJECTIVE_NOUN);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective_noun = new List<LicaoModel>();
                list_adjective_noun = FilterTypeMorphology(period, type_adjective_noun);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team; 
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel preposition_value in list_preposition)
                        {
                            //---
                            foreach (LicaoModel adjective_noun_value in list_adjective_noun)
                            {
                                //---
                                List<WordModel> level_1 = new List<WordModel>();
                                syntax.ForEach(value =>
                                {
                                    //---
                                    level_1.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                adjective_noun_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = adjective_noun_value.team; 
                                    level_1.Add(word);
                                });
                                //---
                                item = new List<WordModel>();
                                preposition_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = preposition_value.team;
                                    level_1.Add(word);
                                });
                                //---
                                if (!VerifyVerbOI(level_1, sentence)) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_1;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            LicaoModel lesson = new LicaoModel();
                            lesson.lecture = level_1;
                            new_lesson.Add(lesson);
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_possessive = new List<string>();
                type_possessive.Add(VAR_POSSESSIVE);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_possessive = new List<LicaoModel>();
                list_possessive = FilterTypeMorphology(period, type_possessive);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel possessive_value in list_possessive)
                            {
                                //---
                                List<WordModel> level_2 = new List<WordModel>();
                                level_1.ForEach(value =>
                                {
                                    //---
                                    level_2.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                possessive_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = possessive_value.team;
                                    level_2.Add(word);
                                });
                                //---
                                if (!((VerifyVerbOD(level_2, sentence, false)) || (VerifyAdjectiveOD(level_2, sentence, false)))) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_2;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_possessive = new List<string>();
                type_possessive.Add(VAR_POSSESSIVE);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_possessive = new List<LicaoModel>();
                list_possessive = FilterTypeMorphology(period, type_possessive);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team; 
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel preposition_value in list_preposition)
                            {
                                //---
                                foreach (LicaoModel possessive_value in list_possessive)
                                {
                                    //---
                                    List<WordModel> level_2 = new List<WordModel>();
                                    level_1.ForEach(value =>
                                    {
                                        //---
                                        level_2.Add(value);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    possessive_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = possessive_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    preposition_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = preposition_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    if (!((VerifyVerbOI(level_2, sentence)) || (VerifyAdjectiveOI(level_2, sentence)))) continue;
                                    //---
                                    LicaoModel lesson = new LicaoModel();
                                    lesson.lecture = level_2;
                                    new_lesson.Add(lesson);
                                }
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_noun = new List<LicaoModel>();
                list_noun = FilterTypeMorphology(period, type_noun);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel noun_value in list_noun)
                            {
                                //---
                                List<WordModel> level_2 = new List<WordModel>();
                                level_1.ForEach(value =>
                                {
                                    //---
                                    level_2.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                noun_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = noun_value.team;
                                    level_2.Add(word);
                                });
                                //---
                                if (!((VerifyVerbOD(level_2, sentence, true)) || (VerifyAdjectiveOD(level_2, sentence, true)))) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_2;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_noun = new List<LicaoModel>();
                list_noun = FilterTypeMorphology(period, type_noun);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel prepostion_value in list_preposition)
                            {
                                //---
                                foreach (LicaoModel noun_value in list_noun)
                                {
                                    //---
                                    List<WordModel> level_2 = new List<WordModel>();
                                    level_1.ForEach(value =>
                                    {
                                        //---
                                        level_2.Add(value);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    noun_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = noun_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    prepostion_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = prepostion_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    if (!((VerifyVerbOI(level_2, sentence)) || (VerifyAdjectiveOI(level_2, sentence)))) continue;
                                    //---
                                    LicaoModel lesson = new LicaoModel();
                                    lesson.lecture = level_2;
                                    new_lesson.Add(lesson);
                                }
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_adjective_noun = new List<string>();
                type_adjective_noun.Add(VAR_ADJECTIVE_NOUN);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_adjective_noun = new List<LicaoModel>();
                list_adjective_noun = FilterTypeMorphology(period, type_adjective_noun);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel adjective_noun_value in list_adjective_noun)
                            {
                                //---
                                List<WordModel> level_2 = new List<WordModel>();
                                level_1.ForEach(value =>
                                {
                                    //---
                                    level_2.Add(value);
                                });
                                //---
                                item = new List<WordModel>();
                                adjective_noun_value.lecture.ForEach(value =>
                                {
                                    WordModel word = new WordModel();
                                    word.term = value.term;
                                    word.kind = value.kind;
                                    word.sentense = VAR_PREDICATE;
                                    word.team = adjective_noun_value.team;
                                    level_2.Add(word);
                                });
                                //---
                                if (!((VerifyVerbODAA(level_2, sentence)) || (VerifyAdjectiveODAA(level_2, sentence)))) continue;
                                //---
                                LicaoModel lesson = new LicaoModel();
                                lesson.lecture = level_2;
                                new_lesson.Add(lesson);
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public List<LicaoModel> PeriodSS_V_Adj_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun)
        {
            try
            {
                //---
                List<LicaoModel> new_lesson = new List<LicaoModel>();
                //---
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                HashSet<string> vocabulary = Vocabulary(sentence);
                //---
                List<string> type_verb = new List<string>();
                type_verb.Add(VAR_VERB);
                //---
                List<string> type_noun = new List<string>();
                type_noun.Add(VAR_NOUN);
                //---
                List<string> type_pronoun = new List<string>();
                type_pronoun.Add(VAR_PERSONAL);
                type_pronoun.Add(VAR_DEMONSTRATIVE);
                //---
                List<string> type_adjective = new List<string>();
                type_adjective.Add(VAR_ADJECTIVE);
                //---
                List<string> type_adjective_noun = new List<string>();
                type_adjective_noun.Add(VAR_ADJECTIVE_NOUN);
                //---
                List<string> type_preposition = new List<string>();
                type_preposition.Add(VAR_PREPOSITION);
                //---
                List<LicaoModel> list_verb = new List<LicaoModel>();
                list_verb = FilterTypeMorphology(period, type_verb);
                //---
                List<LicaoModel> list_subject = new List<LicaoModel>();
                if (noun) list_subject = FilterTypeMorphology(period, type_noun);
                else list_subject = FilterTypeMorphology(period, type_pronoun);
                //---
                List<LicaoModel> list_adjective = new List<LicaoModel>();
                list_adjective = FilterTypeMorphology(period, type_adjective);
                //---
                List<LicaoModel> list_adjective_noun = new List<LicaoModel>();
                list_adjective_noun = FilterTypeMorphology(period, type_adjective_noun);
                //---
                List<LicaoModel> list_preposition = new List<LicaoModel>();
                list_preposition = FilterTypeMorphology(period, type_preposition);
                //---
                foreach (LicaoModel verb_value in list_verb)
                {
                    //---
                    foreach (LicaoModel subject_value in list_subject)
                    {
                        //---
                        List<WordModel> syntax = new List<WordModel>();
                        List<WordModel> item = new List<WordModel>();
                        //---
                        verb_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_PREDICATE;
                            word.team = verb_value.team;
                            syntax.Add(word);
                        });
                        //---
                        item = new List<WordModel>();
                        subject_value.lecture.ForEach(value =>
                        {
                            WordModel word = new WordModel();
                            word.term = value.term;
                            word.kind = value.kind;
                            word.sentense = VAR_SUBJECT;
                            word.team = subject_value.team;
                            syntax.Add(word);
                        });
                        //---
                        if (!VerifyVerbSS(syntax, sentence, noun)) continue;
                        //---
                        foreach (LicaoModel adjective_value in list_adjective)
                        {
                            //---
                            List<WordModel> level_1 = new List<WordModel>();
                            syntax.ForEach(value =>
                            {
                                //---
                                level_1.Add(value);
                            });
                            //---
                            item = new List<WordModel>();
                            adjective_value.lecture.ForEach(value =>
                            {
                                WordModel word = new WordModel();
                                word.term = value.term;
                                word.kind = value.kind;
                                word.sentense = VAR_PREDICATE;
                                word.team = adjective_value.team;
                                level_1.Add(word);
                            });
                            //---
                            if (!VerifyVerbPS(level_1, sentence)) continue;
                            //---
                            foreach (LicaoModel prepostion_value in list_preposition)
                            {
                                foreach (LicaoModel adjective_noun_value in list_adjective_noun)
                                {
                                    //---
                                    List<WordModel> level_2 = new List<WordModel>();
                                    level_1.ForEach(value =>
                                    {
                                        //---
                                        level_2.Add(value);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    adjective_noun_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = adjective_noun_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    item = new List<WordModel>();
                                    prepostion_value.lecture.ForEach(value =>
                                    {
                                        WordModel word = new WordModel();
                                        word.term = value.term;
                                        word.kind = value.kind;
                                        word.sentense = VAR_PREDICATE;
                                        word.team = prepostion_value.team;
                                        level_2.Add(word);
                                    });
                                    //---
                                    if (!((VerifyVerbOI(level_2, sentence)) || (VerifyAdjectiveOI(level_2, sentence)))) continue;
                                    //---
                                    LicaoModel lesson = new LicaoModel();
                                    lesson.lecture = level_2;
                                    new_lesson.Add(lesson);
                                }
                            }
                        }
                    }
                }
                //---
                return new_lesson;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool VerifyVerbSS(List<WordModel> list_word, List<DitadoModel> sentence, bool noun)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word = null;
                string verb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if (noun)
                    {
                        if ((value.kind == VAR_NOUN) && (value.sentense == VAR_SUBJECT) && (value.team == VAR_NOUN)) word = value.term;
                    } else
                    {
                        if ((value.kind == VAR_PRONOUN) && (value.sentense == VAR_SUBJECT)) word = value.term;
                    }
                    if (value.kind == VAR_VERB) verb = value.term;
                });
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word, verb);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyVerbOD(List<WordModel> list_word, List<DitadoModel> sentence, bool noun)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_noun = null;
                string word_verb = null;
                string substantive = null;
                string digit = null;
                string article = null;
                string pronoun = null;
                string verb = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if (noun)
                    {
                        if ((value.kind == VAR_NOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) substantive = value.term;
                        if ((value.kind == VAR_DIGIT) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) digit = value.term;
                        if ((value.kind == VAR_ARTICLE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) article = value.term;
                        if ((value.kind == VAR_PRONOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) pronoun = value.term;
                    } else
                    {
                        if ((value.kind == VAR_PRONOUN) && (value.sentense == VAR_PREDICATE)) word_noun = value.term;
                    }
                    if (value.kind == VAR_VERB) verb = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb_adverb = value.term;
                });
                //---
                if (digit != null) word_noun = digit;
                else
                {
                    if (article != null) word_noun = article;
                    else
                    {
                        if (pronoun != null) word_noun = pronoun;
                        else 
                        {
                            if (noun == true) word_noun = substantive;
                        } 
                    }
                }
                //---
                if (adverb_adverb != null) word_verb = adverb_adverb;
                else
                {
                    if (adverb != null) word_verb = adverb;
                    else
                    {
                        if (verb != null) word_verb = verb;
                    }
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_verb, word_noun);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyVerbOI(List<WordModel> list_word, List<DitadoModel> sentence)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_preposition = null;
                string word_verb = null;
                string verb = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if ((value.kind == VAR_PREPOSITION) && (value.sentense == VAR_PREDICATE)) word_preposition = value.term;
                    //---
                    if (value.kind == VAR_VERB) verb = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb_adverb = value.term;
                });
                //---
                if (adverb_adverb != null) word_verb = adverb_adverb;
                else
                {
                    if (adverb != null) word_verb = adverb;
                    else
                    {
                        if (verb != null) word_verb = verb;
                    }
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_verb, word_preposition);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyVerbODAA(List<WordModel> list_word, List<DitadoModel> sentence)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_noun = null;
                string word_verb = null;
                string substantive = null;
                string article = null;
                string adjective = null;
                string verb = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if ((value.kind == VAR_NOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) substantive = value.term;
                    if ((value.kind == VAR_ARTICLE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) article = value.term;
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) adjective = value.term;
                    //---
                    if (value.kind == VAR_VERB) verb = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) adverb_adverb = value.term;
                });
                //---
                if (article != null) word_noun = article;
                else
                {
                    if (adjective != null) word_noun = adjective;
                    else word_noun = substantive;
                }
                //---
                if (adverb_adverb != null) word_verb = adverb_adverb;
                else
                {
                    if (adverb != null) word_verb = adverb;
                    else word_verb = verb;
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_verb, word_noun);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyVerbPS(List<WordModel> list_word, List<DitadoModel> sentence)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_adjective = null;
                string word_verb = null;
                string verb = null;
                string verb_adverb = null;
                string verb_adverb_adverb = null;
                string adjective = null;
                string adjective_adverb = null;
                string adjective_adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adjective = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adjective_adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adjective_adverb_adverb = value.term;
                    //---
                    if (value.kind == VAR_VERB) verb = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) verb_adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_VERB)) verb_adverb_adverb = value.term;
                });
                //---
                if (verb_adverb_adverb != null) word_verb = verb_adverb_adverb;
                else
                {
                    if (verb_adverb != null) word_verb = verb_adverb;
                    else
                    {
                        if (verb != null) word_verb = verb;
                    }
                }
                //---
                if (adjective_adverb_adverb != null) word_adjective = adjective_adverb_adverb;
                else
                {
                    if (adjective_adverb != null) word_adjective = adjective_adverb;
                    else
                    {
                        if (adjective != null) word_adjective = adjective;
                    }
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_verb, word_adjective);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyAdjectiveOD(List<WordModel> list_word, List<DitadoModel> sentence, bool noun)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_noun = null;
                string word_adjective = null;
                string substantive = null;
                string digit = null;
                string article = null;
                string pronoun = null;
                string adjective = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if (noun)
                    {
                        if ((value.kind == VAR_NOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) substantive = value.term;
                        if ((value.kind == VAR_DIGIT) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) digit = value.term;
                        if ((value.kind == VAR_ARTICLE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) article = value.term;
                        if ((value.kind == VAR_PRONOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_NOUN)) pronoun = value.term;
                    }
                    else
                    {
                        if ((value.kind == VAR_PRONOUN) && (value.sentense == VAR_PREDICATE)) word_noun = value.term;
                    }
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adjective = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb_adverb = value.term;
                });
                //---
                if (digit != null) word_noun = digit;
                else
                {
                    if (article != null) word_noun = article;
                    else
                    {
                        if (pronoun != null) word_noun = pronoun;
                        else
                        {
                            if (noun == true) word_noun = substantive;
                        }
                    }
                }
                //---
                if (adverb_adverb != null) word_adjective = adverb_adverb;
                else
                {
                    if (adverb != null) word_adjective = adverb;
                    else
                    {
                        if (adjective != null) word_adjective = adjective;
                    }
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_adjective, word_noun);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyAdjectiveOI(List<WordModel> list_word, List<DitadoModel> sentence)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_preposition = null;
                string word_adjective = null;
                string adjective = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if ((value.kind == VAR_PREPOSITION) && (value.sentense == VAR_PREDICATE)) word_preposition = value.term;
                    //---
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb_adverb = value.term;
                });
                //---
                if (adverb_adverb != null) word_adjective = adverb_adverb;
                else
                {
                    if (adverb != null) word_adjective = adverb;
                    else
                    {
                        if (adjective != null) word_adjective = adjective;
                    }
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_adjective, word_preposition);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool VerifyAdjectiveODAA(List<WordModel> list_word, List<DitadoModel> sentence)
        {
            try
            {
                //---
                HashSet<string> vocabulary = Vocabulary(sentence);
                Dictionary<(string, string), int> word_2_vec = Word2Vec(sentence);
                //---
                string word_noun = null;
                string word_adjective = null;
                string substantive = null;
                string article = null;
                string adjective_noun = null;
                string adjective = null;
                string adverb = null;
                string adverb_adverb = null;
                //---
                list_word.ForEach(value =>
                {
                    //---
                    if ((value.kind == VAR_NOUN) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) substantive = value.term;
                    if ((value.kind == VAR_ARTICLE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) article = value.term;
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE_NOUN)) adjective = value.term;
                    //---
                    if ((value.kind == VAR_ADJECTIVE) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adjective = value.term;
                    if ((value.kind == VAR_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb = value.term;
                    if ((value.kind == VAR_ADVERB_ADVERB) && (value.sentense == VAR_PREDICATE) && (value.team == VAR_ADJECTIVE)) adverb_adverb = value.term;
                });
                //---
                if (article != null) word_noun = article;
                else
                {
                    if (adjective_noun != null) word_noun = adjective_noun;
                    else word_noun = substantive;
                }
                //---
                if (adverb_adverb != null) word_adjective = adverb_adverb;
                else
                {
                    if (adverb != null) word_adjective = adverb;
                    else word_adjective = adjective;
                }
                //---
                bool similarity = false;
                similarity = Similarity(word_2_vec, vocabulary, word_adjective, word_noun);
                if (similarity) return true;
                //---
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}