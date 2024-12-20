﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras.Enums;
using RuntimeParachainsExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_runtime_parachains.paras;
using ParachainPrimitivesExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives;
using PrimitivesV2Ext = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_primitives.v2;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.ParasStorage
{
    public class ParaStorageTests : PolkadotMock
    {
        [Test]
        [Ignore("TODO find test")]
        public async Task PvfActiveVoteMap_ShouldWorkAsync()
        {
            var coreResult = new RuntimeParachainsExt.PvfCheckActiveVoteState();

            var expectedResult = new PvfCheckActiveVoteState();

            await MockStorageCallWithInputAsync(new Hash("Hash"), coreResult, expectedResult, _substrateService.Storage.Paras.PvfActiveVoteMapAsync);
        }

        [Test]
        public async Task PvfActiveVoteMapNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Hash, RuntimeParachainsExt.PvfCheckActiveVoteState,
                PvfCheckActiveVoteState>(new Hash("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB"), _substrateService.Storage.Paras.PvfActiveVoteMapAsync);
        }

        [Test]
        public async Task PvfActiveVoteList_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<ParachainPrimitivesExt.ValidationCodeHash>();
            coreResult.Create("0x049C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB");

            var expectedResult = new BaseVec<Hash>(new Hash[] {
                new Hash("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB")
            });

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Paras.PvfActiveVoteListAsync);
        }

        [Test]
        public async Task PvfActiveVoteListNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseVec<
                    ParachainPrimitivesExt.ValidationCodeHash>,
                BaseVec<Hash>>(_substrateService.Storage.Paras.PvfActiveVoteListAsync);
        }

        [Test]
        public async Task Parachains_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<ParachainPrimitivesExt.Id>();
            coreResult.Create("0x08E8030000E9030000");

            var expectedResult = new BaseVec<Id>();
            expectedResult.Create(new Id[] {
                new Id(1000),
                new Id(1001),
            });

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Paras.ParachainsAsync);
        }

        [Test]
        public async Task ParachainsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseVec<ParachainPrimitivesExt.Id>,
                 BaseVec<Id>>(_substrateService.Storage.Paras.ParachainsAsync);
        }

        [Test]
        public async Task ParaLifecycles_ShouldWorkAsync()
        {
            var coreResult = new RuntimeParachainsExt.EnumParaLifecycle();
            coreResult.Create(RuntimeParachainsExt.ParaLifecycle.Parachain);

            var expectedResult = new EnumParaLifecycle();
            expectedResult.Create(Contracts.Pallet.Paras.Enums.ParaLifecycle.Parachain);

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.ParaLifecyclesAsync);
        }

        [Test]
        public async Task ParaLifecyclesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                 RuntimeParachainsExt.EnumParaLifecycle,
                 EnumParaLifecycle>(new Id(1), _substrateService.Storage.Paras.ParaLifecyclesAsync);
        }

        [Test]
        public async Task Heads_ShouldWorkAsync()
        {
            var coreResult = new ParachainPrimitivesExt.HeadData();
            coreResult.Create("0xE90268D00B822D44D8CAEEBC484B5822B6A40D2DABC5E1BC8D5CCDD4DE11DD69F5B596FD0B00E33D514E525B14C4326C3514FD9F164B1CBF38D30B8ED4996AB98BBD805A5F30A3E46970B690A290B804338A6715321CECFC6879143AC0C8E66AC5E41C4E7010080661757261203813570800000000056175726101016EBE124E2E70844236E508890E0D9E68E2304552D7402753B2BF22837052FD2EA6E2CD1854A13A926561EA26D60C037B5C1C67405565BCFC4FAC38A6B1748385");

            var expectedResult = new DataCode();
            expectedResult.Create("0xE90268D00B822D44D8CAEEBC484B5822B6A40D2DABC5E1BC8D5CCDD4DE11DD69F5B596FD0B00E33D514E525B14C4326C3514FD9F164B1CBF38D30B8ED4996AB98BBD805A5F30A3E46970B690A290B804338A6715321CECFC6879143AC0C8E66AC5E41C4E7010080661757261203813570800000000056175726101016EBE124E2E70844236E508890E0D9E68E2304552D7402753B2BF22837052FD2EA6E2CD1854A13A926561EA26D60C037B5C1C67405565BCFC4FAC38A6B1748385");

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.HeadsAsync);
        }

        [Test]
        public async Task HeadsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                 ParachainPrimitivesExt.HeadData,
                 DataCode>(new Id(2094), _substrateService.Storage.Paras.HeadsAsync);
        }

        [Test]
        public async Task CurrentCodeHash_ShouldWorkAsync()
        {
            var coreResult = new ParachainPrimitivesExt.ValidationCodeHash();
            coreResult.Create("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB");

            var expectedResult = new Hash("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB");

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.CurrentCodeHashAsync);
        }

        [Test]
        public async Task CurrentCodeHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                 ParachainPrimitivesExt.ValidationCodeHash,
                 Hash>(new Id(2094), _substrateService.Storage.Paras.CurrentCodeHashAsync);
        }

        [Test]
        [TestCase("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB")]
        public async Task PastCodeHash_ShouldWorkAsync(string hash)
        {
            var coreResult = new ParachainPrimitivesExt.ValidationCodeHash();
            coreResult.Create(hash);

            var expectedResult = new Hash(hash);

            var result = await MockStorageCallWithInputAsync(new BaseTuple<Id, U32>(new Id(2094), new U32(1)), coreResult, expectedResult, _substrateService.Storage.Paras.PastCodeHashAsync);

            Assert.That(Utils.Bytes2HexString(result.Bytes), Is.EqualTo(hash));
        }

        [Test]
        public async Task PastCodeHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<BaseTuple<Id, U32>,
                ParachainPrimitivesExt.ValidationCodeHash,
                Hash>(new BaseTuple<Id, U32>(new Id(2094), new U32(1)), _substrateService.Storage.Paras.PastCodeHashAsync);
        }

        [Test]
        public async Task PastCodeMeta_ShouldWorkAsync()
        {
            var coreResult = new RuntimeParachainsExt.ParaPastCodeMeta();
            coreResult.Create("0x00017737DE00");

            var expectedResult = new ParaPastCodeMeta(
                new BaseVec<ReplacementTimes>(new ReplacementTimes[] { }),
                new BaseOpt<U32>(new U32(14563191)));

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.PastCodeMetaAsync);
        }

        [Test]
        public async Task PastCodeMetaNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                RuntimeParachainsExt.ParaPastCodeMeta,
                ParaPastCodeMeta>(new Id(2094), _substrateService.Storage.Paras.PastCodeMetaAsync);
        }

        [Test]
        public async Task PastCodePruning_ShouldWorkAsync()
        {
            var id = new ParachainPrimitivesExt.Id();
            id.Create("0x01000000");

            var coreResult = new BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>();
            coreResult.Create(new BaseTuple<ParachainPrimitivesExt.Id, U32>[]
                {
                    new BaseTuple<ParachainPrimitivesExt.Id, U32>(id, new U32(1))
                });

            var expectedResult = new BaseVec<BaseTuple<Id, U32>>(
                new BaseTuple<Id, U32>[]
                {
                    new BaseTuple<Id, U32>(new Id(1), new U32(1))
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Paras.PastCodePruningAsync);
        }

        [Test]
        public async Task PastCodePruningNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>,
                BaseVec<BaseTuple<Id, U32>>>(_substrateService.Storage.Paras.PastCodePruningAsync);
        }

        [Test]
        public async Task FutureCodeUpgrades_ShouldWorkAsync()
        {
            var coreResult = new U32();
            coreResult.Create("0x01000000");

            var expectedResult = new U32(1);

            await MockStorageCallWithInputAsync(new Id(1), coreResult, expectedResult, _substrateService.Storage.Paras.FutureCodeUpgradesAsync);
        }

        [Test]
        public async Task FutureCodeUpgradesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new Id(1), _substrateService.Storage.Paras.FutureCodeUpgradesAsync);
        }

        [Test]
        public async Task FutureCodeHash_ShouldWorkAsync()
        {
            var coreResult = new ParachainPrimitivesExt.ValidationCodeHash();
            coreResult.Create("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB");

            var expectedResult = new Hash("0x9C900905BF8CB084BE9CE07BFC122857071F81D53142B25F5FEA04986E5D79AB");

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.FutureCodeHashAsync);
        }

        [Test]
        public async Task FutureCodeHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                 ParachainPrimitivesExt.ValidationCodeHash,
                 Hash>(new Id(2094), _substrateService.Storage.Paras.FutureCodeHashAsync);
        }

        [Test]
        public async Task UpgradeGoAheadSignal_ShouldWorkAsync()
        {
            var coreResult = new PrimitivesV2Ext.EnumUpgradeGoAhead();
            coreResult.Create(PrimitivesV2Ext.UpgradeGoAhead.GoAhead);

            var expectedResult = new EnumUpgradeGoAhead();
            expectedResult.Create(UpgradeGoAhead.GoAhead);

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.UpgradeGoAheadSignalAsync);
        }

        [Test]
        public async Task UpgradeGoAheadSignalNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Id,
                PrimitivesV2Ext.EnumUpgradeGoAhead,
                EnumUpgradeGoAhead>(new Id(2094), _substrateService.Storage.Paras.UpgradeGoAheadSignalAsync);
        }

        [Test]
        public async Task UpgradeRestrictionSignal_ShouldWorkAsync()
        {
            var coreResult = new PrimitivesV2Ext.EnumUpgradeRestriction();
            coreResult.Create(PrimitivesV2Ext.UpgradeRestriction.Present);

            var expectedResult = new EnumUpgradeRestriction();
            expectedResult.Create(UpgradeRestriction.Present);

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateService.Storage.Paras.UpgradeRestrictionSignalAsync);
        }

        [Test]
        public async Task UpgradeRestrictionSignalNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Id,
                PrimitivesV2Ext.EnumUpgradeRestriction,
                EnumUpgradeRestriction>(new Id(2094), _substrateService.Storage.Paras.UpgradeRestrictionSignalAsync);
        }

        [Test]
        public async Task UpgradeCooldowns_ShouldWorkAsync()
        {
            var id = new ParachainPrimitivesExt.Id();
            id.Create("0x01000000");

            var coreResult = new BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>();
            coreResult.Create(new BaseTuple<ParachainPrimitivesExt.Id, U32>[]
                {
                    new BaseTuple<ParachainPrimitivesExt.Id, U32>(id, new U32(1))
                });

            var expectedResult = new BaseVec<BaseTuple<Id, U32>>(
                new BaseTuple<Id, U32>[]
                {
                    new BaseTuple<Id, U32>(new Id(1), new U32(1))
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Paras.UpgradeCooldownsAsync);
        }

        [Test]
        public async Task UpgradeCooldownsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>,
                BaseVec<BaseTuple<Id, U32>>
                >(_substrateService.Storage.Paras.UpgradeCooldownsAsync);
        }

        [Test]
        public async Task UpcomingUpgrades_ShouldWorkAsync()
        {
            var id = new ParachainPrimitivesExt.Id();
            id.Create("0x01000000");

            var coreResult = new BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>();
            coreResult.Create(new BaseTuple<ParachainPrimitivesExt.Id, U32>[]
                {
                    new BaseTuple<ParachainPrimitivesExt.Id, U32>(id, new U32(1))
                });

            var expectedResult = new BaseVec<BaseTuple<Id, U32>>(
                new BaseTuple<Id, U32>[]
                {
                    new BaseTuple<Id, U32>(new Id(1), new U32(1))
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Paras.UpcomingUpgradesAsync);
        }

        [Test]
        public async Task UpcomingUpgradesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseTuple<ParachainPrimitivesExt.Id, U32>>,
                BaseVec<BaseTuple<Id, U32>>
                >(_substrateService.Storage.Paras.UpcomingUpgradesAsync);
        }

        [Test]
        public async Task ActionsQueue_ShouldWorkAsync()
        {
            var id = new ParachainPrimitivesExt.Id();
            id.Create("0x01000000");

            var coreResult = new BaseVec<ParachainPrimitivesExt.Id>();
            coreResult.Create(new ParachainPrimitivesExt.Id[] { id });

            var expectedResult = new BaseVec<Id>(
                new Id[] { new Id(1) }
            );

            await MockStorageCallWithInputAsync(new U32(1), coreResult, expectedResult, _substrateService.Storage.Paras.ActionsQueueAsync);
        }

        [Test]
        public async Task ActionsQueueNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<U32,
                BaseVec<ParachainPrimitivesExt.Id>,
                BaseVec<Id>>(new U32(1), _substrateService.Storage.Paras.ActionsQueueAsync);
        }

        [Test]
        [Ignore("Todo find good test")]
        public async Task UpcomingParasGenesis_ShouldWorkAsync()
        {
            var coreResult = new RuntimeParachainsExt.ParaGenesisArgs();

            var expectedResult = new ParaGenesisArgs();

            await MockStorageCallWithInputAsync(new Id(1), coreResult, expectedResult, _substrateService.Storage.Paras.UpcomingParasGenesisAsync);
        }

        [Test]
        public async Task UpcomingParasGenesisNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Id,
                RuntimeParachainsExt.ParaGenesisArgs,
                ParaGenesisArgs>(new Id(1), _substrateService.Storage.Paras.UpcomingParasGenesisAsync);
        }

        [Test]
        public async Task CodeByHashRefs_ShouldWorkAsync()
        {
            var input = new Hash();
            input.Create("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab");

            var expectedResult = new U32(1);

            await MockStorageCallWithInputAsync(input, expectedResult, _substrateService.Storage.Paras.CodeByHashRefsAsync);
        }

        [Test]
        public async Task CodeByHashRefsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new Hash("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab"), _substrateService.Storage.Paras.CodeByHashRefsAsync);
        }

        [Test]
        [Ignore("Response too long todo debug")]
        public async Task CodeByHash_ShouldWorkAsync()
        {
            var input = new Hash("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab");

            var coreResult = new ParachainPrimitivesExt.ValidationCode();
            coreResult.Create("0x52bc537646db8e0528b52ffd00588454058ec14668155310480b291d80119800c008e433ad990f0926591c7c9afc8dd71f5b53056d14365de7242059ed0a9fbd8de1ce56ba4744009ba31fac38d31d5b3b410d0dd59b6863af8555956");

            var expectedResult = new DataCode("0x52bc537646db8e0528b52ffd00588454058ec14668155310480b291d80119800c008e433ad990f0926591c7c9afc8dd71f5b53056d14365de7242059ed0a9fbd8de1ce56ba4744009ba31fac38d31d5b3b410d0dd59b6863af8555956");

            await MockStorageCallWithInputAsync(input, coreResult, expectedResult, _substrateService.Storage.Paras.CodeByHashAsync);
        }

        [Test]
        public async Task CodeByHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new Hash("0x9c900905bf8cb084be9ce07bfc122857071f81d53142b25f5fea04986e5d79ab"), _substrateService.Storage.Paras.CodeByHashRefsAsync);
        }
    }
}
