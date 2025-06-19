using Letter.Models;
using System.Collections.Generic;

interface INoun
{
    //---
    public List<string> MountNoun(string language, FraseModel lesson, List<FraseModel> book);
    //---
    public List<string> FilterList(List<string> value, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> UnionNoun(List<LicaoModel> list_first, List<LicaoModel> list_second);
    public List<LicaoModel> UnionNoun(List<string> list_string, List<LicaoModel> list_second);
    //---
    public List<LicaoModel> VerifyNoun(List<LicaoModel> lesson, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> MountNounDigit(List<string> noun, List<AlgarismoModel> digit, List<PreceitoModel> article);
    public List<LicaoModel> MountNounArticle(List<string> noun, List<PreceitoModel> article);
    public List<LicaoModel> MountNounPronoun(List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article);
    //---
    public List<LicaoModel> MountMorphologyNoun(List<DitadoModel> sentence, List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article, List<AlgarismoModel> digit);
}