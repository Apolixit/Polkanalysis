namespace Blazscan.Configuration.Contract
{
    public class SubstrateEndpoint
    {
        public const string ENDPOINT = "endpoint";
        public string Name { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;

        public Uri EndPointUri => new Uri(Endpoint);
    }
}