using Ajuna.NetApi.Model.Types.Base;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Repository.Block
{
    public class ExplorerBlockTests : ExplorerRepositoryTests
    {
        [Test]
        [Ignore("Invalid")]
        public void InvalidBlockInput_ShouldThrowError()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetBlockDetailsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetEventsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetExtrinsicsAsync("invalidBlockHash", CancellationToken.None));

            //_substrateService.Api.Core.InvokeAsync<Hash>("chain_getBlockHash", Arg.Any<object>(), CancellationToken.None).Returns(new Hash());
            //_substrateService.Rpc.Chain.GetBlockAsync(Arg.Any<Hash>(), Arg.Any<CancellationToken>()).Returns(new Hash());

            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetBlockDetailsAsync(100, CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetEventsAsync(100, CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _explorerRepository.GetExtrinsicsAsync(100, CancellationToken.None));
        }
    }
}
