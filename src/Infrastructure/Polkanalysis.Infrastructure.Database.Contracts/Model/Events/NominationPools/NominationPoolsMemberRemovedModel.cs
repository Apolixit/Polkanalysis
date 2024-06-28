using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsMemberRemovedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsMemberRemovedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, uint pool_id, string member) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Pool_id = pool_id;
            this.Member = member;
        }

        public uint Pool_id { get; set; }
        public string Member { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Pool_id} | {Member}";
        }
    }
}