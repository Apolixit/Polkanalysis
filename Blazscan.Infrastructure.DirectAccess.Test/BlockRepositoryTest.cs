using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Infrastructure.DirectAccess.Repository;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Test
{
    public class BlockRepositoryTest
    {
        private readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IBlockRepository _blockRepository;

        public BlockRepositoryTest() {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));
            _blockRepository = new BlockRepositoryDirectAccess(_substrateRepository);
        }

        [OneTimeSetUp]
        public async Task Connect()
        {
            if(!_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.ConnectAsync();
            }
        }

        [OneTimeTearDown]
        public async Task Disconnect()
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
            Assert.IsNotNull(blockInfo);

        }

        [Test]
        [TestCase(13210791)]
        public async Task GetBlockDetails_ValidBlockNumber_2_ShouldWork(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId);
            Assert.IsNotNull(blockInfo);

        }
    }
}
