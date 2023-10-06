using Polkanalysis.Domain.Contracts.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    internal class MissingMappingException : SubstrateException
    {
        public MissingMappingException(string? message) : base(message) { }
    }
}
