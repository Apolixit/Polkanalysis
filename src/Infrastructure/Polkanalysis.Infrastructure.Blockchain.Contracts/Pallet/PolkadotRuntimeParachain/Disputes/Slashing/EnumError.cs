using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Disputes.Slashing
{
    [DomainMapping("polkadot_runtime_parachains/disputes/slashing/pallet")]
    public enum Error
    {
        InvalidKeyOwnershipProof = 0,
        InvalidSessionIndex = 1,
        InvalidCandidateHash = 2,
        InvalidValidatorIndex = 3,
        ValidatorIndexIdMismatch = 4,
        DuplicateSlashingReport = 5
    }

    /// <summary>
    /// >> 16344 - Variant[polkadot_runtime_parachains.disputes.slashing.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
