using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Helpers
{
    public static class Language
    {
        private static string english = "english";
        private static string deutsch = "deutsch";
        private static string italiano = "italiano";
        private static string espanol = "español";
        private static string portugues = "portugues";
        private static string francais = "français";
        private static string pусский = "pусский";


        public static string Lesson(string lesson)
        {
            if (lesson.Contains("lesson")) return english;
            if (lesson.Contains("lektion")) return deutsch;
            if (lesson.Contains("lezione")) return italiano;
            if (lesson.Contains("lección")) return espanol;
            if (lesson.Contains("lição")) return portugues;
            if (lesson.Contains("leçon")) return francais;
            if (lesson.Contains("урок")) return pусский;
            return "";
        }
        
    }

}
