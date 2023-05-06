using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.DatabaseWorker.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker.Tests
{
    public class BlockPerimeterTest
    {
        private readonly ILogger<BlockPerimeter> _logger;

        public BlockPerimeterTest()
        {
            _logger = Substitute.For<ILogger<BlockPerimeter>>();
        }

        [Test]
        public void BlockPerimeter_WithValidBlockValue_1_ShouldWork()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_valid_1.json", false)
                .Build();

            var blockPerimeter = new BlockPerimeter(config, _logger);

            Assert.That(blockPerimeter.FromBlock, Is.Not.Null);
            Assert.That(blockPerimeter.ToBlock, Is.Not.Null);

            Assert.That(blockPerimeter.FromBlock.Value, Is.EqualTo(1000000));
            Assert.That(blockPerimeter.ToBlock.Value, Is.EqualTo(1000002));
        }

        [Test]
        public void BlockPerimeter_WithValidBlockValue_2_ShouldWork()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_valid_2.json", false)
                .Build();

            var blockPerimeter = new BlockPerimeter(config, _logger);

            Assert.That(blockPerimeter.FromBlock, Is.Not.Null);
            Assert.That(blockPerimeter.ToBlock, Is.Not.Null);

            Assert.That(blockPerimeter.FromBlock.Value, Is.EqualTo(1));
            Assert.That(blockPerimeter.ToBlock.Value, Is.EqualTo(10));
        }

        [Test]
        public void BlockPerimeter_WithValidBlockValue_3_ShouldWork()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_valid_3.json", false)
                .Build();

            var blockPerimeter = new BlockPerimeter(config, _logger);

            Assert.That(blockPerimeter.FromBlock, Is.Not.Null);
            Assert.That(blockPerimeter.ToBlock, Is.Null);

            Assert.That(blockPerimeter.FromBlock.Value, Is.EqualTo(1000000));
        }

        [Test]
        public void BlockPerimeter_WithValidBlockData_1_ShouldWork()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_invalid_1.json", false)
                .Build();

            var blockPerimeter = new BlockPerimeter(config, _logger);

            Assert.That(blockPerimeter.FromBlock, Is.Null);
            Assert.That(blockPerimeter.ToBlock, Is.Null);
        }

        [Test]
        public void BlockPerimeter_WithInvalidBlockData_2_ShouldIgnore()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings_invalid_2.json", false)
                .Build();

            var blockPerimeter = new BlockPerimeter(config, _logger);

            Assert.That(blockPerimeter.FromBlock, Is.Null);
            Assert.That(blockPerimeter.ToBlock, Is.Null);
        }
    }
}
