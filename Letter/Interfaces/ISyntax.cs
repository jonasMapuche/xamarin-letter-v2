using Letter.Models;
using System.Collections.Generic;

interface ISyntax
{
    //---
    public List<WordModel> WordSampleOration(string pronoun_subject, string noun_subject, string article_subject, string digit_subject, string verb, string model);
    public List<WordModel> WordPredicateOration(string pronoun_predicate, string noun_predicate, string article_predicate, string digit_predicate, string preposition);
    //---
    public string MountPhrase(List<WordModel> word_model);
    //---
    public List<LicaoModel> MountLessonPronounVerbNoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition, List<DitadoModel> sentence, List<EstoutroModel> pronoun);
    public List<LicaoModel> MountLessonNounVerbNoun(string language, List<LicaoModel> list_noun, List<ElocucaoModel> list_verb, List<JuncaoModel> list_preposition, List<DitadoModel> sentence, List<EstoutroModel> pronoun);
    //---
    public List<LicaoModel> MountOrder(List<LicaoModel> list_first, List<LicaoModel> list_second);
    //---
    public bool VerifyVerbSS(List<WordModel> list_word, List<DitadoModel> sentence, bool noun);
    //---
    public bool VerifyVerbOD(List<WordModel> list_word, List<DitadoModel> sentence, bool noun);
    public bool VerifyVerbOI(List<WordModel> list_word, List<DitadoModel> sentence, bool noun);
    //---
    public bool VerifyVerbODAA(List<WordModel> list_word, List<DitadoModel> sentence, bool noun);
    //---
    public bool VerifyVerbPS(List<WordModel> list_word, List<DitadoModel> sentence);
    //---
    /* 
     * - P = pronoun
     * - V = verb
     * - Pr = preposition
     * - Adv = adverb 
     * - N = noun
     * - Adj = adjective
     * - A = article
     * - D = digit
     * - C = conjunction 
     */
    public List<LicaoModel> PeriodSS_V(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_Adj_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Adj_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_Adj_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Adj_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    //---
    public List<LicaoModel> PeriodSS_V_Adj_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Adj_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
}