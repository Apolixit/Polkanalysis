using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.WhiteList.Enums
{
    public enum Error
    {
        UnavailablePreImage = 0,
        UndecodableCall = 1,
        InvalidCallWeightWitness = 2,
        CallIsNotWhitelisted = 3,
        CallAlreadyWhitelisted = 4
    }

    /// <summary>
    /// >> 15359 - Variant[pallet_whitelist.pallet.Error]
    /// 
    /// 			Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/)
    /// 			of this pallet.
    /// 			
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
