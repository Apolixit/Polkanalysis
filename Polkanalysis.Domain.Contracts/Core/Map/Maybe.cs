using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Map
{
    public class Maybe<T> : BaseType
        where T : IType, new()
    {
        public Maybe() { }

        public Maybe(T value) {
            Value = value;
        }

        public T Value { get; set; }
        public IType Core { get; set; }
        public bool HasBeenMapped 
            => Value != null;

        public override int TypeSize {
            get
            {
                return HasBeenMapped ? Value.TypeSize : Core.TypeSize;
            }
            set
            {
                if(HasBeenMapped)
                {
                    Value.TypeSize = value;
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
                result.AddRange(Value.Encode());
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

            if (HasBeenMapped)
            {
                Value = new T();
                Value.Decode(byteArray, ref p);
            }
            else
            {
                throw new InvalidOperationException();
            }

            TypeSize = p - start;
        }
    }
}
