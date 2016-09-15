using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Validate
    {
        static public string ReturnSkipSpace(string str)
        {            
            char[] strSymbols = str.ToCharArray();
            int i = 0;

            str = "";

            while (i<strSymbols.Length)
            {
                if (strSymbols[i]!=' ')
                {
                    str += strSymbols[i];
                }
                i++;
            }
            return str;
        }
    }
}
