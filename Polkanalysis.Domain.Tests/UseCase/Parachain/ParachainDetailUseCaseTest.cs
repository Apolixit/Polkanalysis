using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Parachain;
using Polkanalysis.Domain.UseCase.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Parachain
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
