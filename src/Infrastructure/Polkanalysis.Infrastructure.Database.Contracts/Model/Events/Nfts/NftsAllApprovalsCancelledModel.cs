using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsAllApprovalsCancelledModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsAllApprovalsCancelledModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, string owner) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Owner = owner;
        }

        public double Collection { get; set; }
        public string Item { get; set; }

        //[NotMapped]
        //public BigInteger Item => BigInteger.Parse(ItemString);
        public string Owner { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Item} | {Owner}";
        }
    }
}