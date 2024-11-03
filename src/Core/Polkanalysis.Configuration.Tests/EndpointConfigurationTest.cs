using Polkanalysis.Configuration.Extensions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using System.Configuration;

namespace Polkanalysis.Configuration.Tests
{
    public class EndpointConfigurationTest
    {
        [Test]
        public void ValidAppSettings_ShouldCreateNewConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.Endpoints, Has.Count.GreaterThan(0));

            var firstBlockchain = substrateEndpoint.Endpoints[0];
            Assert.That(firstBlockchain.BlockchainName, Is.EqualTo("Polkadot"));

            Assert.That(firstBlockchain.Uris, expression: Has.Count.GreaterThan(0));
            var firstEndpoint = firstBlockchain.Uris[0];
            Assert.That(firstEndpoint.Name, Is.EqualTo("Allnodes"));
            Assert.That(firstEndpoint.Uri.OriginalString, Is.EqualTo("wss://polkadot-rpc.publicnode.com"));
        }

        [Test]
        public void GetEndpoint_WithValidBlockchainName_ShouldSelectFirstByDefault()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.GetEndpoint("Polkadot").Uri.OriginalString, Is.EqualTo("wss://polkadot-rpc.publicnode.com"));
        }

        [Test]
        public void GetEndpoint_WithInvalidBlockchainName_ShouldSelectFirstByDefault()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.Throws<InvalidOperationException>(() => substrateEndpoint.GetEndpoint("Pwet"));
        }

        [Test]
        public void GetEndpointByProviderName_WithValidBlockchainNameAndProviderName_ShouldSelectIt()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.GetEndpointByProviderName("Polkadot", "Dwellir").Uri.OriginalString, Is.EqualTo("wss://polkadot-rpc.dwellir.com"));
        }

        [Test]
        public void GetNextEndpoint_WithValidBlockchainName_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.GetNextEndpoint("Polkadot", "wss://polkadot-rpc.dwellir.com").Uri.OriginalString, Is.EqualTo("wss://dot-rpc.stakeworld.io"));
        }

        [Test]
        public void GetNextEndpoint_WhenThisIsTheLastOne_ShouldLoopToTheFirst()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.GetNextEndpoint("Polkadot", "wss://dot-rpc.stakeworld.io").Uri.OriginalString, Is.EqualTo("wss://polkadot-rpc.publicnode.com"));
        }

        [Test]
        public void nullAppSettings_ShouldFailed()
        {
            Assert.Throws<ConfigurationErrorsException>(() => new SubstrateEndpoint(null!));
        }

        [Test]
        public void EmptyAppSettings_ShouldFailed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Endpoint/appsettings_empty.json", false)
                .Build();

            Assert.Throws<ConfigurationErrorsException>(() => new SubstrateEndpoint(config));
        }
    }
}