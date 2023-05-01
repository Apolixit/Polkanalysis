using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances
{
    /// <summary>
    /// Some balance was unreserved (moved from reserved to free).
    /// </summary>
    public class BalancesUnreservedModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesUnreservedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account, double unreservedAmount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            Account = account;
            UnreservedAmount = unreservedAmount;
        }

        public required string Account { get; set; }
        public required double UnreservedAmount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Account} | {UnreservedAmount}";
        }
    }
}
