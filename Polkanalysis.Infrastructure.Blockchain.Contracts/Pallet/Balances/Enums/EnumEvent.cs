using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    public enum Event
    {

        Endowed = 0,

        DustLost = 1,

        Transfer = 2,

        BalanceSet = 3,

        Reserved = 4,

        Unreserved = 5,

        ReserveRepatriated = 6,

        Deposit = 7,

        Withdraw = 8,

        Slashed = 9,
    }

    public sealed class EnumEvent : BaseEnumExt<Event,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, SubstrateAccount, U128, EnumBalanceStatus>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>>
    {
    }
}
