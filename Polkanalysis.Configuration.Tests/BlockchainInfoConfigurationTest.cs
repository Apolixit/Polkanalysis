using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Polkanalysis.Configuration.Extentions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Tests
{
    public class BlockchainInfoConfigurationTest
    {
        [Test]
        public void FilledBlockchainConfiguration_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/BlockchainInfo/appsettings_valid_blockchaininfo.json", false)
                .Build();

            var blockchainConfig = new BlockchainInformations(config);

            Assert.That(blockchainConfig, Is.Not.Null);
            Assert.That(blockchainConfig.RelayChains, Is.Not.Null);
            Assert.That(blockchainConfig.RelayChains.Count, Is.EqualTo(2));
            Assert.That(blockchainConfig.RelayChains[0].RelayChainName, Is.EqualTo("Polkadot"));
            Assert.That(blockchainConfig.RelayChains[0].BlockainInformations, Is.Not.Null);
            Assert.That(blockchainConfig.RelayChains[0].BlockainInformations.Skip(1).Take(1).First().Name, Is.EqualTo("Astar"));


            Assert.That(blockchainConfig.RelayChains[1].RelayChainName, Is.EqualTo("Kusama"));
            Assert.That(blockchainConfig.RelayChains[1].BlockainInformations, Is.Not.Null);
            Assert.That(blockchainConfig.RelayChains[1].BlockainInformations.Skip(2).Take(1).First().Name, Is.EqualTo("Bajun"));
        }

        [Test]
        public void InvalidBlockchainConfiguration_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/BlockchainInfo/appsettings_invalid_blockchaininfo_1.json", false)
                .Build();

            Assert.Throws<ConfigurationErrorsException>(() => new BlockchainInformations(config));
        }
    }
}
