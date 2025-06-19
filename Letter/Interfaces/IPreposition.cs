using Letter.Models;
using System.Collections.Generic;

interface IPreposition
{
    //---
    public List<JuncaoModel> SelectPreposition(string language);
    //---
    public List<JuncaoModel> GetPreposition(string language);
    //---
    public List<JuncaoModel> FilterPreposition(List<JuncaoModel> preposition, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> MountMorphologyPreposition(List<DitadoModel> sentence, List<JuncaoModel> preposition);
}

