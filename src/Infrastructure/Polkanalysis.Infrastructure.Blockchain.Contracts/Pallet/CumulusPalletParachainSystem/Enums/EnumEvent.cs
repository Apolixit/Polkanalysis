using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.CumulusPalletParachainSystem.Enums
{
    [DomainMapping("cumulus_pallet_parachain_system/pallet")]
    public enum Event
    {
        ValidationFunctionStored = 0,
        ValidationFunctionApplied = 1,
        ValidationFunctionDiscarded = 2,
        DownwardMessagesReceived = 3,
        DownwardMessagesProcessed = 4,
        UpwardMessageSent = 5
    }

    public class EnumEvent : BaseEnumExt<Event, 
        BaseVoid,
        U32,
        BaseVoid,
        U32,
        BaseTuple<Weight, Hash>,
        BaseOpt<FlexibleNameable>>
    {
    }
}
