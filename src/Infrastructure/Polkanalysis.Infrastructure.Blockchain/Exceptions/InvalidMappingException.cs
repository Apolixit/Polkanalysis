using Polkanalysis.Domain.Contracts.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    public class InvalidMappingException : SubstrateException
    {
        public InvalidMappingException(string? message) : base(message) { }
    }
}
