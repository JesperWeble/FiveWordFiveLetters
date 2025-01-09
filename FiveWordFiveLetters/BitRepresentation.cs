using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FiveWordFiveLetters
{
    public class BitRepresentation
    {
        public static int getAsBinary(string word)
        {
            int output = 0;
            foreach (char c in word)
            {
                output |= 1 << ((int)c - 'a');
                
            }
            return output;
        }
    }
}
