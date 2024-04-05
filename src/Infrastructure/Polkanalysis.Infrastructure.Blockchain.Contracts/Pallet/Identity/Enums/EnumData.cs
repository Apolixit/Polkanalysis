using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums
{
    [DomainMapping("pallet_identity/types")]
    public enum Data
    {

        None = 0,

        Raw0 = 1,

        Raw1 = 2,

        Raw2 = 3,

        Raw3 = 4,

        Raw4 = 5,

        Raw5 = 6,

        Raw6 = 7,

        Raw7 = 8,

        Raw8 = 9,

        Raw9 = 10,

        Raw10 = 11,

        Raw11 = 12,

        Raw12 = 13,

        Raw13 = 14,

        Raw14 = 15,

        Raw15 = 16,

        Raw16 = 17,

        Raw17 = 18,

        Raw18 = 19,

        Raw19 = 20,

        Raw20 = 21,

        Raw21 = 22,

        Raw22 = 23,

        Raw23 = 24,

        Raw24 = 25,

        Raw25 = 26,

        Raw26 = 27,

        Raw27 = 28,

        Raw28 = 29,

        Raw29 = 30,

        Raw30 = 31,

        Raw31 = 32,

        Raw32 = 33,

        BlakeTwo256 = 34,

        Sha256 = 35,

        Keccak256 = 36,

        ShaThree256 = 37,
    }

    /// <summary>
    /// >> 267 - Variant[pallet_identity.types.Data]
    /// </summary>
    public sealed class EnumData : BaseEnumExt<Data, BaseVoid,
        NameableSize0,
        NameableSize1,
        NameableSize2,
        NameableSize3,
        NameableSize4,
        NameableSize5,
        NameableSize6,
        NameableSize7,
        NameableSize8,
        NameableSize9,
        NameableSize10,
        NameableSize11,
        NameableSize12,
        NameableSize13,
        NameableSize14,
        NameableSize15,
        NameableSize16,
        NameableSize17,
        NameableSize18,
        NameableSize19,
        NameableSize20,
        NameableSize21,
        NameableSize22,
        NameableSize23,
        NameableSize24,
        NameableSize25,
        NameableSize26,
        NameableSize27,
        NameableSize28,
        NameableSize29,
        NameableSize30,
        NameableSize31,
        NameableSize32,
        NameableSize32,
        NameableSize32,
        NameableSize32,
        NameableSize32>
    {
        public EnumData() { }

        public EnumData(Data t, IType value2)
        {
            Create(t, value2);
        }

        public string ToHuman()
        {
            if (Value2 is Nameable v2)
            {
                return v2.Display();
            }
            return string.Empty;
        }
    }
}
