using Letter.Models;
using Letter.ViewsModels;
using System.Collections.Generic;

interface IMorphology : IPronoun, IAdjective, IVerb, IArticle, IPreposition, IDigit, IAdverb, INoun
{
    //---
    public List<WordModel> Word(string term, string type, string sentence, string model);
    public List<WordModel> WordVerbAdverb(string verb, string adverb);
    public List<WordModel> WordDigitNoun(string noun, string digit);
    public List<WordModel> WordPronounNoun(string noun, string pronoun);
    public List<WordModel> WordArticleNoun(string noun, string article);
    public List<WordModel> WordAdjectiveNoun(string noun, string adjective);
    public List<WordModel> WordAdjectiveNoun(string noun, string adjective, string adverb);
    public List<WordModel> WordAdjectiveNounArticle(string noun, string adjective, string adverb, string article);
    public List<WordModel> WordAdjectiveNounArticle(string noun, string adjective, string article);
    public List<WordModel> WordAdjectiveAdverb(string adjective, string adverb);
    public List<WordModel> WordAdverbAdverb(string adverb_main, string adverb);
    //---
    public List<DitadoModel> SelectSentence(string language);
    //---
    public List<DitadoModel> GetSentence(string language);
    //---
    public List<LicaoModel> UnionMorphology(List<LicaoModel> list_fist, List<LicaoModel> list_last);
    //---
    public List<LicaoModel> FilterTypeMorphology(List<LicaoModel> lesson, List<string> type);
    //---
    public List<WordModel> Authenticate(string language, List<WordModel> lesson);
}