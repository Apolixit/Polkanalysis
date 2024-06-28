using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsBondedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsBondedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string member, uint pool_id, double bonded, bool joined) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Member = member;
            this.Pool_id = pool_id;
            this.Bonded = bonded;
            this.Joined = joined;
        }

        public string Member { get; set; }
        public uint Pool_id { get; set; }
        public double Bonded { get; set; }
        public bool Joined { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Member} | {Pool_id} | {Bonded} | {Joined}";
        }
    }
}