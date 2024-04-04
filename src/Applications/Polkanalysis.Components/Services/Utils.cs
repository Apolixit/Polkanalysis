using Ardalis.GuardClauses;

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
