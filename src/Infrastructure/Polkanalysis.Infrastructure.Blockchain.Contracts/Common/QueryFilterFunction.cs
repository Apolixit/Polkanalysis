using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Common
{
    public class QueryFilterFunction
    {
        public const int DefaultPagination = 100;

        public int? NbElementTake { get; set; } = null;
        public int? NbElementSkip { get; set; } = null;
        public int Pagination { get; set; } = DefaultPagination;
    }
}
