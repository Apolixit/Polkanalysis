using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping
{
    public class MythosMapping : CommonMapping
    {
        public MythosMapping(ILogger<MythosMapping> logger) : base(logger)
        {
        }
    }
}
