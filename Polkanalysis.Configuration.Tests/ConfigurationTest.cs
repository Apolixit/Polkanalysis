using Polkanalysis.Configuration.Extentions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using System.Configuration;

namespace Polkanalysis.Configuration.Tests
{
    public class ConfigurationTest
    {
        [Test]
        public void ValidAppSettings_ShouldCreateNewConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_polkadot_valid.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(substrateEndpoint.WsEndpointUri, Is.EqualTo(new Uri("wss://rpc.polkadot.io")));
            Assert.That(substrateEndpoint.ApiUri, Is.Null);
            Assert.That(substrateEndpoint.PrometheusUri, Is.Null);
        }

        [Test]
        public void ValidAppSettingsWithFacultative_ShouldCreateNewConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_polkadot_valid_with_facultative.json", false)
                .Build();

            var substrateEndpoint = new SubstrateEndpoint(config);

            Assert.That(substrateEndpoint.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(substrateEndpoint.WsEndpointUri, Is.EqualTo(new Uri("wss://rpc.polkadot.io")));
            Assert.That(substrateEndpoint.ApiUri, Is.EqualTo(new Uri("https://localhost:7066")));
            Assert.That(substrateEndpoint.PrometheusUri, Is.EqualTo(new Uri("https://localhost:1234")));
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
                .AddJsonFile("appsettings_empty.json", false)
                .Build();

            Assert.Throws<ConfigurationErrorsException>(() => new SubstrateEndpoint(config));
        }

        [Test]
        public void HaflFilledAppSettings_ShouldFailed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_haflfilled.json", false)
                .Build();

            Assert.Throws<ConfigurationErrorsException>(() => new SubstrateEndpoint(config));
        }
    }
}