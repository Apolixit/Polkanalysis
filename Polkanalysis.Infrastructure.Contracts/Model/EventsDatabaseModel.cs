using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Model
{
    public class EventsDatabaseModel
    {
        public string BlockchainName { get; set; } = string.Empty;
        public int BlockId { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
    }
}
