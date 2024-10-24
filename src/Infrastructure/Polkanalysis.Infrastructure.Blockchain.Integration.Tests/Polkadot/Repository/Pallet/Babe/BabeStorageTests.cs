using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Babe
{
    public class BabeStorageTests : PolkadotIntegrationTest
    {

        public static IEnumerable<(int, string, string, int)>
            AuthorithiesVersionTestCases = new List<(int, string, string, int)>()
        {
            (7500000, "0x9c40155989f6072e82caba245d7db7e40a60f866b403257976b89aba6be2b55b", "0x400d13b56ef1afbfd04d089717a828fe15af3ffd2809decbc580d78be630e81a", 1),
            (10000000, "0xaaf2ec61d23ac5c99332d22967b60c9f7b3e97651a418be4fe9a26e940c3bd7b", "0x40884e6b9876fe866d109aae2a5a6f1a18bfe3655ec9c1fee848ca9273446872", 1),
            (12400000, "0xaaf2ec61d23ac5c99332d22967b60c9f7b3e97651a418be4fe9a26e940c3bd7b", "0x40884e6b9876fe866d109aae2a5a6f1a18bfe3655ec9c1fee848ca9273446872", 1),
            (16500000, "0x8c5f63f7c23d8274ef6068b883922870a4b2096983388ce13e89ca6d4b588f39", "0x40884e6b9876fe866d109aae2a5a6f1a18bfe3655ec9c1fee848ca9273446872", 1),
        };

        [Test]
        [TestCaseSource(nameof(AuthorithiesVersionTestCases))]
        public async Task Authorities_ShouldWorkAsync((int numBlock, string firstAuthorityAddress, string lastAuthorityAddress, int num) input)
        {
            var res = await _substrateRepository.At(input.numBlock).Storage.Babe.AuthoritiesAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Length, Is.GreaterThan(1));

            var firstAuthority = res.Value.First().Value[0].As<PublicSr25519>().ToHex();
            Assert.That(firstAuthority.ToUpper(), Is.EqualTo(input.firstAuthorityAddress.ToUpper()));
            Assert.That(((U64)res.Value.First().Value[1]).Value, Is.EqualTo((ulong)input.num));

            var lastAuthority = res.Value.Last().Value[0].As<PublicSr25519>().ToHex();
            Assert.That(lastAuthority.ToUpper(), Is.EqualTo(input.lastAuthorityAddress.ToUpper()));
            Assert.That(((U64)res.Value.Last().Value[1]).Value, Is.EqualTo((ulong)input.num));

        }

        [Test]
        [TestCaseSource(nameof(BlockFromVersion9090))]
        public async Task AuthorVrfRandomness_ShouldWorkAsync(int numBlock)
        {
            var res = await _substrateRepository.At(numBlock).Storage.Babe.AuthorVrfRandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        public static IEnumerable<(int, ulong)>
            CurrentSlotVersionTestCases = new List<(int, ulong)>()
        {
            (7500000, 272614847),
            (12800000, 277949962),
            (13000000, 278150234),
            (16500000, 281660882),
        };

        [Test]
        [TestCaseSource(nameof(CurrentSlotVersionTestCases))]
        public async Task CurrentSlot_ShouldWorkAsync((int numBlock, ulong value) input)
        {
            var res = await _substrateRepository.At(input.numBlock).Storage.Babe.CurrentSlotAsync(CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Value, Is.EqualTo(input.value));
        }

        [Test, Ignore(NoTestCase)]
        public async Task PendingEpochConfigChange_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.PendingEpochConfigChangeAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EpochConfig_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.EpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task NextEpochConfig_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.NextEpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task Randomness_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.RandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
        [Test]
        public async Task NextRandomness_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.NextRandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task UnderConstruction_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.UnderConstructionAsync(new U32(0), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore(NoTestCase)]
        public async Task Initialized_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Babe.InitializedAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
