using Ardalis.GuardClauses;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Polkanalysis.Components.Services
{
    public static class Utils
    {
        public static string Shorten(this string elem, int nbTake)
        {
            Guard.Against.NegativeOrZero(nbTake, nameof(nbTake));

            if(elem.Length > nbTake)
            {
                return string.Concat(elem.Take(nbTake).Concat("...").ToList());
            } else
            {
                return elem;
            }
        }
    }
}
