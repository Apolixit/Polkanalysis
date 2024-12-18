using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Polkanalysis.Api.Controllers;

namespace Polkanalysis.Api.Filters
{
    public class DynamicRouteConvention : IApplicationModelConvention
    {
        private readonly string _blockchainName;

        public DynamicRouteConvention(string blockchainName)
        {
            _blockchainName = blockchainName;
        }

        public int Order => -1; // Cela garantit que ce provider est appelé avant d'autres

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                // Vérifier si le contrôleur hérite de MasterController
                if (controller.ControllerType.IsSubclassOf(typeof(MasterController)))
                {
                    foreach (var selector in controller.Selectors)
                    {
                        // Appliquer une route dynamique
                        if (selector.AttributeRouteModel != null)
                        {
                            selector.AttributeRouteModel.Template = $"api/{_blockchainName}/[controller]";
                        }
                    }
                }
            }
        }
    }
}
