using Polkanalysis.Configuration.Contracts.Information;

namespace Polkanalysis.Domain.Contracts.Dto.Informations
{
    /// <summary>
    /// Data Transfer Object for Blockchain Details.
    /// </summary>
    public class BlockchainDetailsDto
    {
        /// <summary>
        /// Gets or sets the blockchain project information detail.
        /// </summary>
        public BlockchainProject BlockchainInformationDetail { get; set; }

        /// <summary>
        /// Gets or sets the full name of the blockchain.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the blockchain is a relay chain.
        /// </summary>
        public bool IsRelayChain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the blockchain is alive.
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// Gets or sets the token symbol of the blockchain.
        /// </summary>
        public string TokenSymbol { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the token decimal places of the blockchain.
        /// </summary>
        public int TokenDecimal { get; set; }

        /// <summary>
        /// Gets or sets the version of the blockchain.
        /// </summary>
        public string Version { get; set; } = string.Empty;
    }
}
