using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.UseCase.Runtime;
using Polkanalysis.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.Tests.UseCase.Nominator
{
    public class NominatorDetailUseCaseTest : UseCaseTest<NominatorDetailUseCase, NominatorDto, NominatorDetailQuery>
    {
        private IStakingRepository _roleMemberRepository;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<NominatorDetailUseCase>>();
            _roleMemberRepository = Substitute.For<IStakingRepository>();

            _useCase = new NominatorDetailUseCase(_roleMemberRepository, _logger);
            base.Setup();
        }
    }
}
