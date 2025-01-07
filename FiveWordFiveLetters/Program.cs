// Jeg har fået den til at finde en kombination af fem ord
// Er i gang med at finde ud af at gentage det og finde alle kombinationer.
// Kunne ikke helt finde hoved og hale i noget som helst, da jeg ikke havde sovet :(

using System;
using System.IO;

namespace FiveWordFiveLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int comboResult = 0;
            bool invalidWord = false;
            List<char> usedCharacters = new List<char>();
            List<string> usedWords = new List<string>();
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\word_perfect.txt";
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\word_imperfect.txt";
            string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\beta_data.txt";
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\alpha_data.txt";
            string[] words = File.ReadAllLines(file);
            //HashSet<string> words = new HashSet<string>(File.ReadAllLines(file));
            


            for (int i = 0; i < 5; i++)
            {
                
                foreach (string word in words)
                {
                    //if (word != usedWords[i])
                    //{

                        if (word.Length == 5)
                        {
                            invalidWord = false;
                            foreach (char character in word)
                            {
                                if (usedCharacters.Contains(character))
                                {
                                    invalidWord = true;
                                    break;
                                }

                                if (word.Count(c => c == character) > 1)
                                {
                                    invalidWord = true;
                                    break;

                                }
                            }
                            Console.WriteLine(word + " = " + invalidWord);
                            if (invalidWord == false)
                            {
                                Console.WriteLine("Added |");
                                usedWords.Add("|");
                                usedWords[i] = usedWords[i] + word + "|";
                                foreach (char character in word)
                                {
                                    usedCharacters.Add(character);
                                }
                                result++;
                            }
                        }

                    //}
                }
                foreach (string word in usedWords)
                {
                    Console.WriteLine(word);
                }
            }


            Console.WriteLine("Five Letter Words: " + result);
            Console.WriteLine("Valid Combinations: " + comboResult);
        }
    }
}
