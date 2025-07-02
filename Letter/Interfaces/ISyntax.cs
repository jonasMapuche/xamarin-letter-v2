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
    public bool VerifyVerbOI(List<WordModel> list_word, List<DitadoModel> sentence);
    public bool VerifyVerbODAA(List<WordModel> list_word, List<DitadoModel> sentence);
    //---
    public bool VerifyVerbPS(List<WordModel> list_word, List<DitadoModel> sentence);
    //---
    public bool VerifyAdjectiveOD(List<WordModel> list_word, List<DitadoModel> sentence, bool noun);
    public bool VerifyAdjectiveOI(List<WordModel> list_word, List<DitadoModel> sentence);
    public bool VerifyAdjectiveODAA(List<WordModel> list_word, List<DitadoModel> sentence);
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
     * --
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct)
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct) + Direct Object (Adjectival Adjunct (Adverbial Adjunct))
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct) + Indirect Object (Adjectival Adjunct (Adverbial Adjunct))
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct) + Predicate of the Subject (Adverbial Adjunct)
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct) + Predicate of the Subject (Adverbial Adjunct) + Direct Object (Adjectival Adjunct (Adverbial Adjunct))
     * Noun (Adjectival Adjunct) + Verb (Adverbial Adjunct) + Predicate of the Subject (Adverbial Adjunct) + Indirect Object (Adjectival Adjunct (Adverbial Adjunct))
     */
    //---
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
    //---
    /*
     * Noun + Adjectival Adjunct + Verb (Adverbial Adjunct) + Direct Object (Adjectival Adjunct (Adverbial Adjunct)) + Predicate of the Object (Adverbial Adjunct)
     * Noun + Adjectival Adjunct + Verb (Adverbial Adjunct) + Indirect Object (Adjectival Adjunct (Adverbial Adjunct)) + Predicate of the Object (Adverbial Adjunct)
     * Noun + Adjectival Adjunct + Verb (Adverbial Adjunct) + Direct Object (Adjectival Adjunct (Adverbial Adjunct)) + Indirect Object (Adjectival Adjunct (Adverbial Adjunct))
     * Noun + Adjectival Adjunct + Verb (Adverbial Adjunct) + Indirect Object (Adjectival Adjunct (Adverbial Adjunct)) + Direct Object (Adjectival Adjunct (Adverbial Adjunct))
     * -- 
    public List<LicaoModel> PeriodSS_V_P_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_N_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_AdjN_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     * --
    public List<LicaoModel> PeriodSS_V_Pr_P_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_N_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_AdjN_Adj(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     * --
    public List<LicaoModel> PeriodSS_V_P_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_P_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_P_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_N_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_N_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_N_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_AdjN_Pr_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_AdjN_Pr_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_AdjN_Pr_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     * --
    public List<LicaoModel> PeriodSS_V_Pr_P_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_P_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_P_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_N_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_N_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_N_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_AdjN_P(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_AdjN_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    public List<LicaoModel> PeriodSS_V_Pr_AdjN_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     */
    /*
     * Noun + Adjectival Adjunct + Verb (Adverbial Adjunct) + Direct Object (Adjectival Adjunct (Adverbial Adjunct)) + Conjuction + Direct Object (Adjectival Adjunct (Adverbial Adjunct))
     * --
     public List<LicaoModel> PeriodSS_V_N_C_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     public List<LicaoModel> PeriodSS_V_N_C_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     public List<LicaoModel> PeriodSS_V_AdjN_C_AdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
     public List<LicaoModel> PeriodSS_V_AdjN_C_N(string language, List<DitadoModel> sentence, List<LicaoModel> period, bool noun);
    */
}