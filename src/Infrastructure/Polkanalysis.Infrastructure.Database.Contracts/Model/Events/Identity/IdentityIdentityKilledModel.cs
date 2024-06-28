using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity
{
    public class IdentityIdentityKilledModel : EventModel
    {
        [SetsRequiredMembers]
        public IdentityIdentityKilledModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string accountAddress, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddress = accountAddress;
            this.Amount = amount;
        }

        public string AccountAddress { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddress} | {Amount}";
        }
    }
}