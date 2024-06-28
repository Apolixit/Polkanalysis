using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsCreatedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string depositor, uint pool_id) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Depositor = depositor;
            this.Pool_id = pool_id;
        }

        public string Depositor { get; set; }
        public uint Pool_id { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Depositor} | {Pool_id}";
        }
    }
}