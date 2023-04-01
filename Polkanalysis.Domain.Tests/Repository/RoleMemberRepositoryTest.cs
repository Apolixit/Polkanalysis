using NSubstitute;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Repository
{
    public class RoleMemberRepositoryTest
    {
        protected IExplorerRepository _explorerRepository;
        protected ISubstrateRepository _substrateRepository;
        private IRoleMemberRepository _roleMemberRepository;

        [SetUp]
        public void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _substrateRepository = Substitute.For<ISubstrateRepository>();


            _roleMemberRepository = new PolkadotRoleMemberRepository(
                _substrateRepository,
                Substitute.For<IAccountRepository>(),
                Substitute.For<INode>());
        }

        [Test]
        public void NullOrEmptyAddress_ShouldFailed()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetValidatorDetailAsync(null, CancellationToken.None));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _roleMemberRepository.GetNominatorDetailAsync(null, CancellationToken.None));

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
