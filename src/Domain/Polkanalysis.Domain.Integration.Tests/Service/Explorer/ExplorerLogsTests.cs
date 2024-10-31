using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    internal class ExplorerLogsTests : ExplorerRepositoryTest
    {
        [Test]
        [TestCase(22996447)]
        public async Task DecodingLogs_ShouldWorkAsync(int blockId)
        {
            var hash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber((uint)blockId), CancellationToken.None);
            var blockDetails = await _substrateService.Rpc.Chain.GetBlockAsync(hash, CancellationToken.None);

            var res = await _substrateDecoding.DecodeLogAsync(blockDetails.GetBlock().Header.Digest.Logs, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
