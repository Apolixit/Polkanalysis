using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan
{
    public class CrowdloanCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public CrowdloanCreatedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, int crowdloanId) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.CrowdloanId = crowdloanId;
        }

        public int CrowdloanId { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {CrowdloanId}";
        }
    }
}