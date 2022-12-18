using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Abstract.Mapping
{
    public interface IMappingCategory
    {
        /// <summary>
        /// Type of mapping
        /// </summary>
        string CategoryName { get; set; }

        /// <summary>
        /// Mapping associated to the category
        /// </summary>
        IList<IMappingElement> Mapping { get; set; }
    }
}
