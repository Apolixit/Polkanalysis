using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.ParaSessionInfo.Enums
{
    public enum ExecutorParam
    {
        MaxMemoryPages = 1,
        StackLogicalMax = 2,
        StackNativeMax = 3,
        PrecheckingMaxMemory = 4,
        PvfPrepTimeout = 5,
        PvfExecTimeout = 6,
        WasmExtBulkMemory = 7
    }

    /// <summary>
    /// >> 14208 - Variant[polkadot_primitives.v4.executor_params.ExecutorParam]
    /// </summary>
    public sealed class EnumExecutorParam : BaseEnumExt<ExecutorParam, 
        BaseVoid, 
        Substrate.NetApi.Model.Types.Primitive.U32, 
        Substrate.NetApi.Model.Types.Primitive.U32, 
        Substrate.NetApi.Model.Types.Primitive.U32, 
        Substrate.NetApi.Model.Types.Primitive.U64, 
        BaseTuple<Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v4.EnumPvfPrepTimeoutKind, 
            Substrate.NetApi.Model.Types.Primitive.U64>, 
        BaseTuple<
            Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotPrimitive.v4.EnumPvfExecTimeoutKind, 
            Substrate.NetApi.Model.Types.Primitive.U64>,
        BaseVoid>
    {
    }
}
