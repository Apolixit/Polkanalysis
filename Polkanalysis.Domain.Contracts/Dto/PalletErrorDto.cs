using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts
{
    public class PalletErrorDto
    {
        public string PalletName { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
