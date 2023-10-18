using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session.Enums
{
    public enum Error
    {

        InvalidProof = 0,

        NoAssociatedValidatorId = 1,

        DuplicatedKey = 2,

        NoKeys = 3,

        NoAccount = 4,
    }

    /// <summary>
    /// >> 514 - Variant[pallet_session.pallet.Error]
    /// Error for the session pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
