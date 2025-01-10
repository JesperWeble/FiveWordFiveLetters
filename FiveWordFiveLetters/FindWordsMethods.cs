﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveWordFiveLetters
{
    public class FindWordsMethods
    {       
        
        public static void RecursiveMethod(int[] words, int index, string result = "", int mask = 0)
        {
            if (result.Where(x => x == ' ').Count() == Program._wordCount)
            {
                Console.WriteLine($"\n\n{result}\n\n");
                Program._result++;         
                return;

            }
            for (int i = index; i >= 0; i--)
            {
                if ((mask & words[i]) == 0 )
                {
                    RecursiveMethod(words, i - 1, string.Join(" ", result, Program._dictionary[words[i]]).TrimStart(), mask | words[i]);
                }
            }

        }

        static bool FilterForDistinctCharactersOnly(string filterFrom, string filter)
        {
            foreach (var character in filter)
            {
                if (filterFrom.Contains(character)) return false;
            }
            return true;
        }




        // Older method vvvvv
        public void FindWordsMethod()
        {
            List<char> usedCharacters = new List<char>();
            List<string> usedWords = new List<string>();
            bool invalidWord = false;


            string[] words = File.ReadAllLines(Program._file);
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
                            Program._result++;
                        }
                    }

                    //}
                }
                foreach (string word in usedWords)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
