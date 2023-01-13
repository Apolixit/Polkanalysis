using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Domain.Dto;
using Blazscan.Domain.Runtime;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Integration.Tests.Contracts;
using Blazscan.Polkadot.NetApiExt.Generated.Storage;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using System.Threading;

namespace Blazscan.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Block
{
    public abstract class ExplorerRepositoryTest : PolkadotIntegrationTest
    {
        protected IExplorerRepository _blockRepository;
        protected ICurrentMetaData _currentMetaData;
        protected ISubstrateDecoding _substrateDecoding;

        // https://polkadot.subscan.io/block/10219793
        //  Block with extrinsic failed
        [SetUp]
        public void Setup()
        {
            _currentMetaData = new CurrentMetaData(
                _substrateRepository, Substitute.For<ILogger<CurrentMetaData>>());

            _substrateDecoding = new SubstrateDecoding(
                new EventMapping(), 
                _substrateRepository, 
                new PalletBuilder(
                    _substrateRepository, 
                    _currentMetaData),
                Substitute.For<ILogger<SubstrateDecoding>>());
            _blockRepository = new ExplorerRepositoryDirectAccess(
                _substrateRepository, 
                _substrateDecoding,
                new ModelBuilder(),
                Substitute.For<ILogger<ExplorerRepositoryDirectAccess>>());
        }
    }
}
