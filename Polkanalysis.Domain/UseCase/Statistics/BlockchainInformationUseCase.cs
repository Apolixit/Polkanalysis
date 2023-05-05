using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Statistics
{
    public class BlockchainInformationUseCase : UseCase<
        BlockchainInformationUseCase, BlockchainInformationDto, BlockchainInformationQuery>
    {

        private readonly ISubstrateRepository _substrateRepository;
        private readonly IConfiguration _configuration;

        public BlockchainInformationUseCase(ISubstrateRepository substrateRepository, IConfiguration configuration, ILogger<BlockchainInformationUseCase> logger) : base(logger)
        {
            _substrateRepository = substrateRepository;
            _configuration = configuration;
        }

        public async override Task<Result<BlockchainInformationDto, ErrorResult>> Handle(BlockchainInformationQuery request, CancellationToken cancellationToken)
        {
            if (_configuration == null)
                throw new InvalidOperationException($"{nameof(_configuration)} is not set");

            var blockchainName = _substrateRepository.Rpc.System.ChainAsync();
            var blockchainFullName = _substrateRepository.Rpc.System.NameAsync();
            var blockchainProperty = _substrateRepository.Rpc.System.PropertiesAsync();
            var blockchainChainType = _substrateRepository.Rpc.System.ChainTypeAsync();

            await Task.WhenAll(new Task[] { blockchainName, blockchainFullName, blockchainProperty, blockchainChainType });

            var blockchainInformation = _configuration.GetSection("BlockchainInformation").GetChildren().ToList();

            var blockchainSection = blockchainInformation.FirstOrDefault(e => e.Key == blockchainName.Result) ?? throw new InvalidOperationException($"{nameof(blockchainName)} configuration is not set");

            var result = new BlockchainInformationDto()
            {
                Name = await blockchainName,
                FullName = await blockchainFullName,
                Currency = (await blockchainProperty).TokenSymbol,
                ChainType = await blockchainChainType,
                LogoUrl = blockchainSection["logoUrl"],
                Telegram = blockchainSection["telegram"],
                Founder = blockchainSection["founder"],
                Twitter = blockchainSection["twitter"],
                Website = blockchainSection["website"],
                Whitepaper = blockchainSection["whitepaper"],
                Github = blockchainSection["github"],
            };

            return Helpers.Ok(result);
        }
    }
}
