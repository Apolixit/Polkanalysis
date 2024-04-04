using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Integration.Tests.Polkadot;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class PalletBuilderTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ILogger<CurrentMetaData> _logger;

        public PalletBuilderTest()
        {
            _logger = Substitute.For<ILogger<CurrentMetaData>>();
            _currentMetaData = new CurrentMetaData(_substrateService, _logger);
            _palletBuilder = new PalletBuilder(_substrateService, _currentMetaData);
        }

        [Test]
        [TestCase("0x0B3CA561D98401")]
        public void BuildCall_PalletTimestampSetTime_ShouldSucceed(string hex)
        {
            var callBuilded = _palletBuilder.BuildCall("Timestamp", new Method(3, 0, Utils.HexToByteArray(hex)));

            var timestampSet = new Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.EnumCall();

            var timestampTarget = new BaseCom<U64>();
            timestampTarget.Create(new CompactInteger(1670094366012));

            timestampSet.Create(Infrastructure.Blockchain.Contracts.Pallet.Timestamp.Enums.Call.set, timestampTarget);

            Assert.That(callBuilded.Encode(), Is.EqualTo(timestampSet.Encode()));
        }
    }
}
