using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors;
using Polkanalysis.Configuration.Contracts.Api;

namespace Polkanalysis.Api.Filters
{
    /// <summary>
    /// Check the visibility of the controller for a given blockchain
    /// </summary>
    public class ControllerVisibilityFilter : IActionFilter
    {
        private string[] _allowedControllers;

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="allowedControllers"></param>
        public ControllerVisibilityFilter(string[] allowedControllers)
        {
            _allowedControllers = allowedControllers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.ActionDescriptor.RouteValues["controller"];

            if (!_allowedControllers.Contains(controllerName, StringComparer.OrdinalIgnoreCase))
            {
                context.Result = new NotFoundResult(); // Renvoyer 404 si non autorisé
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context) { }
    }

    public class ControllerVisibilityDocumentProcessor : IDocumentProcessor
    {
        private readonly string[] _allowedControllers;

        public ControllerVisibilityDocumentProcessor(string[] allowedControllers)
        {
            _allowedControllers = allowedControllers;
        }

        public void Process(DocumentProcessorContext context)
        {
            // Supprimer les opérations des contrôleurs non autorisés
            foreach (var controllerType in context.ControllerTypes)
            {
                var controllerName = controllerType.Name.Replace("Controller", "");
                if (!_allowedControllers.Contains(controllerName, StringComparer.OrdinalIgnoreCase))
                {
                    var endpointsToRemove = context.Document.Paths.Keys.Where(key => key.Contains($"/{controllerName.ToLower()}")).ToList();
                    foreach (var endpoint in endpointsToRemove)
                    {
                        context.Document.Paths.Remove(endpoint);
                    }
                    //context.Document.Paths.Remove(controllerType.Name); // Delete unauthorized controller
                }
            }
        }
    }
}
