using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Module;
using Polkanalysis.Domain.UseCase.Validator;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.User;

namespace Polkanalysis.Domain.Tests.UseCase.Validator
{
    public class ValidatorDetailUseCaseTest : UseCaseTest<ValidatorDetailUseCase, ValidatorDto, ValidatorCommand>
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
