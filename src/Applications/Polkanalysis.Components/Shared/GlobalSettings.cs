using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Shared
{
    public class GlobalSettings
    {
        public ViewDisplayType DisplayType { get; set; }

        public enum ViewDisplayType
        {
            TableRaw,
            CardElement
        }
    }
}
