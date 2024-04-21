using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    public static class BytesExtension
    {
        public static byte[] ToBytes(this IEnumerable<U8> bytes)
        {
            if (bytes == null) return new byte[0];

            return bytes.Select(x => x.Value).ToArray();
        }

        public static string ToHuman(this IEnumerable<U8> bytes)
        {
            if (bytes == null) return string.Empty;
            return bytes.ToBytes().ToHuman();
        }

        public static string ToHuman(this byte[] bytes)
        {
            if (bytes == null) return string.Empty;

            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] CompleteByteArray(this byte[] data, int desiredLength)
        {
            if (data.Length >= desiredLength)
                return data;

            byte[] newData = new byte[desiredLength];
            Array.Copy(data, newData, data.Length);
            return newData;
        }
    }
}
