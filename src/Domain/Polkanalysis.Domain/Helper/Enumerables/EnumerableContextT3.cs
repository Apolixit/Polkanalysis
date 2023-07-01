using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public class EnumerableContextT3<T, T1, T2, T3>
    {
        public EnumerableContextT3(List<(T, Task<T1>, Task<T2>, Task<T3>)> initialList)
        {
            InitialList = initialList;
        }

        private List<(T, Task<T1>, Task<T2>, Task<T3>)> InitialList { get; set; }

        public EnumerableContextT4<T, T1, T2, T3, T4> ExtendWith<T4>(Func<T, Task<T4>> behavior)
        {
            List<(T, Task<T1>, Task<T2>, Task<T3>, Task<T4>)> extendedList = new List<(T, Task<T1>, Task<T2>, Task<T3>, Task<T4>)>();

            foreach (var elem in InitialList)
            {
                extendedList.Add((elem.Item1, elem.Item2, elem.Item3, elem.Item4, behavior(elem.Item1)));
            }

            return new EnumerableContextT4<T, T1, T2, T3, T4>(extendedList);
        }

        /// <summary>
        /// Remove it and make this class implement IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(T, Task<T1>, Task<T2>, Task<T3>)> GetExendedList()
        {
            return InitialList;
        }

        public async Task<(T1, T2, T3)> WaitAndReturnAsync((T, Task<T1>, Task<T2>, Task<T3>) elem)
        {
            return await WaiterHelper.WaitAndReturnAsync(t1: elem.Item2, t2: elem.Item3, t3: elem.Item4);
        }
    }
}
