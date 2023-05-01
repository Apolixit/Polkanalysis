using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances
{
    /// <summary>
    /// Transfer succeeded.
    /// </summary>
    public class BalancesTransferModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesTransferModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string from, string to, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            From = from;
            To = to;
            Amount = amount;
        }

        public required string From { get; set; }

        public required string To { get; set; }

        public required double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {From} | {To} | {Amount}";
        }
    }
}
