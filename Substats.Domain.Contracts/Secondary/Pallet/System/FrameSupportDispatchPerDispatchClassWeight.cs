using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class FrameSupportDispatchPerDispatchClassWeight
    {
        public Weight Normal { get; set; } = new Weight();
        public Weight Operational { get; set; } = new Weight();
        public Weight Mandatory { get; set; } = new Weight();
    }
}
