using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Common
{
    public static class StringExtensions
    {
        /// <summary>
        /// removes all spaces from string
        /// </summary>
        public static string RemoveWhiteSpaces(this string param) => String.Concat(param.Where(w => !Char.IsWhiteSpace(w)));
    }
}
