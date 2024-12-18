namespace Polkanalysis.Hub
{
    public interface IApiKeyValidator
    {
        bool Validate(string apiKey, out ApiKey validApiKey);
    }
}
