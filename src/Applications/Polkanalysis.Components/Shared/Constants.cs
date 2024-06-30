using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Shared
{
    public static class Constants
    {
        public static DateTime? DefaultDate => null;
        public static DateTime? DefaultTime => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static int DefaultPageSize => 10;
    }
}
