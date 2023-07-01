using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public class EnumerableContextT0<T>
    {
        public EnumerableContextT0(IEnumerable<T> initialList)
        {
            InitialList = initialList;
        }

        private IEnumerable<T> InitialList { get; set; }

        public EnumerableContextT1<T, T1> ExtendWith<T1>(Func<T, Task<T1>> behavior)
        {
            List<(T, Task<T1>)> extendedList = new List<(T, Task<T1>)>();

            foreach(var elem in InitialList)
            {
                extendedList.Add((elem, behavior(elem)));
            }

            return new EnumerableContextT1<T, T1>(extendedList);
        }

        public IEnumerable<T> GetExendedList()
        {
            return InitialList;
        }
    }
}
