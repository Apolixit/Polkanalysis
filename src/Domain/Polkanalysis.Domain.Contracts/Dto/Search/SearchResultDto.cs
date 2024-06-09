using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Search
{
    public class SearchResultDto
    {
        public SearchResultType ResultType { get; set; }
        public DateTime? When { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        public enum SearchResultType
        {
            BlockHash,
            BlockNumber,
            SubstrateAddress,
        }
    }
}
