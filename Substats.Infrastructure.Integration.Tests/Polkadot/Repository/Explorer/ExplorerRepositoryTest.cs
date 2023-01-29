using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Dto;
using Substats.Domain.Runtime;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using Substats.Polkadot.NetApiExt.Generated.Storage;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using System.Threading;
using Substats.Domain.Runtime.Module;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Block
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
                _currentMetaData,
                Substitute.For<ILogger<SubstrateDecoding>>());
            _blockRepository = new PolkadotExplorerRepository(
                _substrateRepository, 
                _substrateDecoding,
                new ModelBuilder(),
                Substitute.For<ILogger<PolkadotExplorerRepository>>());
        }
    }
}
