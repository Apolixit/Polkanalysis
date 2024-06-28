using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan
{
    public class CrowdloanCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public CrowdloanCreatedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, uint crowdloanId) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.CrowdloanId = crowdloanId;
        }

        public uint CrowdloanId { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {CrowdloanId}";
        }
    }
}