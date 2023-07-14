using MediatR;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Worker.Tasks
{
    public class VersionWorker
    {
        private readonly ISubstrateService _polkadotService;
        private readonly IMediator _mediator;
        private readonly ILogger<VersionWorker> _logger;

        public VersionWorker(ISubstrateService polkadotService, IMediator mediator, ILogger<VersionWorker> logger)
        {
            _polkadotService = polkadotService;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            // Block 7 400 000
            await RequestUpgradeVersionAsync(stoppingToken);

            //await SubscribeNewUpgradeVersionAsync(stoppingToken);
        }

        public async Task RequestUpgradeVersionAsync(CancellationToken cancellationToken)
        {
            //if (!_eraPerimeter.IsSet) throw new InvalidOperationException("Era perimeter is not properly set, please check your configuration file.");

            var storedVersions = await _mediator.Send(new SpecVersionsQuery() {
                BlockchainName = _polkadotService.BlockchainName
            }, cancellationToken);

            uint? lastStoredVersion = storedVersions.Value.LastOrDefault()?.SpecVersion;
            var lastBlockNum = await _polkadotService.Storage.System.NumberAsync(cancellationToken);

            if(lastStoredVersion != null) {
                _logger.LogInformation("Last version stored in database for {blockchainName} is {versionNumber}", _polkadotService.BlockchainName, lastStoredVersion.Value);
            }
            
            //for (uint i = 7400000; i <= lastBlockNum.Value; i++)
            for (uint i = 100_000; i <= lastBlockNum.Value; i++)
            {
                var blockHash = await _polkadotService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(i), cancellationToken);
                var res = await _polkadotService.At(blockHash).Storage.System.LastRuntimeUpgradeAsync(cancellationToken);
                if(lastStoredVersion == null || lastStoredVersion != res.SpecVersion.Value)
                {
                    lastStoredVersion = res.SpecVersion.Value;

                    _logger.LogInformation("New runtime upgrade num {specVersion} at block {blockNum}", res.SpecVersion.Value.Value, i);

                    var dbRes = await _mediator.Send(new SpecVersionCommand()
                    {
                        SpecVersion = lastStoredVersion.Value,
                        BlockStart = i
                    }, cancellationToken);

                    if(dbRes.IsSuccess)
                    {
                        _logger.LogInformation("New runtime successfully inserted in database");
                    } else
                    {
                        _logger.LogError("An error occured when insert new runtime in database");
                    }
                } else
                {
                    if(i % 5000 == 0)
                    {
                        _logger.LogInformation("Fetching block {blockNum}", i);
                    }
                }
            }
        }

        public async Task SubscribeNewUpgradeVersionAsync(CancellationToken cancellationToken)
        {
            //_polkadotService.Storage.System.LastRuntimeUpgradeAsync(cancellationToken);
            //_polkadotService.Rpc.State.GetMetaDataAtAsync()
            //_polkadotService.AjunaClient.SubscribeStorageKeyAsync()
            await _polkadotService.Storage.System.SubscribeNewLastRuntimeUpgradeAsync(
                async (Domain.Contracts.Secondary.Pallet.SystemCore.LastRuntimeUpgradeInfo lastRuntimeUpgradeInfo) =>
            {
                _logger.LogInformation($"New Runtime upgrade ! Runtime spec name {lastRuntimeUpgradeInfo.SpecName} /  Runtime spec version {lastRuntimeUpgradeInfo.SpecVersion}");

                _ = await _mediator.Send(new SpecVersionCommand()
                {
                    SpecVersion = lastRuntimeUpgradeInfo.SpecVersion.Value
                }, cancellationToken);

            }, cancellationToken);
        }
    }
}
