using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Versionning
{
    public class ActivePallets
    {
        private readonly ScanAssemblyPalletVersion _scanPallets;
        private readonly ILogger<ActivePallets> _logger;

        public ActivePallets(ScanAssemblyPalletVersion scanPallets, ILogger<ActivePallets> logger)
        {
            _scanPallets = scanPallets;
            _logger = logger;
        }

        public virtual List<PalletVersionning> GetPallets(string blockchainName, uint blockNumber)
        {
            Guard.Against.NullOrEmpty(blockchainName, nameof(blockchainName));
            Guard.Against.Negative(blockNumber, nameof(blockNumber));

            var res = _scanPallets.ScanAttribute()
                .Where(x => x.Version.BlockchainName == blockchainName);

            if (!res.Any())
            {
                throw new InvalidOperationException($"No pallet found for blockchain name {blockchainName}");
            }

            res = res.Where(x => x.Version.BlockStart <= blockNumber && x.Version.BlockEnd >= blockNumber);

            if (!res.Any())
            {
                throw new InvalidOperationException($"No pallet version found for blockchain name {blockchainName} and block number {blockNumber}");
            }

            _logger.LogDebug("Active pallet with blockchain {blockchainName} and block number {blockNumber} give {nb} count result", blockchainName, blockNumber, res.Count());

            return res.ToList();
        }
    }
}
