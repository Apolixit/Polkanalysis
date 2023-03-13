using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Display;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools;
using Substats.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.NominationPools
{
    public class NominationPoolsStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task MinJoinBond_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MinJoinBondAsync);
        }

        [Test]
        public async Task MinJoinBondNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.MinJoinBondAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task MinCreateBond_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MinCreateBondAsync);
        }

        [Test]
        public async Task MinCreateBondNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.MinCreateBondAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MaxPools_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MaxPoolsAsync);
        }

        [Test]
        public async Task MaxPoolsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.MaxPoolsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MaxPoolMembers_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MaxPoolMembersAsync);
        }

        [Test]
        public async Task MaxPoolMembersNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.MaxPoolMembersAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MaxPoolMembersPerPool_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MaxPoolMembersAsync);
        }

        [Test]
        public async Task MaxPoolMembersPerPoolNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.MaxPoolMembersPerPoolAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForPoolMembers_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MaxPoolMembersAsync);
        }

        [Test]
        public async Task CounterForPoolMembersNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForPoolMembersAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForBondedPools_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.MaxPoolMembersAsync);
        }

        [Test]
        public async Task CounterForBondedPoolsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForBondedPoolsAsync);
        }

        [Test]
        public async Task PoolMembers_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember();
            coreResult.Create("0x010000009F5B4BC9B500000000000000000000006A0B97D2D0178D00000000000000000000");

            var expectedResult = new PoolMember(
                new U32(1), 
                new U128(780766239647), 
                new U128(39714157369953130), 
                new BaseVec<BaseTuple<U32, U128>>());

            await MockStorageCallWithInputAsync
                (new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.NominationPools.PoolMembersAsync);
        }

        [Test]
        public async Task PoolMembersNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.PoolMember,
                PoolMember>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.NominationPools.PoolMembersAsync);
        }

        [Test]
        public async Task BondedPools_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner();
            coreResult.Create("0x45408D5E38C90400000000000000000000B80100003C92BC22C4934341504E8B6F0755BB76906171BCF8A55C49A78E2055DDD28802013C92BC22C4934341504E8B6F0755BB76906171BCF8A55C49A78E2055DDD28802013C92BC22C4934341504E8B6F0755BB76906171BCF8A55C49A78E2055DDD28802013C92BC22C4934341504E8B6F0755BB76906171BCF8A55C49A78E2055DDD28802");

            var expectedResult = new BondedPoolInner(
                new U128(1347143848509509),
                new EnumPoolState(PoolState.Open),
                new U32(440),
                new PoolRoles(
                    new SubstrateAccount("12NRTphLWqYK5Tri7V2aVGcXWuJ78NFPPjwSN9ZkUxLhCa78"),
                    new BaseOpt<SubstrateAccount>(new SubstrateAccount("12NRTphLWqYK5Tri7V2aVGcXWuJ78NFPPjwSN9ZkUxLhCa78")),
                    new BaseOpt<SubstrateAccount>(new SubstrateAccount("12NRTphLWqYK5Tri7V2aVGcXWuJ78NFPPjwSN9ZkUxLhCa78")),
                    new BaseOpt<SubstrateAccount>(new SubstrateAccount("12NRTphLWqYK5Tri7V2aVGcXWuJ78NFPPjwSN9ZkUxLhCa78"))
                )
            );

            await MockStorageCallWithInputAsync
                (new U32(1), coreResult, expectedResult, _substrateRepository.Storage.NominationPools.BondedPoolsAsync);
        }

        [Test]
        public async Task BondedPoolsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondedPoolInner,
                BondedPoolInner>
                (new U32(1), _substrateRepository.Storage.NominationPools.BondedPoolsAsync);
        }

        [Test]
        public async Task RewardPools_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.RewardPool();
            coreResult.Create("0x93EED213FC32CB0000000000000000008D58FA27B21F0000000000000000000034E489F83E1800000000000000000000");

            var expectedResult = new RewardPool(
                new U128(57195478518001299),   
                new U128(34850035357837),   
                new U128(26658736825396)   
            );

            await MockStorageCallWithInputAsync
                (new U32(1), coreResult, expectedResult, _substrateRepository.Storage.NominationPools.RewardPoolsAsync);
        }

        [Test]
        public async Task RewardPoolsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.RewardPool,
                RewardPool>
                (new U32(1), _substrateRepository.Storage.NominationPools.RewardPoolsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForRewardPools_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task CounterForRewardPoolsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task SubPoolsStorage_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.SubPools();
            coreResult.Create("0x9D41C0E4430A000000000000000000009D41C0E4430A0000000000000000000050F40300003F739C5AFD00000000000000000000003F739C5AFD0000000000000000000000F60300002071F9245F06000000000000000000002071F9245F0600000000000000000000F80300000010ACD15300000000000000000000000010ACD1530000000000000000000000F903000000C033C504010000000000000000000000C033C5040100000000000000000000FB030000004429353A0000000000000000000000004429353A0000000000000000000000FC0300000070C9B28B00000000000000000000000070C9B28B0000000000000000000000FD03000000E8764817000000000000000000000000E87648170000000000000000000000FF03000000487835A3020000000000000000000000487835A30200000000000000000000020400004EC429DA0501000000000000000000004EC429DA050100000000000000000000030400000010A5D4E800000000000000000000000010A5D4E80000000000000000000000040400004F836B4E1000000000000000000000004F836B4E10000000000000000000000006040000428012402A0100000000000000000000428012402A010000000000000000000008040000004647FB170000000000000000000000004647FB17000000000000000000000009040000004429353A0000000000000000000000004429353A00000000000000000000000A040000B90FB3A4130100000000000000000000B90FB3A41301000000000000000000000B04000014F401A11C000000000000000000000014F401A11C00000000000000000000000C040000C326B5B6430200000000000000000000C326B5B64302000000000000000000000F04000000C817A804000000000000000000000000C817A8040000000000000000000000100400001558E2F40D2E000000000000000000001558E2F40D2E0000000000000000000011040000EC7515E3600200000000000000000000EC7515E3600200000000000000000000");

            var expectedResult = new SubPools(
                new UnbondPool(new U128(11286716891549), new U128(11286716891549)),
                new BaseVec<BaseTuple<U32, UnbondPool>>(new BaseTuple<U32, UnbondPool>[] {
                    new BaseTuple<U32, UnbondPool>(
                        new U32(1012), 
                        new UnbondPool(new U128(1088146928447), new U128(1088146928447))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1014),
                        new UnbondPool(new U128(7005711986976), new U128(7005711986976))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1016),
                        new UnbondPool(new U128(360000000000), new U128(360000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1017),
                        new UnbondPool(new U128(1120000000000), new U128(1120000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1019),
                        new UnbondPool(new U128(250000000000), new U128(250000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1020),
                        new UnbondPool(new U128(600000000000), new U128(600000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1021),
                        new UnbondPool(new U128(100000000000), new U128(100000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1023),
                        new UnbondPool(new U128(2900000000000), new U128(1120000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1026),
                        new UnbondPool(new U128(1124646634574), new U128(1124646634574))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1027),
                        new UnbondPool(new U128(1000000000000), new U128(1000000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1028),
                        new UnbondPool(new U128(70035145551), new U128(70035145551))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1030),
                        new UnbondPool(new U128(1280975208514), new U128(1280975208514))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1032),
                        new UnbondPool(new U128(103000000000), new U128(103000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1033),
                        new UnbondPool(new U128(250000000000), new U128(250000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1034),
                        new UnbondPool(new U128(1183879204793), new U128(1183879204793))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1035),
                        new UnbondPool(new U128(122960344084), new U128(122960344084))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1036),
                        new UnbondPool(new U128(2489851389635), new U128(2489851389635))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1039),
                        new UnbondPool(new U128(20000000000), new U128(20000000000))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1040),
                        new UnbondPool(new U128(50637477926933), new U128(50637477926933))),

                    new BaseTuple<U32, UnbondPool>(
                        new U32(1041),
                        new UnbondPool(new U128(2615149950444), new U128(2615149950444))),
                }));

            await MockStorageCallWithInputAsync
                (new U32(1), coreResult, expectedResult, _substrateRepository.Storage.NominationPools.SubPoolsStorageAsync);
        }

        [Test]
        public async Task SubPoolsStorageNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.SubPools,
                SubPools>
                (new U32(1), _substrateRepository.Storage.NominationPools.SubPoolsStorageAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForSubPoolsStorage_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task CounterForSubPoolsStorageNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForSubPoolsStorageAsync);
        }

        [Test]
        public async Task Metadata_ShouldWorkAsync()
        {
            var coreResult = new BoundedVecT28();
            coreResult.Create("0x99012331202D2050617261646F78207C20506172614E6F6465732E696F20F09F9A80202D204E6F6D696E6174696E6720747275737465642076616C696461746F7273207769746820686967682072657475726E7320616E642074696D656C79207061796F7574732E");

            var expectedResult = new Nameable().FromText("�\u0001#1 - Paradox | ParaNodes.io 🚀 - Nominating trusted validators with high returns and timely payouts.");

            await MockStorageCallWithInputAsync
                (new U32(1), coreResult, expectedResult, _substrateRepository.Storage.NominationPools.MetadataAsync);
        }

        [Test]
        public async Task MetadataNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                BoundedVecT28,
                Nameable>
                (new U32(1), _substrateRepository.Storage.NominationPools.MetadataAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForMetadata_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task CounterForMetadataNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForMetadataAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task LastPoolId_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task LastPoolIdNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.LastPoolIdAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task ReversePoolIdLookup_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task ReversePoolIdLookupNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync
                (new SubstrateAccount(MockAddress), _substrateRepository.Storage.NominationPools.ReversePoolIdLookupAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForReversePoolIdLookup_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.NominationPools.CounterForRewardPoolsAsync);
        }

        [Test]
        public async Task CounterForReversePoolIdLookupNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.NominationPools.CounterForReversePoolIdLookupAsync);
        }
    }
}
