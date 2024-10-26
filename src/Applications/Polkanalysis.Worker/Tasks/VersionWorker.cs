using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Worker.Tasks
{
    public class VersionWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotService;
        private readonly IMediator _mediator;
        private readonly ILogger<VersionWorker> _logger;

        public uint currentBlock = 0; //1_450_000; // Block when MetadataV14 was introduced

        public VersionWorker(ISubstrateService polkadotService, IMediator mediator, ILogger<VersionWorker> logger)
        {
            _polkadotService = polkadotService;
            _mediator = mediator;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RunAsync(stoppingToken);
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            // Block 7 400 000
            await RequestUpgradeVersionAsync(stoppingToken);

            await SubscribeNewUpgradeVersionAsync(stoppingToken);
        }

        public async Task RequestUpgradeVersionAsync(CancellationToken cancellationToken)
        {
            var storedVersions = await _mediator.Send(new SpecVersionsQuery()
            {
                BlockchainName = _polkadotService.BlockchainName
            }, cancellationToken);

            var lastStoredVersion = storedVersions.Value.LastOrDefault();
            uint? lastStoredVersionNum = storedVersions.Value.LastOrDefault()?.SpecVersion;
            var lastBlockNum = await _polkadotService.Storage.System.NumberAsync(cancellationToken);
            currentBlock = storedVersions.Value.LastOrDefault()?.BlockStart ?? 1;

            if (lastStoredVersion != null)
            {
                _logger.LogInformation("[{workerName}] Last version stored in database for {blockchainName} is {versionNumber}", nameof(VersionWorker), _polkadotService.BlockchainName, lastStoredVersionNum);
            }

            for (uint i = currentBlock; i <= lastBlockNum.Value; i++)
            {
                var blockHash = await _polkadotService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(i), cancellationToken);
                var runtimeVersion = await _polkadotService.Rpc.State.GetRuntimeVersionAsync(blockHash.Bytes, CancellationToken.None);

                if (lastStoredVersionNum == null || lastStoredVersionNum != runtimeVersion.SpecVersion)
                {
                    lastStoredVersionNum = runtimeVersion.SpecVersion;

                    _logger.LogInformation("[{workerName}] New runtime upgrade. Version {specVersion} at block {blockNum}", nameof(VersionWorker), runtimeVersion.SpecVersion, i);
                    await UpgradeVersionAsync(lastStoredVersionNum.Value, i, blockHash, cancellationToken);
                }
                else
                {
                    if (i % 5000 == 0)
                    {
                        _logger.LogInformation("[{workerName}] Fetching block {blockNum}", nameof(VersionWorker), i);
                    }
                }

                currentBlock = i;
            }
        }

        private async Task UpgradeVersionAsync(
            uint lastStoredVersionNum, uint blockStartNumber, Substrate.NetApi.Model.Types.Base.Hash blockHash, CancellationToken cancellationToken)
        {
            var dbRes = await _mediator.Send(new SpecVersionCommand(lastStoredVersionNum, blockStartNumber, blockHash), cancellationToken);

            if (dbRes.IsSuccess)
            {
                _logger.LogDebug("[{workerName}] New runtime successfully inserted in database", nameof(VersionWorker));

                // Now let's insert pallet version
                await _mediator.Send(new PalletVersionCommand()
                {
                    SpecVersion = lastStoredVersionNum,
                    BlockStart = blockStartNumber,
                }, cancellationToken);
            }
            else
                _logger.LogError("[{workerName}] An error occured when insert new runtime in database", nameof(VersionWorker));
        }

        public async Task SubscribeNewUpgradeVersionAsync(CancellationToken cancellationToken)
        {
            await _polkadotService.Storage.System.SubscribeNewLastRuntimeUpgradeAsync(
                async (Infrastructure.Blockchain.Contracts.Pallet.System.LastRuntimeUpgradeInfo lastRuntimeUpgradeInfo) =>
            {
                _logger.LogInformation("[{workerName}] New Runtime upgrade ! Runtime spec name {specName} /  Runtime spec version {specVersion}", nameof(VersionWorker), lastRuntimeUpgradeInfo.SpecName, lastRuntimeUpgradeInfo.SpecVersion);

                var blockData = await _polkadotService.Rpc.Chain.GetBlockAsync(cancellationToken);
                var blockHash = await _polkadotService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber((uint)blockData.GetBlock().Header.Number.Value), cancellationToken);

                await UpgradeVersionAsync(lastRuntimeUpgradeInfo.SpecVersion.Value, (uint)blockData.GetBlock().Header.Number.Value, blockHash, cancellationToken);
            }, cancellationToken);
        }
    }
}
