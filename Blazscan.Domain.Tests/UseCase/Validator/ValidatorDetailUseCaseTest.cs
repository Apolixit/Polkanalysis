using Blazscan.Domain.Contracts.Dto;
using Blazscan.Domain.Contracts.Primary;
using Blazscan.Domain.UseCase.Module;
using Blazscan.Domain.UseCase.Validator;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.UseCase.Validator
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
