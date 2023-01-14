using Substats.Domain.Contracts.Dto;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Module;
using Substats.Domain.UseCase.Validator;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Tests.UseCase.Validator
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
