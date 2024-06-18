using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsPaidOutModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsPaidOutModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string member, uint pool_id, double payout) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Member = member;
            this.Pool_id = pool_id;
            this.Payout = payout;
        }

        public string Member { get; set; }
        public uint Pool_id { get; set; }
        public double Payout { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Member} | {Pool_id} | {Payout}";
        }
    }
}