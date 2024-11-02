using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker.Parameters
{
    public class GenericPerimeter<T>
        where T : ISpanParsable<T>, IComparable<T>
    {
        public T? From { get; set; }
        public T? To { get; set; }
        public bool OverrideIfAlreadyExists { get; set; } = false;
        public bool IsSet => From is not null && !From.Equals(default(T)) && To is not null && !To.Equals(default(T));

        protected GenericPerimeter(
            IConfiguration configuration,
            string section,
            ILogger<PerimeterService> logger,
            T genesisValue,
            T nowValue)
        {
            EnsureConfigurationIsSet(configuration, section);

            var substrateSection = configuration.GetSection(section).GetChildren().ToList();
            if (substrateSection is not null && substrateSection.Any())
            {
                var fromSection = substrateSection.FirstOrDefault(e => e.Key == "from");
                var toSection = substrateSection.FirstOrDefault(e => e.Key == "to");
                var overrideIfExistSection = substrateSection.FirstOrDefault(e => e.Key == "overrideIfAlreadyExists");

                ParseOverrideIfAlreadyExists(overrideIfExistSection);

                // For a valid configuration, both values have to be set (otherwise, just ignore it)
                if (fromSection?.Value != null && toSection?.Value != null)
                {
                    ParseFromSection(logger, genesisValue, fromSection!);
                    ParseToSection(nowValue, toSection!);
                    EnsureParametersAreValid(logger);
                }
            }
        }

        private void EnsureParametersAreValid(ILogger<PerimeterService> logger)
        {
            if (From is not null && To is not null && From.CompareTo(To) > 0)
            {
                logger.LogWarning($"From (={From}) is greater than To (={To}). Param are ignored");

                From = default;
                To = default;
            }
        }

        private void ParseToSection(T nowValue, IConfigurationSection toSection)
        {
            if (toSection.Value!.ToLower() == "now")
            {
                To = nowValue;
            }
            else
            {
                T? parsedTo;
                if (T.TryParse(toSection.Value, null, out parsedTo))
                {
                    To = parsedTo;
                }
            }
        }

        private void ParseFromSection(ILogger<PerimeterService> logger, T genesisValue, IConfigurationSection fromSection)
        {
            if (fromSection.Value!.ToLower() == "genesis")
            {
                From = genesisValue;
            }
            else
            {
                T? parsedFrom;
                if (T.TryParse(fromSection.Value, null, out parsedFrom))
                {
                    From = parsedFrom;
                }
                else
                {
                    logger.LogWarning($"From (={fromSection.Value}) is not a valid input. Param is ignored");
                }
            }
        }

        private void ParseOverrideIfAlreadyExists(IConfigurationSection? overrideIfExistSection)
        {
            if (overrideIfExistSection?.Value is not null)
            {
                bool parsedOverrideIfExist;
                if (bool.TryParse(overrideIfExistSection.Value, out parsedOverrideIfExist))
                {
                    OverrideIfAlreadyExists = parsedOverrideIfExist;
                }
            }
        }

        private static void EnsureConfigurationIsSet(IConfiguration configuration, string section)
        {
            if (configuration is null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            if (string.IsNullOrEmpty(section))
                throw new ConfigurationErrorsException($"{nameof(section)} is not set");
        }
    }
}
