using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core.Map;
using Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;

namespace Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums
{
    public class EventRecord : BaseType
    {
        public EventRecord() { }

        public EventRecord(EnumPhase phase, EnumRuntimeEvent @event, BaseVec<Hash> topics)
        {
            Create(phase, new Maybe<EnumRuntimeEvent>(@event), topics);
        }

        public EventRecord(EnumPhase phase, Maybe<EnumRuntimeEvent> maybeEvent, BaseVec<Hash> topics)
        {
            Create(phase, maybeEvent, topics);
        }

        public void Create(EnumPhase phase, Maybe<EnumRuntimeEvent> maybeEvent, BaseVec<Hash> topics)
        {
            Phase = phase;
            Event = maybeEvent;
            Topics = topics;

            Bytes = Encode();
            TypeSize = Phase.TypeSize + Event.TypeSize + Topics.TypeSize;
        }

        public EnumPhase Phase { get; set; }
        public Maybe<EnumRuntimeEvent> Event { get; set; }
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
            Event = new Maybe<EnumRuntimeEvent>();
            Event.Decode(byteArray, ref p);
            Topics = new BaseVec<Hash>();
            Topics.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
