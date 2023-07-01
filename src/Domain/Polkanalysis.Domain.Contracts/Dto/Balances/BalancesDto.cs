using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Balances
{
    public class BalancesDto
    {
        public double Transferable { get; set; } = 0;
        public double? Stacking { get; set; } = null;
        public double Others { get; set; } = 0;
        public double TotalNative { get; set; } = 0;
        public double TotalCurrency { get; set; } = 0;
    }
}
