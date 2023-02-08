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
        public uint Age { get; set; }
        public uint CreatedAt { get; set; }
        public EnumPvfCheckCause Causes { get; set; }
    }
}
