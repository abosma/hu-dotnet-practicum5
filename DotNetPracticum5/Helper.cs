using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5
{
    public static class Helper
    {
        public static string Reverse(string InputString)
        {
            char[] charArray = InputString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
