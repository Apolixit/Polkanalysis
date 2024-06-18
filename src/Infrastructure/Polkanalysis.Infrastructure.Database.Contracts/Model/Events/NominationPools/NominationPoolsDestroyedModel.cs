using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsDestroyedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsDestroyedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, uint pool_id) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Pool_id = pool_id;
        }

        public uint Pool_id { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Pool_id}";
        }
    }
}