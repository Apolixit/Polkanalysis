using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo
{
    public class SessionInfo
    {
        public uint ActiveValidatorIndices { get; set; }
        public Hash RandomSeed { get; set; }
        public uint DisputePeriod { get; set; }
        public IEnumerable<Public> Validators { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<Public> DiscoveryKeys { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<Public> AssignmentKeys { get; set; } = Enumerable.Empty<Public>();
        public IEnumerable<IEnumerable<uint>> ValidatorGroups { get; set; }
        public uint NCores { get; set; }
        public uint ZerothDelayTrancheWidth { get; set; }
        public uint RelayVrfModuloSamples { get; set; }
        public uint NDelayTranches { get; set; }
        public uint NoShowSlots { get; set; }
        public uint NeededApprovals { get; set; }
    }
}
