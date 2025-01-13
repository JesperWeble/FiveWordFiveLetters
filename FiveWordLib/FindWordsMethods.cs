using System;
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
                Console.WriteLine($"{result}");
                Program._result++;         
                return;

            }
            if (mask == 0)
            {
                Parallel.For(0, index, x =>
                {
                    RecursiveMethod(words, x-1, Program._dictionary[words[x]], words[x]);
                });

            }
            else
            {
                for (int i = index; i >= 0; i--)
                {
                    if ((mask & words[i]) == 0)
                    {
                        RecursiveMethod(words, i - 1, string.Join(" ", result, Program._dictionary[words[i]]).TrimStart(), mask | words[i]);
                    }
                }
            }
        }
    }
}
