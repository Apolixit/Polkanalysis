using Polkanalysis.Domain.Helper.Enumerables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Helper
{
    public class EnumerableExtensionTest
    {
        [Test]
        public async Task ExtendEnumerable_WithThreeMethod_ShouldSucceedAsync()
        {
            var minSleepAsync = 1000;
            var maxSleepAsync = 2000;
            var timeSpendForEachNonWaitingCall = 500;
            // Let's start with a simple id list
            var ids = Enumerable.Range(0, 10);

            // For each element of the list, we add a random name with async method
            var addNamesToIdsAsync = (int id) => Task.Run(() =>
            {
                Thread.Sleep(minSleepAsync);
                return Faker.Name.FullName();
            });

            // For each element of the list, we add a random email with an immediately waitable method
            var addEmailToIdsSync = async (int id) => await Task.Run(() =>
            {
                Thread.Sleep(timeSpendForEachNonWaitingCall);
                return Faker.Internet.Email($"test_{id}");
            });

            // And we add a phone number with async method
            var addPhoneNumberToIdsAsync = (int id) => Task.Run(() =>
            {
                Thread.Sleep(maxSleepAsync);
                return Faker.Phone.Number();
            });

            var extendedIds = ids
                .ExtendWith((id) => addNamesToIdsAsync(id))
                .ExtendWith((id) => addEmailToIdsSync(id))
                .ExtendWith((id) => addPhoneNumberToIdsAsync(id));

            foreach (var extendedId in extendedIds.GetExendedList())
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var res = await extendedIds.WaitAndReturnAsync(extendedId);
                stopWatch.Stop();
                
                var millisecondElapsed = stopWatch.Elapsed.TotalMilliseconds;
                Console.WriteLine($"Id = {extendedId.Item1} elapsed time = {millisecondElapsed}");

                //Assert.That(res, Is.Not.Null);
            }
            Assert.Pass();
        }

        private Task<string> generateRandomNameAsync()
        {
            return Task.Run(Faker.Name.FullName);
        }
    }
}
