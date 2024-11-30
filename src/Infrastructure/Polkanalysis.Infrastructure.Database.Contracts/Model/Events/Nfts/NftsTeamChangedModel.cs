using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts
{
    public class NftsTeamChangedModel : EventModel
    {
        [SetsRequiredMembers]
        public NftsTeamChangedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, double collection, string? issuer, string? admin, string? freezer) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Collection = collection;
            this.Issuer = issuer ?? string.Empty;
            this.Admin = admin ?? string.Empty;
            this.Freezer = freezer ?? string.Empty;
        }

        public double Collection { get; set; }
        public string? Issuer { get; set; }
        public string? Admin { get; set; }
        public string? Freezer { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Collection} | {Issuer} | {Admin} | {Freezer}";
        }
    }
}