using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Exception
{
    public class SubstrateException : System.Exception
    {
        public SubstrateException(string? message) : base(message) { }
    }
}
