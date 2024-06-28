using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances
{
    public class BalancesReservedModel : EventModel
    {
        [SetsRequiredMembers]
        public BalancesReservedModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, string accountAddress, double reservedAmount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddress = accountAddress;
            this.ReservedAmount = reservedAmount;
        }

        public string AccountAddress { get; set; }
        public double ReservedAmount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddress} | {ReservedAmount}";
        }
    }
}