using FiveWordFiveLetters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveWordLib
{
    public class ReadFile
    {
        public static Dictionary<int, string> _dictionary = new Dictionary<int, string>();
        public static void Read(string file, int wordLength) 
        {
            int bit = 0;
            string[] words = File.ReadAllLines(file).Where(x => x.Length == wordLength && x.Distinct().Count() == wordLength).ToArray();
            foreach (string word in words)
            {
                bit = BitRepresentation.getAsBinary(word);
                if (_dictionary.ContainsKey(bit)) continue;
                _dictionary.Add(bit, word);
            }

        }
    }
}
