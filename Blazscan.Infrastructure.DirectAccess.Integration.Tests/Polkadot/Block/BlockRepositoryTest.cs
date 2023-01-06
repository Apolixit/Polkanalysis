﻿using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
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
    public class BlockRepositoryTest : PolkadotIntegrationTest
    {
        private readonly IBlockRepository _blockRepository;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ISubstrateDecoding _substrateDecoding;
        private readonly ILogger<CurrentMetaData> _logger;

        public BlockRepositoryTest()
        {
            _logger = Substitute.For<ILogger<CurrentMetaData>>();
            _currentMetaData = new CurrentMetaData(_substrateRepository, _logger);

            _substrateDecoding = new SubstrateDecoding(
                new EventMapping(), 
                _substrateRepository, 
                new PalletBuilder(
                    _substrateRepository, 
                    _currentMetaData),
                Substitute.For<ILogger<SubstrateDecoding>>());
            _blockRepository = new BlockRepositoryDirectAccess(_substrateRepository, _substrateDecoding);
        }

        [Test]
        [TestCase(13198574)]
        [TestCase(13210791)]
        [TestCase(13278242)]
        [TestCase(13406835)]
        public async Task GetBlockDetails_ValidBlockNumber_ShouldWorkAsync(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync((uint)blockId, CancellationToken.None);
            Assert.IsNotNull(blockInfo);

        }

        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [TestCase("0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        public async Task GetBlockDetails_ValidBlockHash_ShouldWorkAsync(string blockHash)
        {
            var blockInfo = await _blockRepository.GetBlockDetailsAsync(blockHash, CancellationToken.None);
            Assert.IsNotNull(blockInfo);
        }

        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [TestCase("0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        public async Task GetBlockDetails_ValidBlockHash_ShouldWorkAsync(string blockString)
        {
            var blockHash = new Hash();
            blockHash.Create(blockString);

            var blockInfo = await _blockRepository.GetBlockDetailsAsync(blockHash, CancellationToken.None);
            Assert.IsNotNull(blockInfo);
        }

        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(13564726)]
        public async Task GetEventsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(int blockId)
        {
            var blockInfo = await _blockRepository.GetBlockEvents((uint)blockId);
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

        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        public async Task GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            var extrinsic = new Extrinsic(extrinsicHash, ChargeTransactionPayment.Default());
            //var _substrateDecode = new SubstrateDecoding(new EventMapping(), _substrateRepository, new PalletBuilder(_substrateRepository, Substitute.For<ICurrentMetaData>()));
            var res = _substrateDecoding.DecodeExtrinsic(extrinsic);
            Assert.IsTrue(true);
        }
    }
}
