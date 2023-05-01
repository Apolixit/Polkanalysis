using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances
{
    /// <summary>
    /// Some balance was reserved (moved from free to reserved).
    /// </summary>
    public class BalancesReservedModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesReservedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account, double reservedAmount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            Account = account;
            ReservedAmount = reservedAmount;
        }

        public required string Account { get; set; }
        public required double ReservedAmount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Account} | {ReservedAmount}";
        }
    }
}
