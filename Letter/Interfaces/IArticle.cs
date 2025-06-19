using Letter.Models;
using System.Collections.Generic;

interface IArticle
{
    //---
    public List<PreceitoModel> SelectArticle(string language);
    //---
    public List<PreceitoModel> GetArticle(string language);
    //---
    public List<PreceitoModel> FilterArticle(List<PreceitoModel> article, List<DitadoModel> sentence);
    //---
    public HashSet<string> MountArticle(List<PreceitoModel> article);
    //---
    public List<LicaoModel> MountMorphologyArticle(List<DitadoModel> sentence, List<PreceitoModel> article);
}
