using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools
{
    public class NominationPoolsWithdrawnModel : EventModel
    {
        [SetsRequiredMembers]
        public NominationPoolsWithdrawnModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string member, uint pool_id, double balance, double points) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Member = member;
            this.Pool_id = pool_id;
            this.Balance = balance;
            this.Points = points;
        }

        public string Member { get; set; }
        public uint Pool_id { get; set; }
        public double Balance { get; set; }
        public double Points { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Member} | {Pool_id} | {Balance} | {Points}";
        }
    }
}