//using System.Diagnostics.CodeAnalysis;

//namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
//{
//    public class NftsOwnershipAcceptanceChangedModel : EventModel
//    {
//        [SetsRequiredMembers]
//        public NftsOwnershipAcceptanceChangedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string who, double? maybe_collection) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
//        {
//            this.Who = who;
//            this.Maybe_collection = maybe_collection.GetValueOrDefault();
//        }

//        public string Who { get; set; }
//        public double Maybe_collection { get; set; }

//        public override string ToString()
//        {
//            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Who} | {Maybe_collection}";
//        }
//    }
//}