using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan
{
    public class CrowdloanContributedModel : EventModel
    {
        [SetsRequiredMembers]
        public CrowdloanContributedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string accountAddess, uint crowdloanId, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddess = accountAddess;
            this.CrowdloanId = crowdloanId;
            this.Amount = amount;
        }

        public string AccountAddess { get; set; }
        public uint CrowdloanId { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddess} | {CrowdloanId} | {Amount}";
        }
    }
}