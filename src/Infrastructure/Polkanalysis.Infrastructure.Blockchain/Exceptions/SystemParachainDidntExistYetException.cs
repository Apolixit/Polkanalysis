using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    public class SystemParachainDidntExistYetException : Exception
    {
        public SystemParachainDidntExistYetException(string message) : base(message)
        {

        }
    }
}
