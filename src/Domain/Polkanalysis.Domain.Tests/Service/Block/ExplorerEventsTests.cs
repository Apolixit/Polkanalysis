using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Tests.Service.Block
{
    public class ExplorerEventsTests
    {
        protected IExplorerService _explorerService;
        protected ISubstrateService _substrateService;
        protected ISubstrateDecoding _substrateDecoding;
        public ExplorerEventsTests() {
            _substrateService = Substitute.For<ISubstrateService>();
            _substrateDecoding = new SubstrateDecoding(Substitute.For<INodeMapping>(),
                                                       _substrateService,
                                                       Substitute.For<IPalletBuilder>(),
                                                       Substitute.For<ILogger<SubstrateDecoding>>());

            _explorerService = new ExplorerService(_substrateService,
                                                   _substrateDecoding,
                                                   Substitute.For<IAccountService>(),
                                                   Substitute.For<ILogger<ExplorerService>>(), 
                                                   Substitute.For<ICoreService>());
        }

        [Test]
        [TestCase("0x080210082DF3BC5411EFA7040000000000000000C2CA026411EFA70400000000000000000000000000000000620B433D5517020000")]
        public async Task ValidEvent_ShouldReturnDtoAsync(string eventHex)
        {
            var blockHash = "0x4b64bacb0676f06aa9372234abd6bb0d99ae6c2b01d306027d8fb5132faa3953";

            var eventMock = new BaseVec<EventRecord>();
            eventMock.Create(eventHex);
            _substrateService.At(Arg.Any<Hash>()).Storage.System.EventsAsync(CancellationToken.None).Returns(eventMock);

            _substrateService.Rpc.Chain.GetBlockAsync(Arg.Any<Hash>(), CancellationToken.None).Returns(
                new TempOldBlockData(
                    new TempOldBlock() { 
                        Header = new Substrate.NetApi.Model.Rpc.Header() { 
                            Number = new U64(1_000_000) 
                        } 
                    }, null)
                );

            var dto = await _explorerService.GetEventsAsync(blockHash, CancellationToken.None);

            Assert.That(dto.Count, Is.EqualTo(2));
        }
    }
}
