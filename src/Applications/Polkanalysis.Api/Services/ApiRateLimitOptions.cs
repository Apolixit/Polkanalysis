namespace Polkanalysis.Api.Services
{
    /// <summary>
    /// Based on https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Models/MyRateLimitOptions.cs
    /// </summary>
    public class ApiRateLimitOptions
    {
        public const string FixedPolicy = nameof(FixedPolicy);
        public const string TokenBucketPolicy = nameof(TokenBucketPolicy);
        public const string ApiRateLimit = "ApiRateLimit";
        public int NbMaxRequests { get; set; } = 100;
        public int Frequency { get; set; } = 10;
        public int ReplenishmentPeriod { get; set; } = 2;
        public int QueueLimit { get; set; } = 2;
        public int SegmentsPerWindow { get; set; } = 8;
        public int TokenLimit { get; set; } = 10;
        public int TokenLimit2 { get; set; } = 20;
        public int TokensPerPeriod { get; set; } = 4;
        public bool AutoReplenishment { get; set; } = false;
    }
}
