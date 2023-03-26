using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi;
using Polkanalysis.Domain.Contracts.Secondary;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;

namespace Polkanalysis.Domain.Tests.Repository.Block
{
    public abstract class ExplorerRepositoryTests
    {
        protected IExplorerRepository _explorerRepository;
        protected ISubstrateRepository _substrateService;
        protected ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateRepository>();
            _substrateDecode = Substitute.For<ISubstrateDecoding>();

            _explorerRepository = new PolkadotExplorerRepository(
                _substrateService,
                _substrateDecode,
                Substitute.For<IModelBuilder>(),
                Substitute.For<ILogger<PolkadotExplorerRepository>>());


        }


    }
}
