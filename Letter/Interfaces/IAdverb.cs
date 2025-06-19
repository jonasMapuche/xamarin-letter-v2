using Letter.Models;
using System.Collections.Generic;

interface IAdverb
{
    //---
    public List<CircunstanciaModel> SelectAdverb(string language);
    //---
    public List<CircunstanciaModel> GetAdverb(string language);
    //---
    public List<CircunstanciaModel> FilterAdverb(List<CircunstanciaModel> adverb, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> MountAdverbAdverb(List<CircunstanciaModel> adverb);
    //---
    public List<LicaoModel> UnionAdverb(List<CircunstanciaModel> adverb, List<LicaoModel> adverb_adverb);
    //---
    public List<LicaoModel> MountMorphologyAdverb(List<DitadoModel> sentence, List<CircunstanciaModel> adverb);
}