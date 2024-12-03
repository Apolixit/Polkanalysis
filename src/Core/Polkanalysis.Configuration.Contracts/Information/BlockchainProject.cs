using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts.Information
{
    /// <summary>
    /// Represents a blockchain project with various properties such as name, logo URL, social media links, and more.
    /// </summary>
    public class BlockchainProject
    {
        /// <summary>
        /// Gets or sets the name of the blockchain project.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the parachain ID of the blockchain project.
        /// </summary>
        public int? ParachainId { get; set; }

        /// <summary>
        /// Gets or sets the URL of the project's logo.
        /// </summary>
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the Telegram link of the blockchain project.
        /// </summary>
        public string? Telegram { get; set; }

        /// <summary>
        /// Gets or sets the founder of the blockchain project.
        /// </summary>
        public string? Founder { get; set; }

        /// <summary>
        /// Gets or sets the Twitter link of the blockchain project.
        /// </summary>
        public string? Twitter { get; set; }

        /// <summary>
        /// Gets or sets the website URL of the blockchain project.
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Gets or sets the whitepaper URL of the blockchain project.
        /// </summary>
        public string? Whitepaper { get; set; }

        /// <summary>
        /// Gets or sets the GitHub link of the blockchain project.
        /// </summary>
        public string? Github { get; set; }

        /// <summary>
        /// Gets or sets the Medium link of the blockchain project.
        /// </summary>
        public string? Medium { get; set; }

        /// <summary>
        /// Gets or sets the Discord link of the blockchain project.
        /// </summary>
        public string? Discord { get; set; }
    }
}
