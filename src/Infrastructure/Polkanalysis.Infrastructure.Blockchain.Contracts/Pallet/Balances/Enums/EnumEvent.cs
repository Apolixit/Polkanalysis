using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums
{
    [DomainMapping("pallet_balances/pallet")]
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
        Minted = 10,
        Burned = 11,
        Suspended = 12,
        Restored = 13,
        Upgraded = 14,
        Issued = 15,
        Rescinded = 16,
        Locked = 17,
        Unlocked = 18,
        Frozen = 19,
        Thawed = 20
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
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        SubstrateAccount,
        U128,
        U128,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>,
        BaseTuple<SubstrateAccount, U128>
        >
    {
    }
}
