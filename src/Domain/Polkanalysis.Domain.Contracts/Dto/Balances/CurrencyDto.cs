using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Balances
{
    public class CurrencyDto
    {
        public CurrencyDto() { }

        public CurrencyDto(double native)
        {
            Native = native;
        }

        public CurrencyDto(double native, double? lastUsdValue)
        {
            Native = native;

            if(lastUsdValue.HasValue)
                Usd = lastUsdValue.Value * native;
        }
        public double Native { get; set; } = 0;
        public double Usd { get; set; } = 0;

        public static CurrencyDto Empty => new CurrencyDto();

        public static CurrencyDto operator +(CurrencyDto a, CurrencyDto b)
        {
            return new CurrencyDto
            {
                Native = a.Native + b.Native,
                Usd = a.Usd + b.Usd
            };
        }
    }
}
