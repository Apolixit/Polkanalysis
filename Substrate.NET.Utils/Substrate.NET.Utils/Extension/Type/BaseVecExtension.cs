using Newtonsoft.Json.Linq;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Substrate.NET.Utils
{
    public static class BaseVecExtension
    {
        public static IEnumerable<T> AsEnumerable<T>(this BaseVec<T> baseVec) where T: IType, new()
        {
            if(baseVec == null) return Enumerable.Empty<T>();
            return baseVec.Value;
        }

        public static IDictionary<TKey, TValue> ToDictionnary<TKey, TValue>(BaseVec<BaseTuple<TKey, TValue>> baseVec)
            where TKey: IType, new()
            where TValue: IType, new()
        {
            var result = new Dictionary<TKey, TValue>();
            if(baseVec == null || baseVec.Value == null) return result;

            foreach(var elem in baseVec.Value)
            {
                var key = (TKey)elem.Value[0];
                if (!result.TryAdd(key, (TValue)elem.Value[1]))
                {
                    throw new InvalidOperationException($"Key {key} already exists !");
                }
            }

            return result;
        }

        /// <summary>
        /// It's a utility method that take 'nbToTake' first values from a BaseVec and then encode it (easier for unit testing)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vec"></param>
        /// <param name="nbToTake"></param>
        /// <returns></returns>
        public static string TakeAndEncode<T>(this BaseVec<T> vec, int nbToTake)
            where T : IType, new()
        {
            var bv = new BaseVec<T>(vec.Value.Take(nbToTake).ToArray());
            var bytes = new List<byte>();
            bytes.AddRange(bv.Encode());
            var final = Substrate.NetApi.Utils.Bytes2HexString(bytes.ToArray());

            return final;
        }
    }
}
