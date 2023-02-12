using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
{
    public class PvfCheckActiveVoteState
    {
        public object VotesAccept { get; set; }
        public object VotesReject { get; set; }
        public U32 Age { get; set; }
        public U32 CreatedAt { get; set; }
        public EnumPvfCheckCause Causes { get; set; }
    }
}
