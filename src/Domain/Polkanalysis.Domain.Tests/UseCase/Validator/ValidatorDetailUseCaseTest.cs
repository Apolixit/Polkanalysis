using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.UseCase.Staking.Validator;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Tests.UseCase.Validator
{
    public class ValidatorDetailUseCaseTest : UseCaseTest<ValidatorDetailHandler, ValidatorDto, ValidatorDetailQuery>
    {
        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<ValidatorDetailHandler>>();
            _useCase = new ValidatorDetailHandler(Substitute.For<IStakingService>(), _logger, Substitute.For<IDistributedCache>());
            //base.Setup();
        }
    }
}
