namespace Polkanalysis.Api.Services
{
    /// <summary>
    /// Based on https://github.com/dotnet/AspNetCore.Docs.Samples/blob/main/fundamentals/middleware/rate-limit/WebRateLimitAuth/Models/MyRateLimitOptions.cs
    /// </summary>
    public class ApiRateLimitOptions
    {
        /// <summary>
        /// The name of the fixed policy.
        /// </summary>
        public const string FixedPolicy = nameof(FixedPolicy);
        /// <summary>
        /// The name of the token bucket policy.
        /// </summary>
        public const string TokenBucketPolicy = nameof(TokenBucketPolicy);
        /// <summary>
        /// The name of the API rate limit.
        /// </summary>
        public const string ApiRateLimit = "ApiRateLimit";
        /// <summary>
        /// Gets or sets the maximum number of requests allowed.
        /// </summary>
        public int NbMaxRequests { get; set; } = 100;
        /// <summary>
        /// Gets or sets the frequency of the rate limit.
        /// </summary>
        public int Frequency { get; set; } = 10;
        /// <summary>
        /// Gets or sets the replenishment period for the rate limit.
        /// </summary>
        public int ReplenishmentPeriod { get; set; } = 2;
        /// <summary>
        /// Gets or sets the queue limit for the rate limit.
        /// </summary>
        public int QueueLimit { get; set; } = 2;
        /// <summary>
        /// Gets or sets the number of segments per window for the rate limit.
        /// </summary>
        public int SegmentsPerWindow { get; set; } = 8;
        /// <summary>
        /// Gets or sets the token limit for the rate limit.
        /// </summary>
        public int TokenLimit { get; set; } = 10;
        /// <summary>
        /// Gets or sets the secondary token limit for the rate limit.
        /// </summary>
        public int TokenLimit2 { get; set; } = 20;
        /// <summary>
        /// Gets or sets the number of tokens replenished per period.
        /// </summary>
        public int TokensPerPeriod { get; set; } = 4;
        /// <summary>
        /// Gets or sets a value indicating whether auto replenishment is enabled.
        /// </summary>
        public bool AutoReplenishment { get; set; } = false;
    }
}
