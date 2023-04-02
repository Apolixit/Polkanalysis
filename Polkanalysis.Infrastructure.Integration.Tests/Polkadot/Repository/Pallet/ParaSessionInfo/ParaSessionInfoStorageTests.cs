using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository.Pallet.ParaSessionInfo
{
    public class ParaSessionInfoStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task AssignmentKeysUnsafe_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.ParaSessionInfo.AssignmentKeysUnsafeAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EarliestStoredSession_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Get data only for last session index
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Sessions_ShouldWorkAsync()
        {
            var earliestSessionIndex = await _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);
            var res = await _substrateRepository.Storage.ParaSessionInfo.SessionsAsync(earliestSessionIndex, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.ActiveValidatorIndices.Value.Length, Is.GreaterThan(1));
        }

        /// <summary>
        /// Get data only for last session index
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AccountKeys_ShouldWorkAsync()
        {
            var earliestSessionIndex = await _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);

            var res = await _substrateRepository.Storage.ParaSessionInfo.AccountKeysAsync(earliestSessionIndex, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Length, Is.GreaterThan(1));
        }
    }
}
