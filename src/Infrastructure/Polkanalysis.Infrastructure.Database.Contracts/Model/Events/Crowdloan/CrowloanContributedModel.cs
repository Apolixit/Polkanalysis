using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan
{
    public class CrowloanContributedModel : EventModel
    {
        [SetsRequiredMembers]
        public CrowloanContributedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account, int crowdloanId, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            Account = account;
            CrowdloanId = crowdloanId;
            Amount = amount;
        }

        public required string Account { get; set; }
        public required int CrowdloanId { get; set; }
        public required double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Account} | {CrowdloanId} | {Amount}";
        }
    }
}
