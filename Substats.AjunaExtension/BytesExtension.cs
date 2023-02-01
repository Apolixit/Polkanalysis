using Ajuna.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.AjunaExtension
{
    public static class BytesExtension
    {
        public static string ToHuman(this byte[] bytes)
        {
            if (bytes == null) return string.Empty;

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
