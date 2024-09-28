using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Scan.Versionning;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Common.PalletVersion
{
    public class ActivePalletTest
    {

        private ScanAssemblyPalletVersion _scanPallet;
        private ActivePallets _activePallets { get; set; }

        // Mock class
        [PalletVersion("Polkadot", "MyAwesomePallet", 4, 10)]
        internal class MockScanClass : BaseType
        {
            public override void Decode(byte[] byteArray, ref int p)
            {
                throw new NotImplementedException();
            }

            public override byte[] Encode()
            {
                throw new NotImplementedException();
            }
        }

        [SetUp]
        public void Setup()
        {
            _scanPallet = new ScanAssemblyPalletVersion(Substitute.For<ILogger<ScanAssemblyPalletVersion>>());
            _activePallets = new ActivePallets(_scanPallet, Substitute.For<ILogger<ActivePallets>>());

            _scanPallet.SearchingAssembly = "Infrastructure.Blockchain.Tests";
        }

        [Test]
        public void ValidInput_ShouldReturnPallets()
        {
            var res = _activePallets.GetPallets("Polkadot", 8);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.EqualTo(1));
            Assert.That(res[0].Version.StorageName, Is.EqualTo("MyAwesomePallet"));
        }

        [Test]
        public void EmptyData_ShouldReturnEmpty()
        {
            _scanPallet.SearchingAssembly = "Fake.Project";
            Assert.Throws<InvalidOperationException>(() => _activePallets.GetPallets("Polkadot", 20));
        }

        [Test]
        public void InvalidBlockchainName_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _activePallets.GetPallets("pwet", 10));
        }

        [Test]
        public void InvalidBlockNumber_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _activePallets.GetPallets("Polkadot", 1));
        }


    }
}
