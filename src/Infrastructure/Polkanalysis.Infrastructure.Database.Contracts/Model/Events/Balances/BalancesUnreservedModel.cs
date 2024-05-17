using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    public class BalancesUnreservedModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesUnreservedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string accountAddess, double unreservedAmount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddess = accountAddess;
            this.UnreservedAmount = unreservedAmount;
        }

        public string AccountAddess { get; set; }
        public double UnreservedAmount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddess} | {UnreservedAmount}";
        }
    }
}