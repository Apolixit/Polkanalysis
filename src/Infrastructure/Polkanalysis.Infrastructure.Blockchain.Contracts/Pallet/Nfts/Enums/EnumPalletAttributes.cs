using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums
{
    [DomainMapping("pallet_nfts/types")]
    public enum PalletAttributes
    {
        UsedToClaim = 0,
        TransferDisabled = 1
    }

    /// <summary>
    /// >> 4020 - Variant[pallet_nfts.types.PalletAttributes]
    /// </summary>
    public sealed class EnumPalletAttributes : BaseEnumExt<PalletAttributes, IncrementableU256, BaseVoid>
    {
    }
}
