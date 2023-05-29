using Polkanalysis.Domain.UseCase.Validator;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;

namespace Polkanalysis.Domain.Tests.UseCase.Validator
{
    public class ValidatorDetailUseCaseTest : UseCaseTest<ValidatorDetailUseCase, ValidatorDto, ValidatorDetailQuery>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<ValidatorDetailUseCase>>();
            _useCase = new ValidatorDetailUseCase(_logger);
            base.Setup();
        }
    }
}
