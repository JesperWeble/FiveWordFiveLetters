// Er lige blevet færdig med Recursive Method, og skal til at gå i gang med bit representation.

using System;
using System.IO;


namespace FiveWordFiveLetters
{
    public class Program
    {
        public const string _file = "words_alpha.txt";
        public const int _wordLength = 5;
        public const int _wordCount = 4;
        public static int _result = 0;
        private static Dictionary<int, string> dictionary = new Dictionary<int, string>();


        static void Main(string[] args)
        {
            int bit = 0;
            string[] words = File.ReadAllLines(_file).Where(x => x.Length == _wordLength && x.Distinct().Count() == _wordLength).ToArray();
            foreach (string word in words)
            {
                string sortedWord = new string(word.OrderBy(x => x).ToArray());
                bit = BitRepresentation.getAsBinary(sortedWord);
                if (dictionary.ContainsKey(bit)) continue;
                dictionary.Add(bit, sortedWord);
            }
            var filteredWords = dictionary.Values.ToArray();
            Console.WriteLine(filteredWords.Length);
            FindWordsMethods.RecursiveMethod(filteredWords, filteredWords.Length - 1);


            //methods.FindWordsMethod();

            Console.WriteLine("Valid Combinations: " + _result);
        }
    }
}