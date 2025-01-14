// Er lige blevet færdig med Recursive Method, og skal til at gå i gang med bit representation.

using FiveWordLib;
using System;
using System.IO;


namespace FiveWordFiveLetters
{
    public class Program
    {
        const string _file = "words_alpha.txt";
        public const int _wordLength = 5;
        public const int _wordCount = 4;
        public static int _result = 0;
        public static Dictionary<int, string> _dictionary = new Dictionary<int, string>();


        static void Main(string[] args)
        {
            
            FindWords wordFinder = new FindWords();
            wordFinder.Find(_file, _wordCount, _wordLength);

        }
    }
}