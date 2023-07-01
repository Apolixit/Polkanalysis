using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public class EnumerableContextT2<T, T1, T2>
    {
        public EnumerableContextT2(List<(T, Task<T1>, Task<T2>)> initialList)
        {
            InitialList = initialList;
        }

        private List<(T, Task<T1>, Task<T2>)> InitialList { get; set; }

        public EnumerableContextT3<T, T1, T2, T3> ExtendWith<T3>(Func<T, Task<T3>> behavior)
        {
            List<(T, Task<T1>, Task<T2>, Task<T3>)> extendedList = new List<(T, Task<T1> , Task<T2>, Task<T3>)>();
            foreach (var elem in InitialList)
            {
                extendedList.Add((elem.Item1, elem.Item2, elem.Item3, behavior(elem.Item1)));
            }

            return new EnumerableContextT3<T, T1 ,T2, T3>(extendedList);
        }

        public IEnumerable<(T, Task<T1>, Task<T2>)> GetExendedList()
        {
            return InitialList;
        }

        public async Task<(T1, T2)> WaitAndReturnAsync((T, Task<T1>, Task<T2>) elem)
        {
            return await WaiterHelper.WaitAndReturnAsync(t1: elem.Item2, t2: elem.Item3);
        }
    }
}
