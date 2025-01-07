// Jeg har fået den til at finde en kombination af fem ord
// Er i gang med at finde ud af at gentage det og finde alle kombinationer.
// Kunne ikke helt finde hoved og hale i noget som helst, da jeg ikke havde sovet :(

using System;
using System.IO;

namespace FiveWordFiveLetters
{
    public class Program
    {
        public const string _file = "words_alpha.txt";
        public const int _wordLength = 5;
        public const int _wordCount = 5;

        public static int _result = 0;


        static void Main(string[] args)
        {
            FindWordsMethods methods = new FindWordsMethods();

            string[] words = File.ReadAllLines(_file).Where(x => x.Length == _wordLength && x.Distinct().Count() == _wordLength).ToArray();
            var dictionary = new Dictionary<string, string>();
            foreach (string word in words)
            {
                string sortedChar = new string(word.OrderBy(x => x).ToArray());
                if (dictionary.ContainsKey(sortedChar)) continue;
                dictionary.Add(sortedChar, word);
            }
            var filteredWords = dictionary.Values.ToArray();
            Console.WriteLine(filteredWords.Length);
            methods.RecursiveMethod(filteredWords, _wordCount, filteredWords.Length - 1);


            //methods.FindWordsMethod();

            Console.WriteLine("Valid Combinations: " + _result);
        }
    }
}