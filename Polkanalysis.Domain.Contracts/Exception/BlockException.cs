
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Exception
{
    public class BlockException : SubstrateException
    {
        public BlockException(string? message) : base(message) { }
    }
}
