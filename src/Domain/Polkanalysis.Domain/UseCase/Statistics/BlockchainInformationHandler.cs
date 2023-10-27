using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.UseCase.Statistics
{
    public class BlockchainInformationHandler : Handler<
        BlockchainInformationHandler, BlockchainInformationDto, BlockchainInformationQuery>
    {

        private readonly ISubstrateService _substrateService;
        private readonly IConfiguration _configuration;

        public BlockchainInformationHandler(ISubstrateService substrateRepository, IConfiguration configuration, ILogger<BlockchainInformationHandler> logger) : base(logger)
        {
            _substrateService = substrateRepository;
            _configuration = configuration;
        }

        public async override Task<Result<BlockchainInformationDto, ErrorResult>> Handle(BlockchainInformationQuery request, CancellationToken cancellationToken)
        {
            if (_configuration == null)
                throw new InvalidOperationException($"{nameof(_configuration)} is not set");

            var blockchainName = _substrateService.Rpc.System.ChainAsync();
            var blockchainFullName = _substrateService.Rpc.System.NameAsync();
            var blockchainProperty = _substrateService.Rpc.System.PropertiesAsync();
            var blockchainChainType = _substrateService.Rpc.System.ChainTypeAsync();

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
