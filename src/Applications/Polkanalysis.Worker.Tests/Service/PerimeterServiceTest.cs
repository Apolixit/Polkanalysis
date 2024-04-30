using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Worker.Parameters;

namespace Polkanalysis.Worker.Tests.Service
{
    public class PerimeterServiceTest
    {
        private PerimeterService _perimeterService;
        private ILogger<PerimeterService> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<PerimeterService>>();
        }

        [Test]
        public void PerimeterService_WithValidConfiguration_1_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_valid_1.json", false)
                .Build();
            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 10);
            Assert.That(blockPerimeter.IsSet, Is.True);
            Assert.That(blockPerimeter.From, Is.EqualTo(1000000));
            Assert.That(blockPerimeter.To, Is.EqualTo(1000002));
            Assert.That(blockPerimeter.OverrideIfAlreadyExists, Is.False);

            var eraPerimeter = _perimeterService.GetEraPerimeter(() => 0);
            Assert.That(eraPerimeter.IsSet, Is.True);
            Assert.That(eraPerimeter.From, Is.EqualTo(1000));
            Assert.That(eraPerimeter.To, Is.EqualTo(2000));
            Assert.That(eraPerimeter.OverrideIfAlreadyExists, Is.True);

            var tokenPricePerimeter = _perimeterService.GetTokenPricePerimeter(() => new DateTime(2020, 01, 01));
            Assert.That(tokenPricePerimeter.IsSet, Is.True);
            Assert.That(tokenPricePerimeter.From, Is.EqualTo(new DateTime(2023,01,01)));
            Assert.That(tokenPricePerimeter.To, Is.EqualTo(new DateTime(2023, 02, 01)));
            Assert.That(tokenPricePerimeter.OverrideIfAlreadyExists, Is.False);
        }

        [Test]
        public void PerimeterService_WithValidConfiguration_2_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_valid_2.json", false)
                .Build();

            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 10);
            Assert.That(blockPerimeter.IsSet, Is.True);
            Assert.That(blockPerimeter.From, Is.EqualTo(1));
            Assert.That(blockPerimeter.To, Is.EqualTo(1000));

            var eraPerimeter = _perimeterService.GetEraPerimeter(() => 2000);
            Assert.That(eraPerimeter.IsSet, Is.True);
            Assert.That(eraPerimeter.From, Is.EqualTo(1));
            Assert.That(eraPerimeter.To, Is.EqualTo(2000));

            var tokenPricePerimeter = _perimeterService.GetTokenPricePerimeter(() => new DateTime(2020, 01, 01));
            Assert.That(tokenPricePerimeter.IsSet, Is.True);
            Assert.That(tokenPricePerimeter.From, Is.EqualTo(new DateTime(2020, 01, 01)));
            Assert.That(tokenPricePerimeter.To, Is.EqualTo(new DateTime(2023, 02, 01)));
        }

        [Test]
        public void PerimeterService_WithValidConfiguration_3_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_valid_3.json", false)
                .Build();

            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 100);
            Assert.That(blockPerimeter.IsSet, Is.True);
            Assert.That(blockPerimeter.From, Is.EqualTo(10));
            Assert.That(blockPerimeter.To, Is.EqualTo(100));

            var eraPerimeter = _perimeterService.GetEraPerimeter(() => 2000);
            Assert.That(eraPerimeter.IsSet, Is.True);
            Assert.That(eraPerimeter.From, Is.EqualTo(20));
            Assert.That(eraPerimeter.To, Is.EqualTo(2000));

            var tokenPricePerimeter = _perimeterService.GetTokenPricePerimeter(() => new DateTime(2022, 01, 01));
            Assert.That(tokenPricePerimeter.IsSet, Is.True);
            Assert.That(tokenPricePerimeter.From, Is.EqualTo(new DateTime(2020, 01, 01)));

            var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Assert.That(tokenPricePerimeter.To, Is.EqualTo(now.AddDays(-1)));
        }

        [Test]
        public void PerimeterService_WithValidConfiguration_4_ShouldHaveNotSetForEveryone_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_valid_4.json", false)
                .Build();

            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 100);
            Assert.That(blockPerimeter.IsSet, Is.False);

            var eraPerimeter = _perimeterService.GetEraPerimeter(() => 2000);
            Assert.That(eraPerimeter.IsSet, Is.False);

            var tokenPricePerimeter = _perimeterService.GetTokenPricePerimeter(() => new DateTime(2022, 01, 01));
            Assert.That(tokenPricePerimeter.IsSet, Is.False);
        }

        [Test]
        public void BlockPerimeter_WithValidBlockData_1_ShouldWork()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_invalid_1.json", false)
                .Build();

            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 100);

            Assert.That(blockPerimeter.From, Is.EqualTo(default(uint)));
            Assert.That(blockPerimeter.To, Is.EqualTo(default(uint)));
        }

        [Test]
        public void BlockPerimeter_WithInvalidBlockData_2_ShouldIgnore()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Service/appsettings_invalid_2.json", false)
                .Build();

            _perimeterService = new PerimeterService(config, _logger);

            var blockPerimeter = _perimeterService.GetBlockPerimeter(() => 100);

            Assert.That(blockPerimeter.From, Is.EqualTo(default(uint)));
            Assert.That(blockPerimeter.To, Is.EqualTo(default(uint)));
        }
    }
}
