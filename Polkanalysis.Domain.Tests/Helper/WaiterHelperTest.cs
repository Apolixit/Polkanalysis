using Polkanalysis.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Helper
{
    public class WaiterHelperTest
    {
        [Test]
        public async Task WaiterHelper_ShouldParalelizeTask_ShouldWorkAsync()
        {
            int minSleep = 2000;
            int maxSleep = 5000;

            Func<Task<string>> f1 = () => Task.Run(() =>
            {
                Thread.Sleep(minSleep);
                return "f1 finished";
            });

            Func<Task<string>> f2 = () => Task.Run(() =>
            {
                Thread.Sleep(maxSleep);
                return "f2 finished";
            });

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            (_, _) = await WaiterHelper.WaitAndReturnAsync(f1(), f2());
            stopWatch.Stop();

            var millisecondElapsed = stopWatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"WaiterHelper.WaitAndReturnAsync elapsed time = {millisecondElapsed} ms");

            Assert.That(millisecondElapsed, Is.LessThanOrEqualTo(maxSleep + 100));
        }
    }
}
