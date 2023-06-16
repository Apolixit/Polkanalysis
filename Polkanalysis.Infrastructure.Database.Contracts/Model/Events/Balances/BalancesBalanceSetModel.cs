using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    /// <summary>
    /// A balance was set by root.
    /// </summary>
    public class BalancesBalanceSetModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesBalanceSetModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string rootAccount, double amount1, double amount2) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            RootAccount = rootAccount;
            Amount1 = amount1;
            Amount2 = amount2;
        }

        public required string RootAccount { get; set; }
        public required double Amount1 { get; set; }
        public required double Amount2 { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {RootAccount} | {Amount1} | {Amount2}";
        }
    }
}
