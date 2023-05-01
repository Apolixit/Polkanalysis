using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events.System
{
    public class SystemNewAccountModel : EventModel
    {
        [SetsRequiredMembers]
        public SystemNewAccountModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent, string account) : base(blockchainName, blockId, blockDate, eventId, moduleName, moduleEvent)
        {
            Account = account;
        }

        public required string Account { get; set; }

        public override string ToString()
        {
            return $"{BlockchainName} | {BlockId} | {BlockDate} | {EventId} | {ModuleName} | {ModuleEvent} | {Account}";
        }
    }
}
