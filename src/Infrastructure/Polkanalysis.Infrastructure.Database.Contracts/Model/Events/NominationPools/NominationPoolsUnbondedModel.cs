using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsUnbondedModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsUnbondedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string member, uint pool_id, double balance, double points, uint era) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Member = member;
            this.Pool_id = pool_id;
            this.Balance = balance;
            this.Points = points;
            this.Era = era;
        }

        public string Member { get; set; }
        public uint Pool_id { get; set; }
        public double Balance { get; set; }
        public double Points { get; set; }
        public uint Era { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Member} | {Pool_id} | {Balance} | {Points} | {Era}";
        }
    }
}