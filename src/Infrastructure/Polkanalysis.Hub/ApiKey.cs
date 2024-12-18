namespace Polkanalysis.Hub
{
    /// <summary>
    /// API key to access the hub
    /// </summary>
    public class ApiKey
    {
        public ApiKey(string key, List<string> allowedChannels)
        {
            Key = key;
            AllowedChannels = allowedChannels;
        }

        public string Key { get; set; }
        public List<string> AllowedChannels { get; set; }
    }
}
