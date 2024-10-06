using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums
{
    [DomainMapping("pallet_identity/pallet")]
    public enum Event
    {

        IdentitySet = 0,

        IdentityCleared = 1,

        IdentityKilled = 2,

        JudgementRequested = 3,

        JudgementUnrequested = 4,

        JudgementGiven = 5,

        RegistrarAdded = 6,

        SubIdentityAdded = 7,

        SubIdentityRemoved = 8,

        SubIdentityRevoked = 9,
    }

    /// <summary>
    /// >> 77 - Variant[pallet_identity.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event,
        SubstrateAccount,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U32>,
        BaseTuple<SubstrateAccount, U32>,
        BaseTuple<SubstrateAccount, U32>,
        U32,
        BaseTuple<SubstrateAccount, SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, SubstrateAccount, U128>>
    {
    }
}
