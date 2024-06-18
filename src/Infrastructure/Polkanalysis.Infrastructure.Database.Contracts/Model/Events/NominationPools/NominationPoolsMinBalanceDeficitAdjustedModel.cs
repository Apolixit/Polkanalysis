using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsMinBalanceDeficitAdjustedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsMinBalanceDeficitAdjustedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, uint pool_id, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Pool_id = pool_id;
            this.Amount = amount;
        }

        public uint Pool_id { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Pool_id} | {Amount}";
        }
    }
}