using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Analysis.Events.Balances
{
    public class BalancesTransferModel
    {
        public string BlockchainName { get; set; } = string.Empty;
        public int BlockId { get; set; }
        public int EventId { get; set; }
        public RuntimeEvent ModuleName { get; set; }
        public Domain.Contracts.Secondary.Pallet.Balances.Enums.Event ModuleEvent { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public U128 Amount { get; set; } = new U128();
    }
}
