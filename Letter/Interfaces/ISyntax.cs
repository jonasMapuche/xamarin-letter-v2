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
    public List<LicaoModel> PeriodPV(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVPrP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVPrN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdj(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdjP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdjPrP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVPrAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdv(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvPrP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdvN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvPrN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdvAdjP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvAdjPrP(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdvAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvPrAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    //---
    public List<LicaoModel> PeriodPVAdvAdj(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvAdjAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
    public List<LicaoModel> PeriodPVAdvAdjPrAdjN(string language, List<DitadoModel> sentence, List<LicaoModel> period);
}