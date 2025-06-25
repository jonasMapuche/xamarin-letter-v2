using Letter.Models;
using System.Collections.Generic;

interface IAdjective
{
    //---
    public List<string> MountAdjective(FraseModel lesson, List<FraseModel> book);
    //---
    public List<string> FilterList(List<string> value, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> VerifyAdjective(List<LicaoModel> adjective_adverb, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> MountAdjectivePronoun(List<string> noun, List<EstoutroModel> pronoun, List<PreceitoModel> article);
    public List<LicaoModel> MountAdjectiveAdverb(List<string> adjective, List<CircunstanciaModel> adverb);
    public List<LicaoModel> MountAdjectiveAdverb(List<string> adjective, List<LicaoModel> adverb_adverb);
    public List<LicaoModel> MountAdjectiveNoun(List<string> noun, List<LicaoModel> adjective_adverb, List<PreceitoModel> article);
    //---
    public List<LicaoModel> UnionAdjective(List<string> adjective, List<LicaoModel> adjective_adverb);
    public List<LicaoModel> UnionAdjective(List<LicaoModel> adjective_adverb, List<LicaoModel> adjective_adverb_adverb);
    //---
    public List<LicaoModel> MountMorphologyAdjective(List<DitadoModel> sentence, List<string> adjective, List<CircunstanciaModel> adverb);
    public List<LicaoModel> MountMorphologyAdjectiveNoun(List<DitadoModel> sentence, List<string> adjective, List<CircunstanciaModel> adverb, List<string> noun, List<PreceitoModel> article);
}