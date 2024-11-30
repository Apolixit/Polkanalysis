using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsTransferredModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsTransferredModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string item, string from, string to) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Item = item;
            this.From = from;
            this.To = to;
        }

        public double Collection { get; set; }
        public string Item { get; set; }
        public BigInteger ItemValue() => BigInteger.Parse(Item);
        public string From { get; set; }
        public string To { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {ItemValue} | {From} | {To}";
        }
    }
}