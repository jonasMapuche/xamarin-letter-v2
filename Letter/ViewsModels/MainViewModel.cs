using Letter.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using static Android.Graphics.ColorSpace;

namespace Letter.ViewsModels
{
    public class MainViewModel : GrammarViewModel
    {
        //---
        public static readonly LetterViewModel _lettersViewModel = new LetterViewModel();
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
            _preposition_english = GetPreposition(ENGLISH).Distinct().ToList();
            _verb_english = GetVerb(ENGLISH).Distinct().ToList();
            _article_english = GetArticle(ENGLISH).Distinct().ToList();
            _adverb_english = GetAdverb(ENGLISH).Distinct().ToList();
            //---
            _pronoun_deutsch = GetPronoun(DEUTSCH).Distinct().ToList();
            _sentence_deutsch = GetSentence(DEUTSCH).Distinct().ToList();
            _digit_deutsch = GetDigit(DEUTSCH).Distinct().ToList();
            _preposition_deutsch = GetPreposition(DEUTSCH).Distinct().ToList();
            _verb_deutsch = GetVerb(DEUTSCH).Distinct().ToList();
            _article_deutsch = GetArticle(DEUTSCH).Distinct().ToList();
            _adverb_deutsch = GetAdverb(DEUTSCH).Distinct().ToList();
            //---
            _pronoun_italiano = GetPronoun(ITALIANO).Distinct().ToList();
            _sentence_italiano = GetSentence(ITALIANO).Distinct().ToList();
            _digit_italiano = GetDigit(ITALIANO).Distinct().ToList();
            _preposition_italiano = GetPreposition(ITALIANO).Distinct().ToList();
            _verb_italiano = GetVerb(ITALIANO).Distinct().ToList();
            _article_italiano = GetArticle(ITALIANO).Distinct().ToList();
            _adverb_italiano = GetAdverb(ITALIANO).Distinct().ToList();
            //---
            _pronoun_francais = GetPronoun(FRANCAIS).Distinct().ToList();
            _sentence_francais = GetSentence(FRANCAIS).Distinct().ToList();
            _digit_francais = GetDigit(FRANCAIS).Distinct().ToList();
            _preposition_francais = GetPreposition(FRANCAIS).Distinct().ToList();
            _verb_francais = GetVerb(FRANCAIS).Distinct().ToList();
            _article_francais = GetArticle(FRANCAIS).Distinct().ToList();
            _adverb_francais = GetAdverb(FRANCAIS).Distinct().ToList();
            //---
            _pronoun_espanol = GetPronoun(ESPANOL).Distinct().ToList();
            _sentence_espanol = GetSentence(ESPANOL).Distinct().ToList();
            _digit_espanol = GetDigit(ESPANOL).Distinct().ToList();
            _preposition_espanol = GetPreposition(ESPANOL).Distinct().ToList();
            _verb_espanol = GetVerb(ESPANOL).Distinct().ToList();
            _article_espanol = GetArticle(ESPANOL).Distinct().ToList();
            _adverb_espanol = GetAdverb(ESPANOL).Distinct().ToList();
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

        public List<WordModel> GetPrevious(string language, FraseModel lesson, List<FraseModel> book)
        {
            try
            {
                //---
                List<DitadoModel> sentence = SelectSentence(language).Distinct().ToList();
                //---
                List<WordModel> new_word = new List<WordModel>();
                //---
                List<string> list_noun = MountNoun(language, lesson, book);
                List<string> list_adjective = MountAdjective(lesson, book);
                List<string> list_model = MountModel(lesson);
                //---
                List<JuncaoModel> list_preposition = SelectPreposition(language);
                List<PreceitoModel> list_article = SelectArticle(language);
                List<AlgarismoModel> list_digit = SelectDigit(language);
                List<CircunstanciaModel> list_adverb = SelectAdverb(language);
                List<ElocucaoModel> list_verb = SelectVerb(language);
                List<EstoutroModel> list_pronoun = SelectPronoun(language).Distinct().ToList();
                //---
                List<LicaoModel> mount_noun = MountMorphologyNoun(sentence, list_noun, list_pronoun, list_article, list_digit);
                List<LicaoModel> mount_verb = MountMorphologyVerb(sentence, list_model, list_verb, list_adverb);
                List<LicaoModel> mount_adjective = MountMorphologyAdjective(sentence, list_adjective, list_adverb);
                List<LicaoModel> mount_adjective_noun = MountMorphologyAdjectiveNoun(sentence, list_adjective, list_adverb, list_noun, list_article);
                List<LicaoModel> mount_adverb = MountMorphologyAdverb(sentence, list_adverb);
                List<LicaoModel> mount_digit = MountMorphologyDigit(sentence, list_digit);
                List<LicaoModel> mount_article = MountMorphologyArticle(sentence, list_article);
                List<LicaoModel> mount_preposition = MountMorphologyPreposition(sentence, list_preposition);
                List<LicaoModel> mount_pronoun = MountMorphologyPronoun(sentence, list_pronoun);
                //---
                List<LicaoModel> list_full = UnionMorphology(mount_noun, mount_verb);
                list_full = UnionMorphology(list_full, mount_adjective);
                list_full = UnionMorphology(list_full, mount_adjective_noun);
                list_full = UnionMorphology(list_full, mount_adverb);
                list_full = UnionMorphology(list_full, mount_digit);
                list_full = UnionMorphology(list_full, mount_article);
                list_full = UnionMorphology(list_full, mount_preposition);
                list_full = UnionMorphology(list_full, mount_pronoun);
                //---
                List<LicaoModel> list_word = new List<LicaoModel>();
                list_word = MountOrder(PeriodP_V(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Pr_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Pr_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_AdjN(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Pr_AdjN(language, sentence, list_full));
                //---
                list_word = MountOrder(list_word, PeriodP_V_Adj(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_Pr_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_Pr_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_AdjN(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adj_Pr_AdjN(language, sentence, list_full));
                //---
                list_word = MountOrder(list_word, PeriodP_V_Adv(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Pr_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Pr_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_AdjN(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Pr_AdjN(language, sentence, list_full));
                //---
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_Pr_P(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_Pr_N(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_AdjN(language, sentence, list_full));
                list_word = MountOrder(list_word, PeriodP_V_Adv_Adj_Pr_AdjN(language, sentence, list_full));
                //---
                //List<LicaoModel> word_noun = MountLessonNounVerbNoun(language, union_noun, filter_verb, filter_preposition, sentence, filter_pronoun_possessive);
                //---
                SetLesson(language, list_word);
                //---
                foreach (LicaoModel phrase in list_word)
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

    }
}