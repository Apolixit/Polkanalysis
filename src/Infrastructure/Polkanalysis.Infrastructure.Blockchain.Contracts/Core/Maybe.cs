using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core
{
    /// <summary>
    /// Class use to handle unmapped events from NetApiExt
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Maybe<T> : BaseType
        where T : IType, new()
    {
        public Maybe() { }

        public Maybe(T value)
        {
            Value = value;
        }

        public Maybe(T value, IType core) : this(core)
        {
            Value = value;
        }

        public Maybe(IType core)
        {
            Core = core;
        }

        /// <summary>
        /// The mapped value (from Domain)
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// The core value (from ApiExt)
        /// </summary>
        public IType? Core { get; set; }
        public bool HasBeenMapped
            => Value is not null;

        public override int TypeSize
        {
            get
            {
                return HasBeenMapped ? Value!.TypeSize : Core.TypeSize;
            }
            set
            {
                if (HasBeenMapped)
                {
                    Value!.TypeSize = value;
                }
                else
                {
                    Core.TypeSize = value;
                }
            }
        }
        public Type CoreType => Core.GetType();
        public Type DestinationType => typeof(T);

        public override byte[] Encode()
        {
            var result = new List<byte>();

            if (HasBeenMapped)
            {
                result.AddRange(Value!.Encode());
            }
            else
            {
                result.AddRange(Core.Encode());
            }

            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Value = new T();
            Value.Decode(byteArray, ref p);

            //if (HasBeenMapped)
            //{
            //    Mapped = new T();
            //    Mapped.Decode(byteArray, ref p);
            //}
            //else
            //{
            //    throw new InvalidOperationException();
            //}

            TypeSize = p - start;
        }
    }
}
