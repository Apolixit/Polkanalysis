using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public class EnumerableContextT1<T, T1>
    {
        public EnumerableContextT1(List<(T, Task<T1>)> initialList)
        {
            InitialList = initialList;
        }

        private List<(T, Task<T1>)> InitialList { get; set; }

        /// <summary>
        /// Extends each item of the list with a new property given by a function
        /// </summary>
        /// <typeparam name="T2">Element type of the second extension method</typeparam>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public EnumerableContextT2<T, T1, T2> ExtendWith<T2>(Func<T, Task<T2>> behavior)
        {
            List<(T, Task<T1>, Task<T2>)> extendedList = new List<(T, Task<T1>, Task<T2>)>();
            foreach (var elem in InitialList)
            {
                extendedList.Add((elem.Item1, elem.Item2, behavior(elem.Item1)));
            }

            return new EnumerableContextT2<T, T1, T2>(extendedList);
        }

        public IEnumerable<(T, Task<T1>)> GetExendedList()
        {
            return InitialList;
        }

        public async Task<IEnumerable<(T, T1)>> WaitAllAndGetResultAsync()
        {
            await Task.WhenAll(InitialList.Select(x => x.Item2));
            
            return InitialList.Select(x => (x.Item1, x.Item2.Result));
        }

        public async Task<T1> WaitAndReturnAsync((T, Task<T1>) elem)
        {
            return await elem.Item2;
        }
    }
}
