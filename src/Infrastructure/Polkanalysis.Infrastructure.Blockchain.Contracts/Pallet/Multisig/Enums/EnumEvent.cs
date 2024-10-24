using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Enum;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Multisig.Enums
{
    [DomainMapping("pallet_multisig/pallet")]
    public enum Event
    {

        NewMultisig = 0,

        MultisigApproval = 1,

        MultisigExecuted = 2,

        MultisigCancelled = 3,
    }

    /// <summary>
    /// >> 81 - Variant[pallet_multisig.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumExt<Event, BaseTuple<SubstrateAccount, SubstrateAccount, NameableSize32>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, NameableSize32>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, NameableSize32, EnumResult>, BaseTuple<SubstrateAccount, Timepoint, SubstrateAccount, NameableSize32>>
    {
    }
}
