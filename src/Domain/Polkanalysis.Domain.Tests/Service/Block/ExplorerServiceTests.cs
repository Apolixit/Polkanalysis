using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Tests.Service.Block
{
    public abstract class ExplorerServiceTests
    {
        protected IExplorerService _explorerRepository;
        protected ISubstrateService _substrateService;
        protected ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateService>();
            _substrateDecode = Substitute.For<ISubstrateDecoding>();

            _explorerRepository = new ExplorerService(
                _substrateService,
                _substrateDecode,
                Substitute.For<IAccountService>(),
                Substitute.For<ILogger<ExplorerService>>());


        }


    }
}
