using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    public class InvalidDataFromSystemParachainException : Exception
    {
        public uint BlockNumber { get; set; }
        public InvalidDataFromSystemParachainException(string message, uint blockNumber) : base(message) {
            BlockNumber = blockNumber;
        }
    }
}
