using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils.Extension
{
    public static class StringExtension
    {
        public static bool IsEqual(this string? value, string? value2)
        {
            value ??= string.Empty;
            value2 ??= string.Empty;

            return value.Equals(value2);
        }
    }
}
