using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan
{
    public class CrowloanCreatedModel : EventModel
    {
        [SetsRequiredMembers]
        public CrowloanCreatedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, int crowdloanId) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            CrowdloanId = crowdloanId;
        }

        public required int CrowdloanId { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {CrowdloanId}";
        }
    }
}
