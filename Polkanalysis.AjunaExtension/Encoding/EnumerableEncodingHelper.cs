using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Substrate.DotNet.Extension
// Substrate.NET.API.Extension
// Substrate.NET.API.Helper
namespace Polkanalysis.AjunaExtension.Encoding
{
    public static class EnumerableEncodingHelper
    {
        public static byte[] Encode<T>(IEnumerable<T> datas)
            where T : IType
        {
            List<byte> list = new List<byte>();
            list.AddRange(new CompactInteger(datas.Count()).Encode());

            foreach (T data in datas)
            {
                list.AddRange(data.Encode());
            }
            return list.ToArray();
        }

        public static IEnumerable<T> Decode<T>(byte[] byteArray, ref int p)
            where T : IType, new()
        {
            int num = p;
            CompactInteger compactInteger = CompactInteger.Decode(byteArray, ref p);
            T[] array = new T[(int)compactInteger];
            for (int i = 0; i < compactInteger; i++)
            {
                T val = new T();
                val.Decode(byteArray, ref p);
                array[i] = val;
            }

            int TypeSize = p - num;
            var Bytes = new byte[TypeSize];
            Array.Copy(byteArray, num, Bytes, 0, TypeSize);
            return array;
        }
    }
}
