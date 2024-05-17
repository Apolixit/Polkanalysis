using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System
{
    public class SystemNewAccountModel : EventModel
    {
        [SetsRequiredMembers]
        public SystemNewAccountModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string accountAddress) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
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