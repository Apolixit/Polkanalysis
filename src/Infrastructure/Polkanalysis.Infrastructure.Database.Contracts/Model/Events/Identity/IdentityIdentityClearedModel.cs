﻿using System.Diagnostics.CodeAnalysis;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity
{
    public class IdentityIdentityClearedModel : EventModel
    {
        [SetsRequiredMembers]
        public IdentityIdentityClearedModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string accountAddress, double amount) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            this.AccountAddress = accountAddress;
            this.Amount = amount;
        }

        public string AccountAddress { get; set; }
        public double Amount { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {AccountAddress} | {Amount}";
        }
    }
}