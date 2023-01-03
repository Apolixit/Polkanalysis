﻿using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace Blazscan.Domain.Tests.Runtime.Event
{
    public class ParaInclusionEventTest : MainEventTest
    {

        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        [TestCase("0x00010000003500E903000039D33729AEFAA9EBDC83F2DD0C04AA73AD6E3CD69D56B2FD8CC8617D965CE5BB866697928238E7CB51D2049373397570C61767E8325F666BE16BFC202EB44119CEB9CB6328AA06BB70EAA962D98B27AE42C37E97D63728ED402EB10C8625C6871154F3F12AC683E515F353B02CC75F2E8A3B0F036AB8339F574EB0E18AC0A1B992139A7C81EE111175B1584C83845DD8D8CC8EF68CEE83782C489E80F28D337DB055944CD78497E14852544562D731E9990F7E73ABFA6B7FADF73FA399AD5714B6DD977A467F3984D4D9438DBBD63E671E60BE1E0477765D8BFE40236581C0897DE86D7BDCCF4F1BA5AE1A54B871FCAC2DDCD4CA0DF019BC06CC0829DE5980A46C68260EDDF3A551FA5869ED17183CB6639ADC400E63D4F60D92CA8E1A5C805AF7AC5B4ED944097BE3C1AC0138C953093500FBA5F3366F7EC62E4772FEB7F633E902C9731DFE23A4C8730A9DF334EEAF0443E696EBE15A9B977F4A81EB298CC46C70A2BD0500EACE1236FABE274FA53CF71AE0A851B7157FCC083F990667D222FA283EC1650F3AAB8AE4F9D6B2E19939E3F3B73504CF96386B4261BAB98565BC7D62B1527535080661757261209BBA4B0800000000056175726101012C2279A0AB51C3DFE60734BA33D25992E167AAF680F6274E03B1CA88A87F3244822EE78D267A7E76179096A46E656284232D1175EB521A275D57B2BED2914788010000000400000000")]
        public void ParaInclusion_CandidateBacked_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.ParaInclusion));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.inclusion.pallet.Event.CandidateBacked));
        }

        [Test]
        [TestCase("0x00010000003501E9030000F31D2AB23BD6CF4E33B141EAB8935641E51D35BF95B7A1B1A8D4336A5E08D696F440DBABAAC86F79815109D4FEE2BDDFD1F296487D004CC8A049838779BC627DD92190810ADD16D7F1F0D30A0D1C4F069B2CFD25E76E1DD29E7E26A85F753D197E472803338F6114B7261EAF206696DA03A4D58D5538A77550A4F504DE01CE6BCB74A5B9618DBBD366D31EC9037E79533FAEE6BA6423224CC5546EBAF03D17777C025DA549AE0EBDFFF4A9E51583C0D954D9BB9238AC8C4DFAF2A8A64B2B4E203D3CE8D63C6C3EC45E27C6AC7991076BABB5059F7EB919981AF18928201D9F8CC8B92E6F48F78E9084D9F8B622955E26D0E845CA50F5163ADE9807DE9621707B6C68260EDDF3A551FA5869ED17183CB6639ADC400E63D4F60D92CA8E1A5C805ADC537ACFBB76FF527ECAF8334159F88409442DF641593444FEB96A8BB2208377E902B8C46A92D60837188A66A619487BE7AF4431114D4A4F84FDC807A95400B4189B963C0800E6575DB5EAF263E16FD2E2797E4BFD20353A0484613EC6ABAF018DFC3AABCF743208A287A10AE81520D1D2A2E290CB010B29C68A0D3AED211B41FE4B50489ADE08066175726120BA5B4C0800000000056175726101014C4F631E503B273D608797B7B326320788A9FDFC6327C3C79BA7B19E7126B6286DD04838E00BF722B5791C97681FB4390638C00B49CF982B2C83E2E99FC49580010000000D00000000")]
        public void ParaInclusion_CandidateBackedToDto_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.ParaInclusion));
            //Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Withdraw));
        }

        /// <summary>
        /// First ParaInclusion event of block n°13,586,896
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x2c1fa9cdbce35b82b905c32898d2fe26df58dd4bf26d8d6c84293cbaa7f4384f
        /// JSON :
        /// {
        ///     phase: {
        ///    ApplyExtrinsic: 1
        ///  }
        ///  event: {
        ///  method: CandidateIncluded
        ///  section: paraInclusion
        ///  index: 0x3501
        ///    data:
        ///      [
        ///      {
        ///      descriptor:
        ///          {
        ///          paraId: 1,000
        ///          relayParent: 0xf370074154a619588d58c268c4cb34a41c84af1638f44ee2e78993d6316f0aa8
        ///          collator: 0x727b41760c649015e4766b30a6297ebe58312eb79ba73053c816e1139bdde016
        ///          persistedValidationDataHash: 0x68cb29347675d4638f3ed7542ac00a7103403a5950ea7983ca90cb059e3ad015
        ///          povHash: 0xe9ab33a6928efbf6fb7d028871bed7df798193bf53b4265121329402d4279c0f
        ///          erasureRoot: 0x1e36dd22e9f80674cc19ec1c3adfb2321ca3d7e33c1b6223dcda0c630fcd78ac
        ///          signature: 0x52defcd12e584c8c731e0b4a27689c563b9d05611894773ad3b4b0c44d85f03ce4cbc93a95eb1f84d0bb3659f55f416087e3c95a35cee0238a5f528a01de418a
        ///          paraHead: 0x27b98686814ce4b1f64dbaa7282968d69011d4bf9a86f5045a3a2db6f081d4d0
        ///          validationCodeHash: 0x6d3551e75c9d5c3e8641d1b56b6a72273ed9333d86fc0032ac17d0904e1742b1
        ///        }
        ///      commitmentsHash: 0x293effec1b705c3c7f2a7ba9486d3740d87266ae0ab616750c0b370e85162860
        ///      }
        ///      0xcaf7227ef5f8bd81bbc5e0386ef531ea47b2b5bc61c5b02f173d764f5e7e7d510a22b000bc7ab6cde07b993d260a03e0c0ec4b9b069bda1d1b5f5f1fb38359d7f87fd7843ce902e54e45912c7ac3a05d3c38315b60de67a7bfcdcf980c4ae081ec7ed56f080661757261202e9b4e080000000005617572610101b158e2db125553abc0e2dacb956ef62a29a5b871bb64337be42a6167c7f034ca46bf5bce30ff50c505510814c8313380aebee940da86b4ed144723de22a7a40b
        ///      0
        ///      36
        ///      ]
        ///    }
        ///    topics: []
        ///}
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000003501E8030000F370074154A619588D58C268C4CB34A41C84AF1638F44EE2E78993D6316F0AA8727B41760C649015E4766B30A6297EBE58312EB79BA73053C816E1139BDDE01668CB29347675D4638F3ED7542AC00A7103403A5950EA7983CA90CB059E3AD015E9AB33A6928EFBF6FB7D028871BED7DF798193BF53B4265121329402D4279C0F1E36DD22E9F80674CC19EC1C3ADFB2321CA3D7E33C1B6223DCDA0C630FCD78AC52DEFCD12E584C8C731E0B4A27689C563B9D05611894773AD3B4B0C44D85F03CE4CBC93A95EB1F84D0BB3659F55F416087E3C95A35CEE0238A5F528A01DE418A27B98686814CE4B1F64DBAA7282968D69011D4BF9A86F5045A3A2DB6F081D4D06D3551E75C9D5C3E8641D1B56B6A72273ED9333D86FC0032AC17D0904E1742B1293EFFEC1B705C3C7F2A7BA9486D3740D87266AE0AB616750C0B370E85162860E902CAF7227EF5F8BD81BBC5E0386EF531EA47B2B5BC61C5B02F173D764F5E7E7D510A22B000BC7AB6CDE07B993D260A03E0C0EC4B9B069BDA1D1B5F5F1FB38359D7F87FD7843CE902E54E45912C7AC3A05D3C38315B60DE67A7BFCDCF980C4AE081EC7ED56F080661757261202E9B4E080000000005617572610101B158E2DB125553ABC0E2DACB956EF62A29A5B871BB64337BE42A6167C7F034CA46BF5BCE30FF50C505510814C8313380AEBEE940DA86B4ED144723DE22A7A40B000000002400000000")]
        public void ParaInclusion_CandidateIncluded_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.ParaInclusion));
            //Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Withdraw));
        }
    }
}
