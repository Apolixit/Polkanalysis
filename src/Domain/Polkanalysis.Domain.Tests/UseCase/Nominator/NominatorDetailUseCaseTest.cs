using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Staking.Nominator;
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.Tests.UseCase.Nominator
{
    public class NominatorDetailUseCaseTest : UseCaseTest<NominatorDetailHandler, NominatorDto, NominatorDetailQuery>
    {
        private IStakingService _roleMemberRepository;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<NominatorDetailHandler>>();
            _roleMemberRepository = Substitute.For<IStakingService>();

            _useCase = new NominatorDetailHandler(_roleMemberRepository, _logger, Substitute.For<IDistributedCache>());
            //base.Setup();
        }
    }
}
