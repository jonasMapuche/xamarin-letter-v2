using Letter.Models;
using System.Collections.Generic;

interface IDigit
{
    //---
    public List<AlgarismoModel> SelectDigit(string language);
    //---
    public List<AlgarismoModel> GetDigit(string language);
    //---
    public List<AlgarismoModel> FilterDigit(List<AlgarismoModel> digit, List<DitadoModel> sentence);
    //---
    public List<LicaoModel> MountMorphologyDigit(List<DitadoModel> sentence, List<AlgarismoModel> digit);
}
