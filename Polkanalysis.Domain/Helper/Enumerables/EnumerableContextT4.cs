using Microsoft.VisualStudio.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public class EnumerableContextT4<T, T1, T2, T3, T4>
    {
        private List<(T, Task<T1>, Task<T2>, Task<T3>, Task<T4>)> InitialList { get; set; }

        public EnumerableContextT4(List<(T, Task<T1>, Task<T2>, Task<T3>, Task<T4>)> initialList)
        {
            InitialList = initialList;
        }

        public IEnumerable<(T, Task<T1>, Task<T2>, Task<T3>, Task<T4>)> GetExendedList()
        {
            return InitialList;
        }

        public async Task<(T1, T2, T3, T4)> WaitAndReturnAsync((T, Task<T1>, Task<T2>, Task<T3>, Task<T4>) elem)
        {
            return await WaiterHelper.WaitAndReturnAsync(t1: elem.Item2, t2: elem.Item3, t3: elem.Item4, t4: elem.Item5);
        }
    }
}
