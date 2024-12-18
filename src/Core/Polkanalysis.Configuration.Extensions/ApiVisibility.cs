using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts.Api;
using Polkanalysis.Configuration.Contracts.Endpoints;
using System.Configuration;

namespace Polkanalysis.Configuration.Extensions
{
    public class ApiVisibility : IApiVisibility
    {
        private List<ApiVisibilityController> _availableControllerByBlockchain;
        public List<ApiVisibilityController> AvailableControllersByBlockchain { get => _availableControllerByBlockchain; }

        public List<string> GetAvailableController(string blockchainName)
        {
            Guard.Against.NullOrEmpty(blockchainName);
            return _availableControllerByBlockchain.Single(x => x.BlockchainName.ToLower() == blockchainName.ToLower()).ControllerNames;
        }

        public ApiVisibility(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var elements = configuration.GetSection("ApiVisibility").GetChildren().ToList();

            _availableControllerByBlockchain = new List<ApiVisibilityController>();
            foreach (var elem in elements)
            {
                var blockchainName = elem.Key;
                List<string> controllerNames = elem.GetChildren().Select(x => x.Value).ToList() ?? new List<string>();

                Guard.Against.NullOrEmpty(blockchainName);

                _availableControllerByBlockchain.Add(new ApiVisibilityController(blockchainName, controllerNames));
            }
        }
    }
}
