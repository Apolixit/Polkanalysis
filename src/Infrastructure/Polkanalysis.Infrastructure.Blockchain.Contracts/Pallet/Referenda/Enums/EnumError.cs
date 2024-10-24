using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Enums
{
    [DomainMapping("pallet_referenda/pallet")]
    public enum Error
    {
        NotOngoing = 0,
        HasDeposit = 1,
        BadTrack = 2,
        Full = 3,
        QueueEmpty = 4,
        BadReferendum = 5,
        NothingToDo = 6,
        NoTrack = 7,
        Unfinished = 8,
        NoPermission = 9,
        NoDeposit = 10,
        BadStatus = 11,
        PreimageNotExist = 12
    }

    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
