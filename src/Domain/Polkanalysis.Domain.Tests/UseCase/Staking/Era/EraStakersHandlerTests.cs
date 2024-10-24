using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Search;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Search;
using Polkanalysis.Domain.UseCase.Staking.Era;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Staking.Era
{
    public class EraStakersHandlerTests : UseCaseTest<EraStakersCommandHandler, bool, EraStakersCommand>
    {
        private IStakingDatabaseRepository _stakingDatabaseRepository;

        [SetUp]
        public void Setup()
        {
            _substrateService.BlockchainName.Returns("Polkadot");
           _logger = Substitute.For<ILogger<EraStakersCommandHandler>>();
            _stakingDatabaseRepository = new StakingDatabaseRepository(_substrateDbContext,
                                                                       Substitute.For<ILogger<StakingDatabaseRepository>>(),
                                                                       _substrateService);

            _useCase = new EraStakersCommandHandler(_stakingDatabaseRepository,
                                                    _substrateService,
                                                    _logger,
                                                    Substitute.For<IDistributedCache>());
        }

        private IQueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure> mockStakersQueryStorage()
        {
            var mockReturn = new List<(BaseTuple<U32, SubstrateAccount>, Exposure)>() {
                new(
                    mockEraAndValidator(),
                    mockExposure()
                )
            };

            // Create a mock instance of the QueryStorage class
            var mockQueryStorage = Substitute.For<IQueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>>();
            // Set up the mock to return the real list of data
            mockQueryStorage.StorageFunctionAsync(Arg.Any<QueryStorageFunction>(), Arg.Any<QueryFilterFunction>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(mockReturn));

            mockQueryStorage.ExecuteAsync(Arg.Any<CancellationToken>()).Returns(Task.FromResult(mockReturn));

            return mockQueryStorage;
        }

        private Exposure mockExposure()
        {
            return new Exposure(
                                    new BaseCom<U128>(10),
                                    new BaseCom<U128>(20),
                                    new BaseVec<IndividualExposure>(
                                        [
                                            new IndividualExposure(new SubstrateAccount(Alice.ToString()), new BaseCom<U128>(100))
                                        ]
                                    )
                                );
        }

        private BaseTuple<U32, SubstrateAccount> mockEraAndValidator()
        {
            return new BaseTuple<U32, SubstrateAccount>(
                                    new U32(1),
                                    new SubstrateAccount(Alice.ToString())
                                   );
        }

        [Test]
        public async Task EraStakersCommandValidator_WithInvalidEraId_ShouldFailAsync()
        {
            _substrateService.Storage.Staking.CurrentEraAsync(CancellationToken.None).Returns(new U32(100));

            var command = new EraStakersCommand()
            {
                EraId = 20
            };

            var validator = new EraStakersCommandValidator(_substrateService);

            var result = await validator.ValidateAsync(command);

            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public async Task ErasStakers_WithNoResult_ShouldFailAsync()
        {
            // Mock
            var storageFunctionAsyncMock = Substitute.For<
                Func<QueryStorageFunction, QueryFilterFunction, CancellationToken, Task<List<(BaseTuple<U32, SubstrateAccount>, Exposure)>>>
                >();
            var mockQueryStorage = new QueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure>(storageFunctionAsyncMock, new QueryStorageFunction("module", "method", typeof(U32), typeof(U32)));
            _substrateService.Storage.Staking.ErasStakersQueryAsync(Arg.Any<uint>(), Arg.Any<CancellationToken>()).Returns(mockQueryStorage);

            var command = new EraStakersCommand()
            {
                EraId = 20
            };

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsError, Is.True);
        }

        [Test]
        public async Task ErasStakers_WithResult_ShouldSucceedAsync()
        {
            IQueryStorage<BaseTuple<U32, SubstrateAccount>, Exposure> mockQueryStorage = mockStakersQueryStorage();

            _substrateService.Storage.Staking.ErasStakersQueryAsync(Arg.Any<uint>(), Arg.Any<CancellationToken>()).Returns(mockQueryStorage);

            _substrateService.Storage.Staking.ErasStakersAsync(Arg.Any<BaseTuple<U32, SubstrateAccount>>(), CancellationToken.None).Returns(mockExposure());

            var command = new EraStakersCommand()
            {
                EraId = 20,
                OverrideIfAlreadyExist = false
            };

            var result = await _useCase!.Handle(command, CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True);

            Assert.That(_substrateDbContext.EraStakersModels.Count(), Is.EqualTo(1));

            var entry = _substrateDbContext.EraStakersModels.First();
            Assert.That(entry.TotalStake, Is.EqualTo(new BigInteger(10)));
            Assert.That(entry.EraNominatorsVote.Count(), Is.EqualTo(1));

            var nominator = entry.EraNominatorsVote.First();
            Assert.That(nominator.ValueStake, Is.EqualTo(new BigInteger(100)));

            // No override
            var result2 = await _useCase!.Handle(command, CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True);

            Assert.That(_substrateDbContext.EraStakersModels.Count(), Is.EqualTo(1));
        }

        
    }
}
