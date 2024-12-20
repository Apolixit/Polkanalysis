﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping
{
    public interface INodeMapping
    {
        /// <summary>
        /// Search the current type into mapping element
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        IMappingElement Search(Type searchType);
    }
}
