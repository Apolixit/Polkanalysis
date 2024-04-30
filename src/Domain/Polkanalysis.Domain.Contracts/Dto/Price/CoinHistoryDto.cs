using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Price
{
    public class CoinHistoryDto
    {
        public string id { get; set; } = default!;
        public string symbol { get; set; } = default!;
        public string name { get; set; } = default!;
        public MarketDataDto market_data { get; set; } = default!;
    }

    public class MarketDataDto
    {
        public CurrentPriceDto current_price { get; set; } = default!;
    }

    public class CurrentPriceDto
    {
        public double usd { get; set; } = default!;
    }
}
