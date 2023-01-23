using Microsoft.Extensions.Logging;
using NSubstitute;
using Substats.Domain.Contracts.Dto.Parachain;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Parachain;
using Substats.Domain.UseCase.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Tests.UseCase.Parachain
{
    internal class ParachainDetailUseCaseTest : UseCaseTest<ParachainDetailUseCase, ParachainDto, ParachainCommand>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<ParachainDetailUseCase>>();
            _useCase = new ParachainDetailUseCase(_logger);
            base.Setup();
        }
    }
}
