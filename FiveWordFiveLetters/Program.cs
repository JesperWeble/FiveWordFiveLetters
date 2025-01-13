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
        public static Dictionary<int, string> _dictionary = new Dictionary<int, string>();


        static void Main(string[] args)
        {
            int bit = 0;
            string[] words = File.ReadAllLines(_file).Where(x => x.Length == _wordLength && x.Distinct().Count() == _wordLength).ToArray();
            foreach (string word in words)
            {
                //string sortedWord = new string(word.OrderBy(x => x).ToArray());
                bit = BitRepresentation.getAsBinary(word);
                if (_dictionary.ContainsKey(bit)) continue;
                _dictionary.Add(bit, word);
            }
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            FindWordsMethods.RecursiveMethod(_dictionary.Keys.ToArray(), _dictionary.Count - 1);
            watch.Stop();

            //methods.FindWordsMethod();

            Console.WriteLine($"Valid Combinations: {_result} in {watch.ElapsedMilliseconds}ms");
        }
    }
}