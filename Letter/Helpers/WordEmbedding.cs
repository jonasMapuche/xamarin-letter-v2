using Letter.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Letter.Helpers
{
    public class WordEmbedding
    {
        public bool Similarity(Dictionary<(string, string), int> word_2_vec, HashSet<string> vocabulary, string target, string target1)
        {
            try
            {
                //---
                if ((Array.IndexOf(vocabulary.ToArray(), target) == -1) || (Array.IndexOf(vocabulary.ToArray(), target1) == -1))
                {
                    return false;
                }
                //---
                bool similarity = false;
                foreach (KeyValuePair<(string, string), int> value in word_2_vec)
                {
                    if ((value.Key.Item1 == target) && (value.Key.Item2 == target1))
                    {
                        similarity = true;
                        break;
                    }
                }
                //---
                return similarity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Saw(List<DitadoModel> sentences)
        {
            try
            {
                //---
                string ditado = "";
                sentences.ForEach(index =>
                {
                    ditado = ditado + index.impulso;
                });
                ditado = ditado.ToLower();
                ditado = ditado.Replace(".", " . ");
                ditado = ditado.Replace("!", " ! ");
                ditado = ditado.Replace("?", " ? ");
                ditado = ditado.Replace("¿", " ¿ ");
                ditado = ditado.Replace("'", " ' ");
                ditado = RemoveAccent(ditado);
                return ditado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public HashSet<string> Vocabulary(List<DitadoModel> sentences)
        {
            try
            {
                //---
                string ditado = Saw(sentences);
                //---
                HashSet<string> vocabulary = new HashSet<string>(ditado.Split(' '));
                //---
                return vocabulary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Dictionary<(string, string), int> Word2Vec(List<DitadoModel> sentences)
        {
            //---
            Dictionary<(string, string), int> word_pairs = new Dictionary<(string, string), int>();
            string[] words = Saw(sentences).Split(' ');
            for (int i = 0; i < words.Length - 1; i++)
            {
                var pair = (words[i], words[i + 1]);
                if ((pair.Item1 == ".") || (pair.Item2 == ".")) continue;
                if ((pair.Item1 == "!") || (pair.Item2 == "!")) continue;
                if ((pair.Item1 == "?") || (pair.Item2 == "?")) continue;
                if ((pair.Item1 == "¿") || (pair.Item2 == "¿")) continue;
                if ((pair.Item1 == "'") || (pair.Item2 == "'")) continue;
                if (word_pairs.TryGetValue(pair, out int value))
                {
                    word_pairs[pair] = ++value;
                }
                else
                {
                    word_pairs[pair] = 1;
                }
            }
            //---
            return word_pairs;
        }

        public string RemoveAccent(string input)
        {
            string normalized_string = input.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char i in normalized_string)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(i) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(i);
                }
            }
            return builder.ToString();
        }

    }
}
