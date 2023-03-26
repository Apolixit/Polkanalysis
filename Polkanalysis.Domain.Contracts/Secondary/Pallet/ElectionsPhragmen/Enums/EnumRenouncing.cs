using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ElectionsPhragmen.Enums
{
    public enum Renouncing
    {

        Member = 0,

        RunnerUp = 1,

        Candidate = 2,
    }

    /// <summary>
    /// >> 242 - Variant[pallet_elections_phragmen.Renouncing]
    /// </summary>
    public sealed class EnumRenouncing : BaseEnumExt<Renouncing, BaseVoid, BaseVoid, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
