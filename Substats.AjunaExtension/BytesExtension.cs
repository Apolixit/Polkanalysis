using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.AjunaExtension
{
    public static class BytesExtension
    {
        public static byte[] ToBytes(this IEnumerable<U8> bytes)
        {
            if (bytes == null) return new byte[0];

            return bytes.Select(x => x.Value).ToArray();
        }

        public static string ToHuman(this byte[] bytes)
        {
            if (bytes == null) return string.Empty;

            return Encoding.UTF8.GetString(bytes);
        }

        public static string ToHuman(this IEnumerable<U8> bytes)
        {
            if (bytes == null) return string.Empty;

            return Encoding.UTF8.GetString(bytes.Select(x => x.Value).ToArray());
        }
    }
}
