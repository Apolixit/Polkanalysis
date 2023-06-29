using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Price
{
    public class TokenPriceDto
    {
        public required double Price { get; set; }
        public required CurrencyDto CompareToCurrency { get; set; }
        public required DateTime Date { get; set; }

        public override string? ToString()
        {
            return $"[{Date.ToString("dd/MM/yyyy")} {Price} / {CompareToCurrency}]";
        }
    }
}
