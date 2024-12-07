using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    internal class PolkadotServiceTests : PolkadotIntegrationTest
    {
        public static IEnumerable<TestCaseData> MetadataTestCases()
        {
            return FilterTestCase(new List<TestCaseData>
            {
                new TestCaseData("0xc0096358534ec8d21d01d34b836eed476a1c343f8724fa2153dc0725ad797a90"),
                new TestCaseData("0xa15bf122d7a9b2cd07956c3af8f7eda61298aff0a3bd1193018df413d982a4ef"),
                new TestCaseData("0x49a695416fcf55487adf9b9f5808619cee6618bd285a0119a78db60c5a7f3e13"),
                new TestCaseData("0xdab56553594fd489adc085d2f83f3dcb65f5de5b1878325d5547fcf72b6dd6b3"),
                new TestCaseData("0xaff11447ba47e853bcadb73920c0780013e581a0286831eadce0e48bf1db9942"),
                new TestCaseData("0x4eba9b7a60fb063fbd8b9ceb8028c1c7b5a3cc2ea7b0ad703885ce580dee327c"),
                new TestCaseData("0x773e8d8c1fdcbc94d79bb2cdcaf2f7fca5ff869d34c50171fe50ac1640f3e05c"),
                new TestCaseData("0x209d24943d81e5910bfb7a57c8a5c3037c4a434af7c486a536d4f96a2160c9f5"),
                new TestCaseData("0x3eef3df8dd7eedfe6baaed544dcef9c36ee7a142035bd6ae3fd7fd2969ad5933"),
                new TestCaseData("0x4f61e8e6017cce5a10e2de7340061a037895411c19e7bc27f607953d8a56a943"),
                new TestCaseData("0x7cf0e5e3671b02ca341ab439453e1a9ca6616c6e351bdfa8cbb6f5124a8224b8"),
                new TestCaseData("0x349399f6b6481070047626f184d0152699bd02cb71040ef045adefc4f8daec5b"),
                new TestCaseData("0xab6f40697e72d0a4ab0d105145b1ddc1bd8cead0bb1d6a13f4ac1a05508b1882"),
                new TestCaseData("0x78433cba37c0cbc777faad71f27e21094defe24451033dd4d9a0443a1dc291b2"),
                new TestCaseData("0x9a18fb9522d9688eadefb59bf7389fc0deaf219b080a462d6db5ee1d3ec79562"),
                new TestCaseData("0xe187cabcfb9d30b66fae7257f3820b947c89b65e6e20f6ead2af4fd78926825f"),
                new TestCaseData("0xd85988f4f7bc3594200fd5f8e738153260f2ba342b56d9bf4edabf9209c65ae0"),
                new TestCaseData("0x8a0f28f399d3a85643413435e5a001c4ade7b8195eaf7e91f399549f192a56c7"),
                new TestCaseData("0x0b40f111395a0871b1a59da4bd8587bcddf662e3e7b4ba06d8862a44dacf6256"),
                new TestCaseData("0x780cd3091ef9cdc3a94dbcdfa7908d6120f5e037a1e534b4f18249c37005a533"),
                new TestCaseData("0x26fa4c7e27aad01f5a8367aefece17f8c0940b75423628d52a8c07a203bd2458"),
                new TestCaseData("0xd00026d2bdca30cd20f7c361544e9651041107a1fd35ea447d8dfabb5001960f"),
                new TestCaseData("0x766a02e9abe37328ad0dee3a64aad557dd1bade9e9f27849a9cf5838c0e7e6bb"),
                new TestCaseData("0x8a8a7aa9ac863359b2cc609b836e3ebd7086d775c31f8c177f183ed9ffa71fa5"),
                new TestCaseData("0x89f4608b568a05a89737bc826a32f8677f2646a5773312d7dee3a667458e5a98"),
                new TestCaseData("0xddca674d4e6e4935b1e5e81ed697f7ce027c2a9602523424bcc8dee3184e4863"),
                new TestCaseData("0x4b34bd42835a084af0f441c5986d216b18a85abb4d03762096692e6f06365203"),
                new TestCaseData("0x8192df1609d4478d1c1fcf5d39975596a8162d42d745c141c22148b0931708f2")
            });
        }

        [Test]
        [TestCaseSource(nameof(MetadataTestCases))]
        public async Task GetMetadata_ShouldWorkAsync(string hash)
        {

            var metadata = await _substrateService.At(hash).GetMetadataAsync(CancellationToken.None);

            Assert.That(metadata, Is.Not.Null);
            Assert.That(metadata.NodeMetadata, Is.Not.Null);
        }

        [Test]
        public async Task Module_CheckEveryCurrentRuntimeModule_ShouldWorkAsync()
        {
            var metadata = await _substrateService.GetMetadataAsync(CancellationToken.None);

            metadata.NodeMetadata.Modules.Select(x => x.Value).ToList().ForEach(module =>
            {
                Assert.That(module.Name, Is.Not.Null);
            });
        }

        [Test]
        public async Task ConnectToNode_ThenCancel_ShouldWorkAsync()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            var wasConnectedCalled = false;

            await _substrateService.ConnectAsync(CancellationToken.None);
            Assert.That(_substrateService.IsConnected);

            var task = _substrateService.CheckBlockchainStateAsync(isConnected => wasConnectedCalled = isConnected, cancellationTokenSource.Token);

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Assert.That(cancellationTokenSource.IsCancellationRequested, Is.True);
            }
        }

        [Test]
        public void GenesisHash_ShouldSucceed()
        {
            Assert.That(_substrateService.GenesisHash.Value, Is.Not.Empty);
        }

        [Test]
        public void RuntimeVersion_ShouldSucceed()
        {
            Assert.That(_substrateService.RuntimeVersion.SpecName, Is.Not.Empty);
            Assert.That(_substrateService.RuntimeVersion.ImplName, Is.Not.Empty);
            Assert.That(_substrateService.RuntimeVersion.AuthoringVersion, Is.GreaterThan(0));
            Assert.That(_substrateService.RuntimeVersion.TransactionVersion, Is.GreaterThan(0));
        }
    }
}
