using Ajuna.NetApi.Model.Types.Base;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Tests.Block
{
    public class ExplorerBlockTests : ExplorerRepositoryTests
    {
        [Test]
        public void InvalidBlockInput_ShouldThrowError()
        {

            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetBlockDetailsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetEventsAsync("invalidBlockHash", CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetExtrinsicsAsync("invalidBlockHash", CancellationToken.None));

            _substrateService.Client.InvokeAsync<Hash>("chain_getBlockHash", Arg.Any<object>(), CancellationToken.None).Returns(new Hash());

            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetBlockDetailsAsync(100, CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetEventsAsync(100, CancellationToken.None));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await _blockRepository.GetExtrinsicsAsync(100, CancellationToken.None));
        }
    }
}
