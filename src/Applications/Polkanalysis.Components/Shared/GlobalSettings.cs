using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Components.Shared
{
    public class GlobalSettings
    {
        /// <summary>
        /// Display data type, could be with table or card element
        /// </summary>
        public ViewDisplayType ViewDisplay { get; set; }

        /// <summary>
        /// Table display type, could be compact (2/3 columns), normal (4/5 columns) or full
        /// </summary>
        public TableDisplayType TableDisplay { get; set; }

        public enum ViewDisplayType
        {
            TableRaw,
            CardElement
        }

        public enum TableDisplayType
        {
            /// <summary>
            /// Display only the most important columns
            /// </summary>
            Compact,

            /// <summary>
            /// Display the most important columns and some additional columns
            /// </summary>
            Normal,

            /// <summary>
            /// Display all the columns
            /// </summary>
            Full
        }
    }
}
