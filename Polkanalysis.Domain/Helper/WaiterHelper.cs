using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Helper
{
    /// <summary>
    /// Helper to wait several asynchronous calls and returns them when all are ready
    /// </summary>
    public static class WaiterHelper
    {
        public static async Task<(T1, T2)> WaitAndReturnAsync<T1, T2>(
            Task<T1> t1, Task<T2> t2) 
            => (await t1, await t2);

        public static async Task<(T1, T2, T3)> WaitAndReturnAsync<T1, T2, T3>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3) 
            => (await t1, await t2, await t3);

        public static async Task<(T1, T2, T3, T4)> WaitAndReturnAsync<T1, T2, T3, T4>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4) 
            => (await t1, await t2, await t3, await t4);

        public static async Task<(T1, T2, T3, T4, T5)> WaitAndReturnAsync<T1, T2, T3, T4, T5>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5) 
            => (await t1, await t2, await t3, await t4, await t5);

        public static async Task<(T1, T2, T3, T4, T5, T6)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6) 
            => (await t1, await t2, await t3, await t4, await t5, await t6);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7, T8>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7, Task<T8> t8) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7, await t8);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7, Task<T8> t8, Task<T9> t9) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7, await t8, await t9);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7, Task<T8> t8, Task<T9> t9, Task<T10> t10) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7, await t8, await t9, await t10);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7, Task<T8> t8, Task<T9> t9, Task<T10> t10, Task<T11> t11) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7, await t8, await t9, await t10, await t11);

        public static async Task<(T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> WaitAndReturnAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7, Task<T8> t8, Task<T9> t9, Task<T10> t10, Task<T11> t11, Task<T12> t12) 
            => (await t1, await t2, await t3, await t4, await t5, await t6, await t7, await t8, await t9, await t10, await t11, await t12);
    }
}
