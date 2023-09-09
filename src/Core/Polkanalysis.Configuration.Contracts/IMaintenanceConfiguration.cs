namespace Polkanalysis.Configuration.Contracts
{
    public interface IMaintenanceConfiguration
    {
        string EndTime { get; set; }
        bool IsActivated { get; set; }
    }
}