using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper.Enumerables
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Extends each item of the list with a new property given by a function
        /// This is usually used to extend a list of objects with a new property with asynchronous call
        /// </summary>
        /// <typeparam name="T">Element type of the initial list</typeparam>
        /// <typeparam name="T1">Element type of the first extension method</typeparam>
        /// <param name="initialList"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public static EnumerableContextT1<T, T1> ExtendWith<T ,T1>(this IEnumerable<T> initialList, Func<T, Task<T1>> behavior)
        {
            List<(T, Task<T1>)> extendedList = new List<(T, Task<T1>)>();

            foreach (var elem in initialList)
            {
                extendedList.Add((elem, behavior(elem)));
            }

            return new EnumerableContextT1<T, T1>(extendedList);
        }
    }
}
