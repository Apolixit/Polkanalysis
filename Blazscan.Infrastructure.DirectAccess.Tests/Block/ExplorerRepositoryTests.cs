using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi;
using Blazscan.Domain.Contracts.Secondary;
using Newtonsoft.Json.Linq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Domain.Contracts.Dto;
using Microsoft.Extensions.Logging;

namespace Blazscan.Infrastructure.DirectAccess.Tests.Block
{
    public abstract class ExplorerRepositoryTests
    {
        protected IExplorerRepository _explorerRepository;
        protected ISubstrateNodeRepository _substrateService;
        protected ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateService = Substitute.For<ISubstrateNodeRepository>();
            _substrateDecode = Substitute.For<ISubstrateDecoding>();

            _explorerRepository = new ExplorerRepositoryDirectAccess(
                _substrateService,
                _substrateDecode,
                Substitute.For<IModelBuilder>(),
                Substitute.For<ILogger<ExplorerRepositoryDirectAccess>>());
            
            
        }

        
    }
}
