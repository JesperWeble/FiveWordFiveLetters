// Er lige blevet færdig med Recursive Method, og skal til at gå i gang med bit representation.

using System;
using System.IO;

namespace FiveWordFiveLetters
{
    public class Program
    {
        public const string _file = "words_beta.txt";
        public const int _wordLength = 5;
        public const int _wordCount = 4;

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
            methods.RecursiveMethod(filteredWords, filteredWords.Length - 1);


            //methods.FindWordsMethod();

            Console.WriteLine("Valid Combinations: " + _result);
        }
    }
}