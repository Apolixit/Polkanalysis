using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using StreamJsonRpc;
using System.Threading;

namespace Polkanalysis.Worker.Tasks
{
    public class VersionWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotService;
        private readonly IMediator _mediator;
        private readonly ILogger<VersionWorker> _logger;

        public uint currentBlock = 1_450_000;

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

            //await SubscribeNewUpgradeVersionAsync(stoppingToken);
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

            if (lastStoredVersion != null)
            {
                _logger.LogInformation("Last version stored in database for {blockchainName} is {versionNumber}", _polkadotService.BlockchainName, lastStoredVersionNum);
            }
            //var block = new List<uint>()
            //{
            //    0, 29231, 188836, 199405, 214264,  244358, 303079, 314201, 342400, 443963, 528470, 687751, 746085, 787923, 799302, 1205128
            //};
            //foreach (uint i in block)
            //{


            for (uint i = currentBlock; i <= lastBlockNum.Value; i++)
            {
                var blockHash = await _polkadotService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(i), cancellationToken);
                var runtimeVersion = await _polkadotService.Rpc.State.GetRuntimeVersionAtAsync(blockHash.Value, CancellationToken.None);

                if (lastStoredVersion == null || lastStoredVersionNum != runtimeVersion.SpecVersion)
                {
                    lastStoredVersionNum = runtimeVersion.SpecVersion;

                    _logger.LogInformation("New runtime upgrade num {specVersion} at block {blockNum}", runtimeVersion.SpecVersion, i);
                    await UpgradeVersionAsync(lastStoredVersionNum.Value, i, cancellationToken);
                }
                else
                {
                    if (i % 5000 == 0)
                    {
                        _logger.LogInformation("Fetching block {blockNum}", i);
                    }
                }

                currentBlock = i;
            }
        }

        private async Task UpgradeVersionAsync(
            uint lastStoredVersionNum, uint blockStartNumber, CancellationToken cancellationToken)
        {
            var dbRes = await _mediator.Send(new SpecVersionCommand()
            {
                SpecVersion = lastStoredVersionNum,
                BlockStart = blockStartNumber
            }, cancellationToken);

            if (dbRes.IsSuccess)
            {
                _logger.LogInformation("New runtime successfully inserted in database");

                // Now let's insert pallet version
                await _mediator.Send(new PalletVersionCommand()
                {
                    SpecVersion = lastStoredVersionNum,
                    BlockStart = blockStartNumber,
                }, cancellationToken);
            }
            else
                _logger.LogError("An error occured when insert new runtime in database");
        }

        public async Task SubscribeNewUpgradeVersionAsync(CancellationToken cancellationToken)
        {
            await _polkadotService.Storage.System.SubscribeNewLastRuntimeUpgradeAsync(
                async (Infrastructure.Blockchain.Contracts.Pallet.System.LastRuntimeUpgradeInfo lastRuntimeUpgradeInfo) =>
            {
                _logger.LogInformation($"New Runtime upgrade ! Runtime spec name {lastRuntimeUpgradeInfo.SpecName} /  Runtime spec version {lastRuntimeUpgradeInfo.SpecVersion}");

                var blockData = await _polkadotService.Rpc.Chain.GetBlockAsync(cancellationToken);

                await UpgradeVersionAsync(lastRuntimeUpgradeInfo.SpecVersion.Value, (uint)blockData.Block.Header.Number.Value, cancellationToken);
            }, cancellationToken);
        }
    }
}
