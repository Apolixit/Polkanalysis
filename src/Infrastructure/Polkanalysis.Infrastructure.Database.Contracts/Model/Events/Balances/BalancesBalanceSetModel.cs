using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    public class BalancesBalanceSetModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesBalanceSetModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string rootAccount, double amount1, double amount2) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.RootAccount = rootAccount;
            this.Amount1 = amount1;
            this.Amount2 = amount2;
        }

        public string RootAccount { get; set; }
        public double Amount1 { get; set; }
        public double Amount2 { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {RootAccount} | {Amount1} | {Amount2}";
        }
    }
}