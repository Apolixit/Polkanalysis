using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Parachain;
using Polkanalysis.Domain.UseCase.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Parachain
{
    public class ParachainDetailUseCaseTest : UseCaseTest<ParachainDetailHandler, ParachainDto, ParachainDetailQuery>
    {
        protected IParachainService _parachainRepository;
        [SetUp]
        public override void Setup()
        {
            _parachainRepository = Substitute.For<IParachainService>();
            _logger = Substitute.For<ILogger<ParachainDetailHandler>>();
            _useCase = new ParachainDetailHandler(_parachainRepository, _logger);
            base.Setup();
        }
    }
}
