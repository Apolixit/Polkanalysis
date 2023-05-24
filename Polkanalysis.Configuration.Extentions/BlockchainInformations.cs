using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts.Information;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extentions
{
    public class BlockchainInformations : IBlockchainInformations
    {
        public List<RelayChain> RelayChains { get; init; }

        private const string GlobalInfo = "BlockchainInformation";
        private const string RelayChainName = "RelayChainName";
        private const string BlockchainInfoDetail = "Informations";

        public BlockchainInformations(IConfiguration configuration) {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            RelayChains = new List<RelayChain>();
            var blockchainInfoSection = configuration.GetSection(GlobalInfo).GetChildren().ToList();

            foreach (var relayChainSection in blockchainInfoSection)
            {
                var relayChainName = relayChainSection.GetRequiredSection(RelayChainName).Value;
                if(string.IsNullOrEmpty(relayChainName)) throw new ConfigurationErrorsException($"{relayChainName} not found");

                var blockchainsDetail = relayChainSection.GetSection(BlockchainInfoDetail).GetChildren().ToList();

                var blockchainProjects = new List<BlockchainProject>();
                foreach (var blockchainDetail in blockchainsDetail)
                {
                    var name = !string.IsNullOrEmpty(blockchainDetail["name"]) ? blockchainDetail["name"] : throw new ConfigurationErrorsException($"blockchain name have to be filled in appsettings (BlockchainInformation > Informations > name)");

                    blockchainProjects.Add(new BlockchainProject()
                    {
                        Name = name,
                        ParachainId = !string.IsNullOrEmpty(blockchainDetail["parachainId"]) ? int.Parse(blockchainDetail["parachainId"]!) : null,
                        LogoUrl = blockchainDetail["logoUrl"],
                        Telegram = blockchainDetail["telegram"],
                        Founder = blockchainDetail["founder"],
                        Twitter = blockchainDetail["twitter"],
                        Website = blockchainDetail["website"],
                        Whitepaper = blockchainDetail["whitepaper"],
                        Github = blockchainDetail["whitepaper"],
                        Medium = blockchainDetail["medium"],
                        Discord = blockchainDetail["discord"],
                    });
                }

                RelayChains.Add(new RelayChain()
                {
                    RelayChainName = relayChainName,
                    BlockainInformations = blockchainProjects
                });
            }
        }
    }
}
