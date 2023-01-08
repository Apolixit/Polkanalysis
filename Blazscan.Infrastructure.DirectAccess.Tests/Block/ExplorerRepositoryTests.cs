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

namespace Blazscan.Infrastructure.DirectAccess.Tests.Block
{
    public abstract class ExplorerRepositoryTests
    {
        protected IExplorerRepository _blockRepository;
        protected ISubstrateNodeRepository _substrateService;
        protected ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _blockRepository = Substitute.For<IExplorerRepository>();
            _substrateService = Substitute.For<ISubstrateNodeRepository>();
            _substrateDecode = Substitute.For<ISubstrateDecoding>();
        }

        
    }
}
