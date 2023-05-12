using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Parachain;
using Polkanalysis.Domain.UseCase.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Parachain
{
    public class ParachainDetailUseCaseTest : UseCaseTest<ParachainDetailUseCase, ParachainDto, ParachainDetailQuery>
    {
        protected IParachainRepository _parachainRepository;
        [SetUp]
        public override void Setup()
        {
            _parachainRepository = Substitute.For<IParachainRepository>();
            _logger = Substitute.For<ILogger<ParachainDetailUseCase>>();
            _useCase = new ParachainDetailUseCase(_parachainRepository, _logger);
            base.Setup();
        }
    }
}
