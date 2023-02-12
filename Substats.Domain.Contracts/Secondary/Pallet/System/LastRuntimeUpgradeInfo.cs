using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class LastRuntimeUpgradeInfo
    {
        public U32 SpecVersion { get; set; }
        public string SpecName { get; set; }
    }
}
