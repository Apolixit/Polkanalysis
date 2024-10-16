using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.DispatchInfo;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Error;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Errors
{
    public class SystemErrorListenerTest : PolkadotIntegrationTest
    {
        private readonly ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            var currentMetadata = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());

            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                _substrateService,
                new PalletBuilder(_substrateService, Substitute.For<ILogger<PalletBuilder>>()),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        public async Task DecodeExtrinsicFail_ShouldSucceedAsync()
        {
            var input = new Substrate.NetApi.Model.Types.Base.BaseTuple<EnumDispatchError, DispatchInfo>();
            input.Create("0x030707000000075C075F360155EE0000");

            var metadata = await _substrateService.At("0xd14d9606068b70847edbe551b38e5e9bbd793d49a93f3c5224b194cc66bb2edf").GetMetadataAsync(CancellationToken.None);
            var node = await _substrateDecode.DecodeAsync(input, metadata, CancellationToken.None);

            Assert.That(node, Is.Not.Null);
        }
    }
}
