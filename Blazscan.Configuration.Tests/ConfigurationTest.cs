using Blazscan.Configuration.Extentions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Configuration;

namespace Blazscan.Configuration.Tests
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

            Assert.That(substrateEndpoint.Name, Is.EqualTo("Polkadot"));
            Assert.That(substrateEndpoint.Endpoint, Is.EqualTo("wss://rpc.polkadot.io"));
        }

        [Test]
        public void nullAppSettings_ShouldFailed()
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Assert.Throws<ConfigurationErrorsException>(() => new SubstrateEndpoint(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
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