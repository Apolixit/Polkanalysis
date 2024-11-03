using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot
{
    internal class PolkadotServiceTests : PolkadotMock
    {
        [Test, Ignore("Todo setup mock")]
        public void TimeQueryable_WithCurentBlockLowerThanQueryableBlock_ShouldThrowException()
        {
            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), Arg.Any<CancellationToken>()).Returns(MockHash);
            _substrateService.Rpc.Chain.GetBlockAsync().Returns(
                new TempNewBlockData(new TempNewBlock() { 
                    Header = new Substrate.NetApi.Model.Rpc.Header() { 
                        Number = new Substrate.NetApi.Model.Types.Primitive.U64(10) 
                    } 
                }, null!)
            );

            Assert.Throws<InvalidOperationException>(() => _substrateService.At(new BlockNumber(20)));
        }
    }
}
