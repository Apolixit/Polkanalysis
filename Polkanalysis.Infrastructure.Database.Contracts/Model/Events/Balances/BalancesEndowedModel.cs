using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    /// <summary>
    /// An account was created with some free balance.
    /// </summary>
    public class BalancesEndowedModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesEndowedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            Account = account;
            Amount = amount;
        }

        public required string Account { get; set; }
        public required double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Account} | {Amount}";
        }
    }
}
