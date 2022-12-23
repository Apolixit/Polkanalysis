using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Exception
{
    public class HashException : SubstrateException
    {
        public HashException(string? message) : base(message) { }
    }
}
