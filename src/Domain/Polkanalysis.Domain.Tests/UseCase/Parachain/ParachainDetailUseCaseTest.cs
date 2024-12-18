using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Parachain;

namespace Polkanalysis.Domain.Tests.UseCase.Parachain
{
    public class ParachainDetailUseCaseTest : UseCaseTest<ParachainDetailHandler, ParachainDto, ParachainDetailQuery>
    {
        protected IParachainService _parachainRepository;

        [SetUp]
        public void Setup()
        {
            _parachainRepository = Substitute.For<IParachainService>();
            _logger = Substitute.For<ILogger<ParachainDetailHandler>>();
            _useCase = new ParachainDetailHandler(_parachainRepository, _logger, Substitute.For<HybridCache>());
            //base.Setup();
        }
    }
}
