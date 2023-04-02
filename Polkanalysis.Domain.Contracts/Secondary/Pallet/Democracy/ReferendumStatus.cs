using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Enum.FrameSupport;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Democracy
{
    public class ReferendumStatus : BaseType
    {
        public ReferendumStatus() { }

        public ReferendumStatus(U32 end, EnumBounded proposal, EnumVoteThreshold threshold, U32 delay, Tally tally)
        {
            Create(end, proposal, threshold, delay, tally);
        }

        public void Create(U32 end, EnumBounded proposal, EnumVoteThreshold threshold, U32 delay, Tally tally)
        {
            End = end;
            Proposal = proposal;
            Threshold = threshold;
            Delay = delay;
            Tally = tally;

            Bytes = Encode();
            TypeSize = End.TypeSize + Proposal.TypeSize + Threshold.TypeSize + Delay.TypeSize + Tally.TypeSize;
        }
        public U32 End { get; set; }
        public EnumBounded Proposal { get; set; }
        public EnumVoteThreshold Threshold { get; set; }
        public U32 Delay { get; set; }
        public Tally Tally;

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(End.Encode());
            result.AddRange(Proposal.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Delay.Encode());
            result.AddRange(Tally.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            End = new U32();
            End.Decode(byteArray, ref p);
            Proposal = new EnumBounded();
            Proposal.Decode(byteArray, ref p);
            Threshold = new EnumVoteThreshold();
            Threshold.Decode(byteArray, ref p);
            Delay = new U32();
            Delay.Decode(byteArray, ref p);
            Tally = new Tally();
            Tally.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
