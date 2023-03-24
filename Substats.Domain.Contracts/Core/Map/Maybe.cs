using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Map
{
    public class Maybe<T>
        where T : IType, new()
    {
        public Maybe() { }

        public T Value { get; set; }
        public IType Core { get; set; }
        public bool HasBeenMapped 
            => Value != null;

        public Type CoreType => Core.GetType();
        public Type DestinationType => typeof(T);
    }
}
