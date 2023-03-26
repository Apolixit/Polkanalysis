using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;

namespace Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    /// <summary>
    /// AAA season
    /// </summary>
    public class Season
    {
        public required string Name { get; set; }
        public required string Descripion { get; set; }
        public U32 EarlyStart { get; set; }
        public U32 Start { get; set; }
        public U32 End { get; set; }
        public byte MaxVariations { get; set; }
        public byte MaxComponents { get; set; }
        public IEnumerable<EnumRarityTier> Tiers { get; set; } = Enumerable.Empty<EnumRarityTier>();
        public Hash PSingleMint { get; set; }
        public Hash PBatchMint { get; set; }

    }
}
