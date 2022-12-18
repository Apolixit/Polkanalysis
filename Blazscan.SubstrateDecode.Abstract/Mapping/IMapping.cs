using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Abstract
{
    public interface IMapping
    {
        /// <summary>
        /// Search the current type into mapping element
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        IMappingElement Search(Type searchType);
    }
}
