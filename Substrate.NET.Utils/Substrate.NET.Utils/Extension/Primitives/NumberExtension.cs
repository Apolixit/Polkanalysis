using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    /// <summary>
    /// Memo :
    /// Vec<Tuple<T>> -> Dictionnary
    /// Vec<T> -> IList
    /// Tuple<T ,U> -> (T, U)
    /// BaseOpt<T> -> T?
    /// Str -> string
    /// Hex to classic text (encode utf8...)
    /// 
    /// All Ajuna primitive -> to primitive
    /// All primitive -> to Ajuna primitives
    /// 
    /// Address :
    ///     - Public Key
    ///     - ss42 key
    /// </summary>
    public static class NumberExtension
    {
        public static double ToDouble(this BigInteger num, int tokenDecimals)
        {
            var divider = new BigInteger(Math.Pow(10, tokenDecimals));
            return (double)(num / divider);
        }
        public static double ToDouble(this U128 num, int tokenDecimals) => ToDouble(num.Value, tokenDecimals);
        public static double ToDouble(this U128 num, Properties properties) => ToDouble(num.Value, properties.TokenDecimals);
        public static async Task<double> ToDoubleAsync(this U128 num, ISystem system)
        {
            var prop = await system.PropertiesAsync();
            return ToDouble(num, prop.TokenDecimals);
        }

        private static object CastToUnsigned<T>(T number) where T : struct
        {
            unchecked
            {
                switch (number)
                {
                    case long xlong: return (ulong)xlong;
                    case int xint: return (uint)xint;
                    case short xshort: return (ushort)xshort;
                    case sbyte xsbyte: return (byte)xsbyte;
                }
            }
            return number;
        }
    }
}
