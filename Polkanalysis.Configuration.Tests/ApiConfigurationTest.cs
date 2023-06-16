using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Polkanalysis.Configuration.Extensions;

namespace Polkanalysis.Configuration.Tests
{
    public class ApiConfigurationTest
    {
        [Test]
        public void FilledApiConfiguration_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Api/appsettings_valid_api.json", false)
                .Build();

            var apiConfig = new ApiEndpoint(config);

            Assert.That(apiConfig.ApiUri, Is.Not.Null);
            Assert.That(apiConfig.ApiUri.OriginalString, Is.EqualTo("https://localhost:7066"));
        }

        [Test]
        public void EmptyApiConfiguration_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Api/appsettings_empty_api.json", false)
                .Build();

            var apiConfig = new ApiEndpoint(config);

            Assert.That(apiConfig.ApiUri, Is.Null);
        }
    }
}
