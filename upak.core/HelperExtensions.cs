using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upak.core
{
    internal static class HelperExtensions
    {
        public static string EnsureEndsWith(this string str, char c)
        {
            if (!str.EndsWith(c))
                return str + c;
            return str;
        }
    }
}
