using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substrate.NET.Utils
{
    public static class BaseTupleExtension
    {
        public static ValueTuple<T1, T2> ToTuple<T1, T2>(this BaseTuple<T1, T2> baseTuple) 
            where T1 : IType, new()
            where T2 : IType, new()
        {
            if (baseTuple == null)
                throw new ArgumentNullException($"{nameof(baseTuple)}");

            if (baseTuple.Value == null)
                throw new ArgumentException($"{nameof(baseTuple.Value)}");

            if (baseTuple.Value.Length != 2)
                throw new InvalidOperationException($"{nameof(baseTuple)} invalid count elements");

            return ((T1)baseTuple.Value[0], (T2)baseTuple.Value[1]);
        }

        public static ValueTuple<T1, T2, T3> ToTuple<T1, T2, T3>(this BaseTuple<T1, T2, T3> baseTuple)
            where T1 : IType, new()
            where T2 : IType, new()
            where T3 : IType, new()
        {
            if (baseTuple == null)
                throw new ArgumentNullException($"{nameof(baseTuple)}");

            if (baseTuple.Value == null)
                throw new ArgumentException($"{nameof(baseTuple.Value)}");

            if (baseTuple.Value.Length != 3)
                throw new InvalidOperationException($"{nameof(baseTuple)} invalid count elements");

            return ((T1)baseTuple.Value[0], (T2)baseTuple.Value[1], (T3)baseTuple.Value[1]);
        }

        public static ValueTuple<T1, T2, T3, T4> ToTuple<T1, T2, T3, T4>(this BaseTuple<T1, T2, T3, T4> baseTuple)
            where T1 : IType, new()
            where T2 : IType, new()
            where T3 : IType, new()
            where T4 : IType, new()
        {
            if (baseTuple == null)
                throw new ArgumentNullException($"{nameof(baseTuple)}");

            if (baseTuple.Value == null)
                throw new ArgumentException($"{nameof(baseTuple.Value)}");

            if (baseTuple.Value.Length != 4)
                throw new InvalidOperationException($"{nameof(baseTuple)} invalid count elements");

            return ((T1)baseTuple.Value[0], (T2)baseTuple.Value[1], (T3)baseTuple.Value[2], (T4)baseTuple.Value[3]);
        }
    }
}
