using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker
{
    /// <summary>
    /// Workers configuration
    /// </summary>
    internal class WorkerConfig
    {
        public required EventsConfig EventsConfig { get; set; }
        public required BlocksConfig BlocksConfig { get; set; }
        public required ExtrinsicsConfig ExtrinsicsConfig { get; set; }
        public required PriceConfig PriceConfig { get; set; }
        public required StakingConfig StakingConfig { get; set; }
        public required VersionConfig VersionConfig { get; set; }
    }

    /// <summary>
    /// Configuration for saving events
    /// </summary>
    /// <param name="IsEnabled"></param>
    /// <param name="SaveAllEvents"></param>
    public record EventsConfig(bool IsEnabled, bool SaveAllEvents);

    /// <summary>
    /// Configuration for saving blocks
    /// </summary>
    /// <param name="IsEnabled"></param>
    public record BlocksConfig(bool IsEnabled);

    /// <summary>
    /// Configuration for saving extrinsics
    /// </summary>
    /// <param name="IsEnabled"></param>
    public record ExtrinsicsConfig(bool IsEnabled);

    /// <summary>
    /// Configuration for saving prices
    /// </summary>
    /// <param name="IsEnabled"></param>
    public record PriceConfig(bool IsEnabled);

    /// <summary>
    /// Configuration for saving staking
    /// </summary>
    /// <param name="IsEnabled"></param>
    public record StakingConfig(bool IsEnabled);

    /// <summary>
    /// Configuration for saving pallet and metadata version
    /// </summary>
    /// <param name="IsEnabled"></param>
    public record VersionConfig(bool IsEnabled);
}
