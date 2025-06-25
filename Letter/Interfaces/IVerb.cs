using Letter.Models;
using System.Collections.Generic;

interface IVerb
{
    //---
    public List<string> MountModel(FraseModel lesson);
    public List<ElocucaoModel> MountVerb(string language, FraseModel lesson);
    //---
    public List<ElocucaoModel> GetModel(string language, string model);
    //---
    public List<ElocucaoModel> SelectVerb(string language);
    //---
    public List<ElocucaoModel> MountVerb(List<string> model, List<ElocucaoModel> verb);
    //---
    public List<ElocucaoModel> FilterVerb(List<ElocucaoModel> verb, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> VerifyVerb(List<LicaoModel> verb_adverb, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> UnionVerb(List<ElocucaoModel> verb, List<LicaoModel> verb_adverb);
    public List<LicaoModel> UnionVerb(List<LicaoModel> verb_adverb, List<LicaoModel> verb_adverb_adverb);
    //---
    public List<LicaoModel> MountVerbAdverb(List<ElocucaoModel> verb, List<CircunstanciaModel> adverb);
    public List<LicaoModel> MountVerbAdverb(List<ElocucaoModel> verb, List<LicaoModel> adverb_adverb);
    //---
    public List<LicaoModel> MountMorphologyVerb(List<DitadoModel> sentence, List<string> model, List<ElocucaoModel> verb, List<CircunstanciaModel> adverb);
}