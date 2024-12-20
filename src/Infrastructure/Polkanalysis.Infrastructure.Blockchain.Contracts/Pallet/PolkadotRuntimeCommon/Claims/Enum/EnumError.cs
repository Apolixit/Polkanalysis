﻿using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeCommon.Claims.Enum
{
    [DomainMapping("polkadot_runtime_common/claims/pallet")]
    public enum Error
    {

        InvalidEthereumSignature = 0,

        SignerHasNoClaim = 1,

        SenderHasNoClaim = 2,

        PotUnderflow = 3,

        InvalidStatement = 4,

        VestedBalanceExists = 5,
    }

    /// <summary>
    /// >> 561 - Variant[polkadot_runtime_common.claims.pallet.Error]
    /// 
    ///			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    ///			of this pallet.
    ///			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
