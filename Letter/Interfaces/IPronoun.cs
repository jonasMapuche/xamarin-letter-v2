using Letter.Models;
using Letter.ViewsModels;
using System.Collections.Generic;

interface IPronoun
{
    //---
    public List<EstoutroModel> SelectPronoun(string language);
    //---
    public List<EstoutroModel> GetPronoun(string language);
    public List<EstoutroModel> GetPronoun(string language, string type);
    //---
    public List<EstoutroModel> FilterTypePronoun(List<EstoutroModel> pronouns, List<string> type);
    public List<EstoutroModel> FilterPronoun(List<EstoutroModel> pronoun, List<DitadoModel> sentence);
    //---
    public List<EstoutroModel> SetSortPronoun(List<EstoutroModel> pronoun);
    //---
    public List<EstoutroModel> MountPronoun(List<string> type, List<EstoutroModel> pronoun);
    //---
    public List<LicaoModel> MountMorphologyPronoun(List<DitadoModel> sentence, List<EstoutroModel> pronoun);
}



