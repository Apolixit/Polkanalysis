using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Staking
{
    public class StakingEraPaidModel : EventModel
    {
        [SetsRequiredMembers]
        public StakingEraPaidModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent, uint era_index, double validator_payout, double remainder) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.Era_index = era_index;
            this.Validator_payout = validator_payout;
            this.Remainder = remainder;
        }

        public uint Era_index { get; set; }
        public double Validator_payout { get; set; }
        public double Remainder { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Era_index} | {Validator_payout} | {Remainder}";
        }
    }
}