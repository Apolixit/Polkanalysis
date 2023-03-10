using Ajuna.NetApi.Model.Types.Base;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums
{
    public class EventRecord : BaseType
    {
        public EnumPhase Phase { get; set; }
        public EnumRuntimeEvent Event { get; set; }
        public BaseVec<Hash> Topics { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Phase.Encode());
            result.AddRange(Event.Encode());
            result.AddRange(Topics.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Phase = new EnumPhase();
            Phase.Decode(byteArray, ref p);
            Event = new EnumRuntimeEvent();
            Event.Decode(byteArray, ref p);
            Topics = new BaseVec<Hash>();
            Topics.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
