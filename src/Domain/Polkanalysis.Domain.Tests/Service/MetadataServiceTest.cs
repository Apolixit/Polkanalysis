﻿using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Domain.Contracts.Service;
using Substrate.NET.Metadata.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Domain.Service;
using System.Threading;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NET.Utils.Core;

namespace Polkanalysis.Domain.Tests.Service
{
    public class MetadataServiceTest : DomainTestAbstract
    {
        private IMetadataService _metadataService;
        private ICoreService _coreService;
        private ISubstrateService _substrateService;

        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<MetadataService>>();
            _coreService = Substitute.For<ICoreService>();
            _substrateService = Substitute.For<ISubstrateService>();
            
            _metadataService = new MetadataService(
                _substrateService,
                _substrateDbContext,
                _coreService,
                logger
            );

            _substrateService.Rpc.Chain.GetBlockHashAsync(CancellationToken.None).Returns(MockHash);
        }

        [Test]
        public void GetPalletModule_WithNullName_ShouldFailed()
        {
            // Mock metadata
            _metadataService.SetMetadata(MetadataHelper.GetMetadataFromHex(MockMetadata1));

            Assert.ThrowsAsync<ArgumentException>(() => _metadataService.GetPalletModuleByNameAsync(string.Empty, CancellationToken.None));
        }

        [Test]
        public async Task GetMetadataAsync_FromSpecVersion_ShouldSucceedAsync()
        {
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 10,
                BlockchainName = "Polkadot",
                BlockStart = 1000,
                BlockStartDateTime = new DateTime(2024,1,1),
                BlockEnd = 2000,
                BlockEndDateTime = new DateTime(2024, 01, 20),
                MetadataVersion = 14,
                Metadata = MockMetadata1
            });
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 20,
                BlockchainName = "Polkadot",
                BlockStart = 2001,
                BlockStartDateTime = new DateTime(2024, 01, 21),
                BlockEnd = 3000,
                BlockEndDateTime = null,
                MetadataVersion = 14,
                Metadata = MockMetadata2
            });
            _substrateDbContext.SaveChanges();

            _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber((uint)1000), Arg.Any<CancellationToken>()).Returns(MockHash);
            _substrateService.Rpc.State.GetMetaDataAsync(MockHash, CancellationToken.None).Returns(MockMetadata1);
            _coreService.GetDateTimeFromTimestampAsync(MockHash, CancellationToken.None).Returns(new DateTime(2024, 01, 01));

            var res = await _metadataService.GetMetadataAsync(10, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task GetMetadataAsync_WithSpecVersionNull_ShouldReturnNullAsync()
        {
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 10,
                BlockchainName = "Polkadot",
                BlockStart = 1000,
                BlockStartDateTime = new DateTime(2024, 1, 1),
                BlockEnd = 2000,
                BlockEndDateTime = new DateTime(2024, 01, 20),
                MetadataVersion = 14,
                Metadata = MockMetadata1
            });
            _substrateDbContext.SaveChanges();

            var res = await _metadataService.GetMetadataAsync(8, CancellationToken.None);
            Assert.That(res, Is.Null);
        }

        [Test]
        public async Task GetAllMetadataInfoAsync_WithData_ShouldReturnEverything()
        {
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 10,
                BlockchainName = "Polkadot",
                BlockStart = 1000,
                BlockStartDateTime = new DateTime(2024, 1, 1),
                BlockEnd = 2000,
                BlockEndDateTime = new DateTime(2024, 01, 20),
                MetadataVersion = 14,
                Metadata = MockMetadata1
            });
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 20,
                BlockchainName = "Polkadot",
                BlockStart = 2001,
                BlockStartDateTime = new DateTime(2024, 01, 21),
                BlockEnd = 3000,
                BlockEndDateTime = null,
                MetadataVersion = 14,
                Metadata = MockMetadata2
            });
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                SpecVersion = 30,
                BlockchainName = "Polkadot",
                BlockStart = 3001,
                BlockStartDateTime = new DateTime(2024, 01, 21),
                BlockEnd = 1000,
                BlockEndDateTime = null,
                MetadataVersion = 14,
                Metadata = MockMetadata1
            });
            _substrateDbContext.SaveChanges();

            var res = await _metadataService.GetAllMetadataInfoAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);

            var list = res.ToList();
            Assert.Multiple(() =>
            {
                Assert.That(list, Has.Count.EqualTo(3));
                Assert.That(list[0].SpecVersion, Is.EqualTo(10));
                Assert.That(list[1].SpecVersion, Is.EqualTo(20));
                Assert.That(list[2].SpecVersion, Is.EqualTo(30));
            });
        }

        [Test]
        public async Task GetPalletModuleByIndexAsync_WithValidIndex_ShouldSucceedAsync()
        {
            _metadataService.SetMetadata(MetadataHelper.GetMetadataFromHex(MockMetadata1));

            var res = await _metadataService.GetPalletModuleByIndexAsync(0, CancellationToken.None);

            Assert.That(res.Name, Is.EqualTo("System"));
        }
        [Test]
        public void GetPalletModuleByIndexAsync_WithInvalidIndex_ShouldThrowException()
        {
            _metadataService.SetMetadata(MetadataHelper.GetMetadataFromHex(MockMetadata1));

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await _metadataService.GetPalletModuleByIndexAsync(250, CancellationToken.None));
        }
    }
}
