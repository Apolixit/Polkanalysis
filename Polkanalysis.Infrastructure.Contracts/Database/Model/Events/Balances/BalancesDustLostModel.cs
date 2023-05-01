using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances
{
    /// <summary>
    /// An account was removed whose balance was non-zero but below ExistentialDeposit, resulting in an outright loss.
    /// </summary>
    public class BalancesDustLostModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesDustLostModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
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
