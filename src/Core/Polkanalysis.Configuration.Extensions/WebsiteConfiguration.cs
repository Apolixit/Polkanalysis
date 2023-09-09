using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;

namespace Polkanalysis.Components.Configuration
{
    public class WebsiteConfiguration : IWebsiteConfiguration
    {
        public IMaintenanceConfiguration Maintenance { get; set; }

        public WebsiteConfiguration(IConfiguration configuration)
        {
            if (configuration == null)
                throw new InvalidOperationException($"{nameof(configuration)} is not set");

            var websiteSection = configuration.GetSection("Website").GetChildren().ToList();

            string? isMaintenanceActivated = null;
            string? hasMaintenanceEndtime = null;

            if(websiteSection is not null && websiteSection.Any())
            {
                isMaintenanceActivated = configuration["Website:Maintenance:IsActivated"];
                hasMaintenanceEndtime = configuration["Website:Maintenance:EndTime"];
            }

            Maintenance = new MaintenanceConfiguration()
            {
                IsActivated = isMaintenanceActivated is not null && bool.Parse(isMaintenanceActivated.ToString()),
                EndTime = hasMaintenanceEndtime is not null ? hasMaintenanceEndtime : string.Empty,
            };
        }
    }

    public class MaintenanceConfiguration : IMaintenanceConfiguration
    {
        public bool IsActivated { get; set; }
        public string EndTime { get; set; } = string.Empty;
    }
}
