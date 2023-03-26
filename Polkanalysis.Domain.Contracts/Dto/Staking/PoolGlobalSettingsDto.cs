using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Staking
{
    public class PoolGlobalSettingsDto
    {
        /// <summary>
        /// Number of current active pool
        /// </summary>
        public required uint ActivePoolNumber { get; set; }

        /// <summary>
        /// Maximum member in a pool
        /// Can be nullable if no maximim has been set
        /// </summary>
        public required uint? MaximumMemberPerPool { get; set; }

        /// <summary>
        /// Minimum of token to join pool
        /// </summary>
        public required double MinimumJoinPool { get; set; }

        /// <summary>
        /// Minimum of token to create a new pool
        /// </summary>
        public required double MinimumCreatePool { get; set; }
        
        /// <summary>
        /// Maximum pool that can exists
        /// Can be nullable if no maximum has been set
        /// </summary>
        public required uint? MaximumPoolNumber { get; set; }
    }
}
