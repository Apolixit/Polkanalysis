using Substrate.NetApi.Model.Types.Base;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Exception;

namespace Polkanalysis.Domain.Tests.Service.Block
{
    public class ExplorerBlockTests : ExplorerServiceTests
    {
        [Test]
        public void InvalidBlockHash_ShouldThrowError()
        {
            Assert.ThrowsAsync<BlockException>(async () => await _explorerService.GetBlockDetailsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<BlockException>(async () => await _explorerService.GetEventsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<BlockException>(async () => await _explorerService.GetExtrinsicsAsync("invalidBlockHash", CancellationToken.None));
        }
    }
}
