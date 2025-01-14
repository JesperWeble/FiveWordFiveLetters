using FiveWordFiveLetters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveWordLib
{
    public class FindWords
    {
        private Dictionary<int, string> _dictionary = new Dictionary<int, string>();
        public static int _result = 0;
        public void Find(string file, int wordCount, int wordLength)
        {
            var watch = new System.Diagnostics.Stopwatch();
            ReadFile(file, wordLength, _dictionary);
            watch.Start();
            RecursiveSearch(_dictionary.Keys.ToArray(), _dictionary.Count - 1, wordCount, _dictionary);
            watch.Stop();
            Console.WriteLine($"Valid Combinations: {_result} in {watch.ElapsedMilliseconds}ms");
        }

        private void ReadFile(string file, int wordLength, Dictionary<int, string> dictionary)
        {
            _dictionary.Clear();
            int bit = 0;
            string[] words = File.ReadAllLines(file).Where(x => x.Length == wordLength && x.Distinct().Count() == wordLength).ToArray();
            foreach (string word in words)
            {
                bit = BitRepresentation.getAsBinary(word);
                if (dictionary.ContainsKey(bit)) continue;
                dictionary.Add(bit, word);
            }

        }

        public static void RecursiveSearch(int[] words, int index, int wordCount, Dictionary<int, string> dictionary, string result = "", int mask = 0)
        {

            if (result.Where(x => x == ' ').Count() == wordCount)
            {
                Console.WriteLine($"{result}");
                _result++;
                return;
            }
            if (mask == 0)
            {
                Parallel.For(0, index, x =>
                {
                    RecursiveSearch(words, x - 1, wordCount, dictionary, dictionary[words[x]], words[x]);
                });

            }
            else
            {
                for (int i = index; i >= 0; i--)
                {
                    if ((mask & words[i]) == 0)
                    {
                        RecursiveSearch(words, i - 1, wordCount, dictionary, string.Join(" ", result, dictionary[words[i]]).TrimStart(), mask | words[i]);
                    }
                }
            }
        }
    }
}
