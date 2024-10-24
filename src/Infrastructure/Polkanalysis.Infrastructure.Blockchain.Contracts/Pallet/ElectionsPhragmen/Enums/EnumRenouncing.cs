using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ElectionsPhragmen.Enums
{
    [DomainMapping("pallet_elections_phragmen")]
    public enum Renouncing
    {

        Member = 0,

        RunnerUp = 1,

        Candidate = 2,
    }

    /// <summary>
    /// >> 242 - Variant[pallet_elections_phragmen.Renouncing]
    /// </summary>
    public sealed class EnumRenouncing : BaseEnumExt<Renouncing, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
