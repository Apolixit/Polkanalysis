using Microsoft.Extensions.Logging;
using NSubstitute;
using Substats.Domain.Contracts.Dto.Module;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Module;
using Substats.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Tests.UseCase.Nominator
{
    internal class NominatorDetailUseCaseTest : UseCaseTest<NominatorDetailUseCase, NominatorDto, NominatorCommand>
    {
        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<NominatorDetailUseCase>>();
            _useCase = new NominatorDetailUseCase(_logger);
            base.Setup();
        }
    }
}
