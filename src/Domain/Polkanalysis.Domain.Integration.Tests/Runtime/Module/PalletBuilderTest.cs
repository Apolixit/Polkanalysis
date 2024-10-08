using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class PalletBuilderTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly IMetadataService _currentMetaData;
        private readonly ILogger<MetadataService> _logger;

        public PalletBuilderTest()
        {
            _logger = Substitute.For<ILogger<MetadataService>>();
            _currentMetaData = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());

            _palletBuilder = new PalletBuilder(_substrateService, Substitute.For<ILogger<PalletBuilder>>());
        }

        [Test]
        [TestCase("0x5ff1293f4dfbdeb3bd405af3f908846c4d8689d2c78ffbbc3bb8f1008caa62e0", "0x0B3CA561D98401")]
        public void BuildCall_PalletTimestampSetTime_ShouldSucceed(string blockHash, string hex)
        {
            var callBuilded = _palletBuilder.BuildCall(new Hash(blockHash), "Timestamp", new Method(3, 0, Utils.HexToByteArray(hex)));
            Assert.That(callBuilded, Is.Not.Null);

            var timestampSet = new Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.EnumCall();

            var timestampTarget = new BaseCom<U64>();
            timestampTarget.Create(new CompactInteger(1670094366012));

            timestampSet.Create(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set, timestampTarget);

            Assert.That(callBuilded.Encode(), Is.EqualTo(timestampSet.Encode()));
        }
    }
}
