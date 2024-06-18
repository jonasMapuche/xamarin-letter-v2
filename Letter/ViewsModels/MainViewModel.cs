using Letter.Models;
using Letter.ViewModel;
using System;
using System.Collections.Generic;

namespace Letter.ViewsModels
{
    public class MainViewModel
    {
        public static readonly LetterViewModel _lettersViewModel = new LetterViewModel();

        public List<String> GetSentenceSimple(string lesson)
        {
            FraseModel aula = _lettersViewModel.GetSentenceSimple(lesson);
            List<string> saida = new List<string>();
            if (aula != null)
            {
                saida.Add(aula.conteudo.pronome[0].ToString());
                saida.Add(aula.conteudo.verbo[0].ToString());
                saida.Add(aula.conteudo.substantivo[0].ToString());
            }
            else saida = null;
            return saida;
        }
    }
}