using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts.Api
{
    public interface IApiVisibility
    {
        /// <summary>
        /// List of controllers accessible for each blockchain
        /// </summary>
        public List<ApiVisibilityController> AvailableControllersByBlockchain { get; }

        /// <summary>
        /// Get available controller for the blockchain
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <returns></returns>
        public List<string> GetAvailableController(string blockchainName);
    }

    public class ApiVisibilityController
    {
        public ApiVisibilityController(string blockchainName, List<string> controllerName)
        {
            BlockchainName = blockchainName;
            ControllerNames = controllerName;
        }

        public string BlockchainName { get; set; }
        public List<string> ControllerNames { get; set; }
    }
}
