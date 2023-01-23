using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi;
using Substats.Domain.Contracts.Secondary;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Runtime;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;

namespace Substats.Infrastructure.DirectAccess.Tests.Repository.Block
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
