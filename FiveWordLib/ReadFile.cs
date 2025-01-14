//using FiveWordFiveLetters;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FiveWordLib
//{
//    public class ReadFile
//    {
//        public static Dictionary<int, string> Read(string file, int wordLength, Dictionary<int, string> dictionary)
//        {
//            int bit = 0;
//            string[] words = File.ReadAllLines(file).Where(x => x.Length == wordLength && x.Distinct().Count() == wordLength).ToArray();
//            foreach (string word in words)
//            {
//                bit = BitRepresentation.getAsBinary(word);
//                if (dictionary.ContainsKey(bit)) continue;
//                dictionary.Add(bit, word);
//            }
//            return dictionary;

//        }
//    }
//}
