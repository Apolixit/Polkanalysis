using Algolia.Search.Models.Common;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Extrinsics;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Errors;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;

namespace Polkanalysis.Domain.Tests.UseCase.Monitored
{
    public class SavedExtrinsicsHandlerTest : UseCaseTest<SavedExtrinsicsHandler, bool, SavedExtrinsicsCommand>
    {
        private IExplorerService _explorerService;
        private ISubstrateDecoding _substrateDecoding;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SavedExtrinsicsHandler>>();
            _explorerService = Substitute.For<IExplorerService>();
            _substrateDecoding = Substitute.For<ISubstrateDecoding>();

            //_explorerService.GetBlockLightAsync(Arg.Any<uint>(), Arg.Any<CancellationToken>()).Returns(
            //    new Contracts.Dto.Block.BlockLightDto()
            //    {
            //        Hash = new Hash("0x1234567890"),
            //        Number = 1,
            //        Status = Contracts.Dto.GlobalStatusDto.BlockStatusDto.Finalized,
            //        BlockDate = DateTime.Now,
            //        When = DateTime.Now.ToString(),
            //        NbEvents = 1,
            //        NbExtrinsics = 1,
            //        NbLogs = 1,
            //        ValidatorIdentity = new UserIdentityDto()
            //        {
            //            Name = "Alice",
            //            Address = Alice.ToString(),
            //            PublicKey = Utils.Bytes2HexString(Alice.Bytes)
            //        },
            //        ValidatorAddress = Alice.ToString()
            //    });

            _substrateService.BlockchainName.Returns("Polkadot");

            _useCase = new SavedExtrinsicsHandler(_substrateService,
                                              _explorerService,
                                              _substrateDbContext,
                                              _logger,
                                              Substitute.For<IDistributedCache>(),
                                              _substrateDecoding, 
                                              Substitute.For<ICoreService>());
        }

        /// <summary>
        /// Mock a KilledAccount event
        /// </summary>
        /// <returns></returns>
        private EventRecord buildKilledAccountEvent()
        {
            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var killedAccountEvent = new EnumEvent();

            killedAccountEvent.Create(Event.KilledAccount, new SubstrateAccount(Alice.ToString()));
            runtimeEvent.Create(RuntimeEvent.System, killedAccountEvent);

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(runtimeEvent), topics);
            return firstEvent;
        }

        private IExtrinsic standardExtrinsicMock()
        {
            EventRecord killedAccountEvent = buildKilledAccountEvent();
            var mockExtrinsic = new TempOldExtrinsic("0x41028400AE5B1DD41CCA2BB6875D240A28724C6977CF3E80B9AB24EE2A7B0A856BC8D86801E8D5AA83C3D6040D2935470D46601C4E219E91BB155B44C831D1607625EBEA0341067CAC1B8BA8625A0ECB10BB0EAB4FE152F67F4059E8732A51D993C90B0D84F502A400050300EA9F7DD7160C14CF17861D8024DCD20D1D914D5DAC47915CD06EF7B2671F51500700E5025793", ChargeTransactionPayment.Default());
            var hash = new Hash("0x00");
            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), CancellationToken.None).Returns(hash);
            _substrateService.Rpc.Chain.GetBlockAsync(hash, CancellationToken.None).Returns(
                new TempOldBlockData(
                    new TempOldBlock()
                    {
                        Header = new Substrate.NetApi.Model.Rpc.Header()
                        {
                            Number = new U64(1_000_000)
                        },
                        Extrinsics = new List<TempOldExtrinsic>([mockExtrinsic]).ToArray()
                    }, null)
                );
            _substrateService.At(Arg.Any<uint>()).Storage.System.EventsAsync(CancellationToken.None).Returns(
                new BaseVec<EventRecord>([killedAccountEvent])
            );

            _explorerService.GetExtrinsicsStatusAsync(Arg.Any<EventRecord[]>(), Arg.Any<int>(), CancellationToken.None).Returns(Contracts.Dto.Extrinsic.ExtrinsicStatusDto.Success());
            _explorerService.GetExtrinsicsFeesAsync(Arg.Any<EventRecord[]>(), Arg.Any<int>(), CancellationToken.None).ReturnsNull();
            _explorerService.GetExtrinsicsLifetimeAsync(Arg.Any<uint>(), mockExtrinsic, CancellationToken.None).Returns(new Contracts.Dto.Extrinsic.LifetimeDto()
            {
                IsImmortal = false,
                FromBlock = 1,
                ToBlock = 10
            });

            return mockExtrinsic;
        }

        [Test]
        public async Task SavedBlocksHandler_WithValidData_ShouldSucceedAsync()
        {
            var mockExtrinsic = standardExtrinsicMock();
            _substrateDecoding.DecodeExtrinsicAsync(mockExtrinsic, Arg.Any<Hash>(), CancellationToken.None).Returns(new GenericNode()
            {
                Name = "Timestamp",
                Children = new List<INode>([ new GenericNode()
                {
                    Name = "set"
                }])
            });

            var command = new SavedExtrinsicsCommand(1);

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            var firstDb = _substrateDbContext.ExtrinsicsInformation.FirstOrDefault();
            Assert.That(firstDb, Is.Not.Null);
            Assert.That(firstDb.Status, Is.EqualTo("Success"));
        }

        [Test]
        public async Task SavedBlocksHandler_WithDecodedError_ShouldLogAndFailAsync()
        {
            var mockExtrinsic = standardExtrinsicMock();
            _substrateDecoding.DecodeExtrinsicAsync(mockExtrinsic, Arg.Any<Hash>(), CancellationToken.None).ThrowsAsync<Exception>();

            var command = new SavedExtrinsicsCommand(1);

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsError, Is.True);

            var firstDb = _substrateDbContext.SubstrateErrors.FirstOrDefault();
            Assert.That(firstDb, Is.Not.Null);
            Assert.That(firstDb.TypeError, Is.EqualTo(TypeErrorModel.Extrinsics));
        }

        
    }
}
