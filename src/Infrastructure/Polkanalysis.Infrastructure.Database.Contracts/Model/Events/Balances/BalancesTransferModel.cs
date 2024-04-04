using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    /// <summary>
    /// Transfer succeeded.
    /// </summary>
    public class BalancesTransferModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesTransferModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string from, string to, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            From = from;
            To = to;
            Amount = amount;
        }

        public required string From { get; set; }

        public required string To { get; set; }

        public required double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {From} | {To} | {Amount}";
        }
    }
}
