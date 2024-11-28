using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsTransferApprovedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsTransferApprovedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, string owner, string @delegate, uint deadline) : this(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent, collection, item, owner, @delegate)
        {
            this.Deadline = deadline;
        }

        [SetsRequiredMembers]
        public NftsTransferApprovedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, string owner, string @delegate) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.Owner = owner;
            this.Delegate = @delegate;
            this.Deadline = default;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);
        public string Owner { get; set; }
        public string Delegate { get; set; }
        public uint Deadline { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue} | {Owner} | {Delegate} | {Deadline}";
        }
    }
}