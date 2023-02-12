using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo
{
    public class SessionInfo
    {
        public U32 ActiveValidatorIndices { get; set; }
        public Hash RandomSeed { get; set; }
        public U32 DisputePeriod { get; set; }
        public IEnumerable<Public> Validators { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<Public> DiscoveryKeys { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<Public> AssignmentKeys { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<IEnumerable<U32>> ValidatorGroups { get; set; }
        public U32 NCores { get; set; }
        public U32 ZerothDelayTrancheWidth { get; set; }
        public U32 RelayVrfModuloSamples { get; set; }
        public U32 NDelayTranches { get; set; }
        public U32 NoShowSlots { get; set; }
        public U32 NeededApprovals { get; set; }
    }
}
