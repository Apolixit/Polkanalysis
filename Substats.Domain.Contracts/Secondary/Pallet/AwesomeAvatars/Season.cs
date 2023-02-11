using Substats.Domain.Contracts.Core.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    /// <summary>
    /// AAA season
    /// </summary>
    public class Season
    {
        public required string Name { get; set; }
        public required string Descripion { get; set; }
        public uint EarlyStart { get; set; }
        public uint Start { get; set; }
        public uint End { get; set; }
        public byte MaxVariations { get; set; }
        public byte MaxComponents { get; set; }
        public IEnumerable<EnumRarityTier> Tiers { get; set; } = Enumerable.Empty<EnumRarityTier>();
        public Hash PSingleMint { get; set; }
        public Hash PBatchMint { get; set; }

    }
}
