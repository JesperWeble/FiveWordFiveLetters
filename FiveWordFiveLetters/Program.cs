using System;
using System.IO;

namespace FiveWordFiveLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            bool invalidWord = false;
            List<char> usedCharacters = new List<char>();
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\word_perfect.txt";
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\word_imperfect.txt";
            string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\beta_data.txt";
            //string file = @"C:\Users\HFGF\source\repos\FiveWordFiveLetters\FiveWordFiveLetters\alpha_data.txt";
            string[] words = File.ReadAllLines(file);

            // For every word in the file check if the number of characters is 5, then check each character in the word has more than one instance in the word then add to the result.
            foreach (string word in words)
            {
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
                    if (invalidWord == false)
                    {
                        foreach(char character in word)
                        {
                            usedCharacters.Add(character);
                        }
                        result++;
                    }
                }
            }


            Console.WriteLine("Five Letter Words: " + result);
        }
    }
}
