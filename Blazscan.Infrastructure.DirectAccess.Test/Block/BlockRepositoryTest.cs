using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.SubstrateDecode;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using NSubstitute;

namespace Blazscan.Infrastructure.DirectAccess.Test.Block
{
    public class BlockRepositoryTest
    {
        private readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IBlockRepository _blockRepository;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ISubstrateDecoding _substrateDecoding;

        public BlockRepositoryTest()
        {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));

            _currentMetaData = new CurrentMetaData(_substrateRepository);

            _substrateDecoding = new SubstrateDecoding(new EventMapping(), _substrateRepository, new PalletBuilder(_substrateRepository, _currentMetaData));

            _blockRepository = new BlockRepositoryDirectAccess(_substrateRepository, _substrateDecoding);
        }

        [OneTimeSetUp]
        public async Task ConnectAsync()
        {
            if (!_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.ConnectAsync();
            }
        }

        [OneTimeTearDown]
        public async Task DisconnectAsync()
        {
            if (_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.CloseAsync();
            }
        }

        [Test]
        [TestCase(13198574)]
        public async Task GetBlockDetails_ValidBlockNumber_ShouldWork(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId);
            Assert.IsNull(blockInfo);

        }

        [Test]
        [TestCase(13210791)]
        public async Task GetBlockDetails_ValidBlockNumber_2_ShouldWork(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId);
            Assert.IsNull(blockInfo);

        }

        [Test]
        [TestCase(13278242)]
        public async Task GetBlockDetails_ValidBlockNumber_3_ShouldWork(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId);
            Assert.IsNull(blockInfo);

        }

        [Test]
        [TestCase(13406835)]
        public async Task GetBlockDetails_ValidBlockNumber_4_ShouldWork(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId);
            Assert.IsNull(blockInfo);

        }

        //[Test]
        //[TestCase("0x9d492b0f85248f25822b2ff88b9b91b42dbaf1cc6b070f59d945cbd7fa453be3")]
        //public async Task GetExtrinsic_ShouldWork(string extrinsicHash)
        //{
        //    var extrinsic = new Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
        //    //var _substrateDecode = new SubstrateDecoding(new EventMapping(), _substrateRepository, new PalletBuilder(_substrateRepository, Substitute.For<ICurrentMetaData>()));
        //    var res = _substrateDecoding.DecodeExtrinsic(extrinsic);
        //    Assert.IsTrue(true);
        //}
    }
}
