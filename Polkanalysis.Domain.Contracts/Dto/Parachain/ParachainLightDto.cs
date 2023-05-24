using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Parachain
{
    public class ParachainLightDto
    {
        public string Name { get; set; }
        public uint ParachainId { get; set; }
        public int ValidatorCount { get; set; }

        // Replace string by "multiple id"
        public string CrowdloanId { get; set; }
        public LeaseDto Lease { get; set; }

        /// <summary>
        /// Parachain / Parachain / Standalone
        /// </summary>
        public string RegisterStatus { get; set; }
    }
}
