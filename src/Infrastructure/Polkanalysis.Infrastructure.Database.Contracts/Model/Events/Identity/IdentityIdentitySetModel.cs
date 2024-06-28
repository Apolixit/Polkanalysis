using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity
{
    public class IdentityIdentitySetModel : EventModel
    {
        [SetsRequiredMembers]
        public IdentityIdentitySetModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string accountAddress) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddress = accountAddress;
        }

        public string AccountAddress { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddress}";
        }
    }
}