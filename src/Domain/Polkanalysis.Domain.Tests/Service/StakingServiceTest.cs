using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.Tests.Service
{
    public class StakingServiceTest : DomainTestAbstract
    {
        protected IExplorerService _explorerRepository;
        protected ISubstrateService _substrateRepository;
        private IStakingService _roleMemberRepository;

        [SetUp]
        public void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerService>();
            _substrateRepository = Substitute.For<ISubstrateService>();


            _roleMemberRepository = new StakingService(
                _substrateRepository,
                Substitute.For<IAccountService>(),
                Substitute.For<IStakingDatabaseRepository>(),
                Substitute.For<ILogger<StakingService>>(),
                _substrateDbContext);
        }

        [Test]
        public void NullOrEmptyAddress_ShouldFailed()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetValidatorDetailAsync(null!, CancellationToken.None));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetNominatorDetailAsync(null!, CancellationToken.None));

            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetValidatorDetailAsync(string.Empty, CancellationToken.None));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetNominatorDetailAsync(string.Empty, CancellationToken.None));
        }

        [Test]
        public void InvalidAddress_ShouldFailed()
        {
            _substrateRepository.IsValidAccountAddress(Arg.Any<string>()).Returns(false);

            Assert.ThrowsAsync<AddressException>(async () => await _roleMemberRepository.GetValidatorDetailAsync("invalidAddress", CancellationToken.None));
            Assert.ThrowsAsync<AddressException>(async () => await _roleMemberRepository.GetNominatorDetailAsync("invalidAddress", CancellationToken.None));
        }
    }
}
