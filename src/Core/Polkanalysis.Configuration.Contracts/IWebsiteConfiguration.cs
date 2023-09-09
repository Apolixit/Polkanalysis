namespace Polkanalysis.Configuration.Contracts
{
    public interface IWebsiteConfiguration
    {
        IMaintenanceConfiguration Maintenance { get; set; }
    }
}