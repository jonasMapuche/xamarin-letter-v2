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
    public List<LicaoModel> PeriodP_V(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adj_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adj_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adj_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adj_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adj_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adj_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_Adj_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Adj_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_Adj_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Adj_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodP_V_Adv_Adj_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodP_V_Adv_Adj_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
}