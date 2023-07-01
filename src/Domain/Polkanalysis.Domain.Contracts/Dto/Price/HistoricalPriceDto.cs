using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Price
{
    public class HistoricalPriceDto
    {
        public IEnumerable<TokenPriceDto> TokenPrices { get; set; } = Enumerable.Empty<TokenPriceDto>();
    }
}
