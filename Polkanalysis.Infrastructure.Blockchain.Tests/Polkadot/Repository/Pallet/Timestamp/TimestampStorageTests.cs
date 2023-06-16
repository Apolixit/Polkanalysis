using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Timestamp
{
    public class TimestampStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task Now_ShouldWorkAsync(U64 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Timestamp.NowAsync);
        }

        [Test]
        public async Task NowNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Timestamp.NowAsync);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DidUpdate_ShouldWorkAsync(bool expectedResult)
        {
            await MockStorageCallAsync(new Bool(expectedResult), _substrateRepository.Storage.Timestamp.DidUpdateAsync);
        }

        [Test]
        public async Task DidUpdateNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Timestamp.DidUpdateAsync);
        }
    }
}
