using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Scan.Versionning;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Common.PalletVersion
{
    public class ScanPalletTest
    {
        private ScanAssemblyPalletVersion _scan;

        [SetUp]
        public void Setup()
        {
            _scan = new ScanAssemblyPalletVersion(Substitute.For<ILogger<ScanAssemblyPalletVersion>>());
        }

        //[Test]
        //public void ScanAllPallet_ShouldSuceed()
        //{
        //    var res = _scan.Scan();
        //    Assert.That(res, Is.Not.Null);
        //    Assert.That(res.Count, Is.GreaterThan(0));
        //}

        [Test, Ignore("Outdated")]
        public void ScanAllPalletAttribute_ShouldSuceed()
        {
            var res = _scan.ScanAttribute();
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Count, Is.GreaterThan(0));
        }

        [Test, Ignore("Outdated")]
        public void ScanAllPallet_WithInvalidAssemblyName_ShouldFail()
        {
            _scan.SearchingAssembly = "Fake.Assembly.Name";

            Assert.Throws<InvalidOperationException>(() => _scan.ScanAttribute());
        }
    }
}
