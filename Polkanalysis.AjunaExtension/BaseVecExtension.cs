using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.AjunaExtension
{
    public static class BaseVecExtension
    {
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
            var final = Utils.Bytes2HexString(bytes.ToArray());

            return final;
        }
    }
}
