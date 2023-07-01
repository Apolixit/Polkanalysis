using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Price
{
    public class CoinHistoryDto
    {
        public string id {  get; set; }
        public string symbol {  get; set; }
        public string name {  get; set; }
        public MarketDataDto market_data { get; set; }
    }

    public class MarketDataDto
    {
        public CurrentPriceDto current_price { get; set; }
    }

    public class CurrentPriceDto
    {
        public double usd { get; set; }
    }
}
