using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Module;
using Polkanalysis.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Nominator
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
