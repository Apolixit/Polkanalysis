using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Balances
{
    public class BalancesDto
    {
        /// <summary>
        /// Free balance
        /// </summary>
        public CurrencyDto Transferable { get; set; } = CurrencyDto.Empty;

        /// <summary>
        /// Locked + reserve
        /// </summary>
        public List<(CurrencyDto Currency, string Reason)> NonTransferable { get; set; } = new List<(CurrencyDto, string)>();

        /// <summary>
        /// Amount locked in a pool
        /// </summary>
        public CurrencyDto Pool { get; set; } = CurrencyDto.Empty;

        /// <summary>
        /// Amount locked in a crowdloan
        /// </summary>
        public CurrencyDto Crowdloan { get; set; } = CurrencyDto.Empty;

        /// <summary>
        /// Total amount
        /// </summary>
        public CurrencyDto Total {
            get
            {
                var res = Transferable + Pool + Crowdloan;
                foreach(var nonTransferable in NonTransferable)
                {
                    res += nonTransferable.Item1;
                }

                return res;
            }
        }
        public DateTime? LastTimeUsdUpdated { get; set; }
    }
}
