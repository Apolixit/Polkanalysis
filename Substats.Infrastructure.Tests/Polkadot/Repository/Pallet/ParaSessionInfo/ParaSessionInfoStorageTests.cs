using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.ParaSessionInfo
{
    public class ParaSessionInfoStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task AssignmentKeysUnsafe_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<
                        Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.assignment_app.Public>();
            coreResult.Create("0x081C9A9A52E094114C0C1CD1AF7B0F7F2023B34B78AD842A87AF690AECBF2DA7258AC16E2487AE411A37A41F7A086824B2EFD39C94B3494EFA7C1B708E360B380C");

            var expectedResult = new BaseVec<PublicSr25519>(
                new PublicSr25519[]
                {
                    new PublicSr25519("0x1c9a9a52e094114c0c1cd1af7b0f7f2023b34b78ad842a87af690aecbf2da725"),
                    new PublicSr25519("0x8ac16e2487ae411a37a41f7a086824b2efd39c94b3494efa7c1b708e360b380c"),
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.ParaSessionInfo.AssignmentKeysUnsafeAsync);
        }

        [Test]
        public async Task AssignmentKeysUnsafeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.ParaSessionInfo.AssignmentKeysUnsafeAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task EarliestStoredSession_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync);
        }

        [Test]
        public async Task EarliestStoredSessionNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync);
        }

        /// <summary>
        /// To create this unit test, I used real Sessions call from integration test and then I splitted datas to keep a simple version (just kept the 2 first results from each list)
        /// So here is the JSON display of this UT :
        /// {
        ///   activeValidatorIndices: [
        ///     144
        ///     81
        ///   ]
        ///   randomSeed: 0xd385f13394068e87b0cf39c525782df628ea9a5d41364914cae4a951eb7c3359
        ///   disputePeriod: 6
        ///   validators: [
        ///     0xdc23d2e5dd85889560c2c3dc197cb19e0b2e2698ee79a4aea14234a0ee823a3d
        ///     0xe24208a0bbbb7035130798abba24cab205d22443e8973817b685f13c9012b97c
        ///   ]
        ///   discoveryKeys: [
        ///     0xa4ec26f9ba0e8d613485b10581faacb3630801881552a23eb0e7cbe4df3c9473
        ///     0x9eb30a9abe2de835e3229d8c3cd6b00e936d5339b325684a5c483b15420e123c
        ///   ]
        ///   assignmentKeys: [
        ///     0xc29a602efbf32a378c6bd435b93d44bf996c58a2bc03e540729551aa52b4bf1e
        ///     0xca80ef8c5a7f17dda7b9554e659d2b24c2373f3dcd7473bf12aefe152f200333
        ///   ]
        ///   validatorGroups: [
        ///     [
        ///       0
        ///       1
        ///       2
        ///       3
        ///       4
        ///     ]
        ///     [
        ///       5
        ///       6
        ///       7
        ///       8
        ///       9
        ///     ]
        ///   ]
        ///   nCores: 43
        ///   zerothDelayTrancheWidth: 0
        ///   relayVrfModuloSamples: 40
        ///   nDelayTranches: 89
        ///   noShowSlots: 2
        ///   neededApprovals: 30
        /// }
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Sessions_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.SessionInfo();
            IEnumerable<byte> encoded =
                Ajuna.NetApi.Utils.HexToByteArray("0x089000000051000000") // ActiveValidatorIndices
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0xD385F13394068E87B0CF39C525782DF628EA9A5D41364914CAE4A951EB7C3359")) // RandomSeed
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x06000000")) // DisputePeriod
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x08DC23D2E5DD85889560C2C3DC197CB19E0B2E2698EE79A4AEA14234A0EE823A3DE24208A0BBBB7035130798ABBA24CAB205D22443E8973817B685F13C9012B97C")) // Validators
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x08A4EC26F9BA0E8D613485B10581FAACB3630801881552A23EB0E7CBE4DF3C94739EB30A9ABE2DE835E3229D8C3CD6B00E936D5339B325684A5C483B15420E123C")) // DiscoveryKeys
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x08C29A602EFBF32A378C6BD435B93D44BF996C58A2BC03E540729551AA52B4BF1ECA80EF8C5A7F17DDA7B9554E659D2B24C2373F3DCD7473BF12AEFE152F200333")) // AssignmentKeys
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x08140000000001000000020000000300000004000000140500000006000000070000000800000009000000")) // ValidatorGroups
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x2B000000")) // NCores
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x00000000")) // ZerothDelayTrancheWidth
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x28000000")) // RelayVrfModuloSamples
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x59000000")) // NDelayTranches
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x02000000")) // NoShowSlots
                .Concat(Ajuna.NetApi.Utils.HexToByteArray("0x1E000000")); // NeededApprovals

            coreResult.Create(encoded.ToArray());

            var expectedResult = new SessionInfo(
                new BaseVec<U32>(new U32[] { new U32(144), new U32(81) }),
                new Domain.Contracts.Core.Random.Hexa("0xd385f13394068e87b0cf39c525782df628ea9a5d41364914cae4a951eb7c3359"),
                new U32(6),
                new BaseVec<PublicSr25519>(new PublicSr25519[] { 
                    new PublicSr25519("0xdc23d2e5dd85889560c2c3dc197cb19e0b2e2698ee79a4aea14234a0ee823a3d"), 
                    new PublicSr25519("0xe24208a0bbbb7035130798abba24cab205d22443e8973817b685f13c9012b97c"), 
                }),
                new BaseVec<PublicSr25519>(new PublicSr25519[] {
                    new PublicSr25519("0xa4ec26f9ba0e8d613485b10581faacb3630801881552a23eb0e7cbe4df3c9473"),
                    new PublicSr25519("0x9eb30a9abe2de835e3229d8c3cd6b00e936d5339b325684a5c483b15420e123c"),
                }),
                new BaseVec<PublicSr25519>(new PublicSr25519[] {
                    new PublicSr25519("0xc29a602efbf32a378c6bd435b93d44bf996c58a2bc03e540729551aa52b4bf1e"),
                    new PublicSr25519("0xca80ef8c5a7f17dda7b9554e659d2b24c2373f3dcd7473bf12aefe152f200333"),
                }),
                new BaseVec<BaseVec<U32>>(new BaseVec<U32>[]
                {
                    new BaseVec<U32>(new U32[] { new U32(0), new U32(1), new U32(2), new U32(3), new U32(4)}),
                    new BaseVec<U32>(new U32[] { new U32(5), new U32(6), new U32(7), new U32(8), new U32(9)}),
                }),
                new U32(43), new U32(0), new U32(40), new U32(89), new U32(2), new U32(30)
            );

            await MockStorageCallWithInputAsync(new U32(1), coreResult, expectedResult, _substrateRepository.Storage.ParaSessionInfo.SessionsAsync);
        }

        [Test]
        public async Task SessionsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.ParaSessionInfo.SessionsAsync);
        }

        [Test]
        public async Task AccountKeys_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<AccountId32>();
            coreResult.Create("0x087E74E295C040927DE4200C770994A314185D3EE447BE3D70C79ED056FDD1AC533C017930B46AB5A4413BF3153B001287ED5FF7FDBD2734CF69ABC843F4EE0447");

            var expectedResult = new BaseVec<SubstrateAccount>(
                new SubstrateAccount[]
                {
                    new SubstrateAccount("13rokpqWneXxGjE8y2YF6H7MtRvqGTqkPR332e3vvMRJet3a"),
                    new SubstrateAccount("12MgK2Sc8Rrh6DXS2gDrt7fWJ24eGeVb23NALbZLMw1grnkL"),
                }    
            );

            await MockStorageCallWithInputAsync(new U32(6114), coreResult, expectedResult, _substrateRepository.Storage.ParaSessionInfo.AccountKeysAsync);
        }

        [Test]
        public async Task AccountKeysNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.ParaSessionInfo.AccountKeysAsync);
        }
    }
}
