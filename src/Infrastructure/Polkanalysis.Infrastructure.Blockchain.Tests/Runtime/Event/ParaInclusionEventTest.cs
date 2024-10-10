﻿using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using PolkadotRuntime = Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Runtime;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class ParaInclusionEventTest : MainEventTest
    {

        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test, Ignore("Debug Event updates")]
        [TestCase("0x00010000003500D2070000569443704D65208FC2B79AEE6D072934CC4C35C47734973D86E5C43C8A4F063FB48BD5B696D07CD6A332C559F58D3DA058E3B1779950E4B605B0E6EA77CFC75F89BA8D9CE29BDD68C0D4C78D9EDB829FE0BCD5500CE37903AF4922FB41265266A782F202F1A6C0D5BCF70687E5E993456FE19A81195E69214517006147A40FC867B0776114F47A2D018EC5EC4392C600BA6CAED2E1E2158257455CE6E472F7A44CDBC0B0A0984A4BBD48B4CCF7037D3F04496F97BC11EAC72141F5C738B1C775D5906B29CE3E662454B7BA8249821A4561BD40DECCB24DF76C3465AB69D68989699BDE26125E72C7A057E3C527420586D0AA7DAD118C178C7E14E449D5A5FB1E32283647AC87830D1B136BCE5FE3BAD5ACBA67ADD2A89F005497D93FAC9E5D20C1A4B661E74721D5A2FD537E155E22ADFF145024DE0FCAA9C41E14432AD70CCE89036BCAD8CD2E57D1FECCAD32E200C443AC8A71FEFC26D83DD392D91232870A422C0E2EC200019372F886C4DEE04D8B867D5810B5063D1813EE117125B5F2DF94B8C7BED6EBC8A6F1278357066AE8D4B2EABE55FCC59731D9263E0B082B394A0143AC2C25990C0661757261200667B110000000000466726F6E880153A6F3FCF48A3F15A27E5746E60EDA9A683BA674D040030A57BAB1D1A6AC6DD00005617572610101C659384F9967D8F8BBC584A6C1A59E7C96C3FFB4867E96CFE5987F00E1BDC27A98AF400D05BBDF2119C7F50AC06E125EEEBC6833D0AF10C9F5E871393FD1E18B030000001E00000000")]
        public async Task ParaInclusion_CandidateBacked_ShouldBeParsedAsync(string hex)
        {
            var coreEvent = new EventRecord();
            coreEvent.Create(hex);

            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.ParaInclusion));
            Assert.That(nodeResult.Method, Is.EqualTo(Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.Event.CandidateBacked));
        }

        [Test, Ignore("Debug Event updates")]
        [TestCase("0x00010000003501E9030000F31D2AB23BD6CF4E33B141EAB8935641E51D35BF95B7A1B1A8D4336A5E08D696F440DBABAAC86F79815109D4FEE2BDDFD1F296487D004CC8A049838779BC627DD92190810ADD16D7F1F0D30A0D1C4F069B2CFD25E76E1DD29E7E26A85F753D197E472803338F6114B7261EAF206696DA03A4D58D5538A77550A4F504DE01CE6BCB74A5B9618DBBD366D31EC9037E79533FAEE6BA6423224CC5546EBAF03D17777C025DA549AE0EBDFFF4A9E51583C0D954D9BB9238AC8C4DFAF2A8A64B2B4E203D3CE8D63C6C3EC45E27C6AC7991076BABB5059F7EB919981AF18928201D9F8CC8B92E6F48F78E9084D9F8B622955E26D0E845CA50F5163ADE9807DE9621707B6C68260EDDF3A551FA5869ED17183CB6639ADC400E63D4F60D92CA8E1A5C805ADC537ACFBB76FF527ECAF8334159F88409442DF641593444FEB96A8BB2208377E902B8C46A92D60837188A66A619487BE7AF4431114D4A4F84FDC807A95400B4189B963C0800E6575DB5EAF263E16FD2E2797E4BFD20353A0484613EC6ABAF018DFC3AABCF743208A287A10AE81520D1D2A2E290CB010B29C68A0D3AED211B41FE4B50489ADE08066175726120BA5B4C0800000000056175726101014C4F631E503B273D608797B7B326320788A9FDFC6327C3C79BA7B19E7126B6286DD04838E00BF722B5791C97681FB4390638C00B49CF982B2C83E2E99FC49580010000000D00000000")]
        public async Task ParaInclusion_CandidateBackedToDto_ShouldBeParsedAsync(string hex)
        {
            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.ParaInclusion));
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
        [Test, Ignore("Debug Event updates")]
        [TestCase("0x00010000003501E8030000F370074154A619588D58C268C4CB34A41C84AF1638F44EE2E78993D6316F0AA8727B41760C649015E4766B30A6297EBE58312EB79BA73053C816E1139BDDE01668CB29347675D4638F3ED7542AC00A7103403A5950EA7983CA90CB059E3AD015E9AB33A6928EFBF6FB7D028871BED7DF798193BF53B4265121329402D4279C0F1E36DD22E9F80674CC19EC1C3ADFB2321CA3D7E33C1B6223DCDA0C630FCD78AC52DEFCD12E584C8C731E0B4A27689C563B9D05611894773AD3B4B0C44D85F03CE4CBC93A95EB1F84D0BB3659F55F416087E3C95A35CEE0238A5F528A01DE418A27B98686814CE4B1F64DBAA7282968D69011D4BF9A86F5045A3A2DB6F081D4D06D3551E75C9D5C3E8641D1B56B6A72273ED9333D86FC0032AC17D0904E1742B1293EFFEC1B705C3C7F2A7BA9486D3740D87266AE0AB616750C0B370E85162860E902CAF7227EF5F8BD81BBC5E0386EF531EA47B2B5BC61C5B02F173D764F5E7E7D510A22B000BC7AB6CDE07B993D260A03E0C0EC4B9B069BDA1D1B5F5F1FB38359D7F87FD7843CE902E54E45912C7AC3A05D3C38315B60DE67A7BFCDCF980C4AE081EC7ED56F080661757261202E9B4E080000000005617572610101B158E2DB125553ABC0E2DACB956EF62A29A5B871BB64337BE42A6167C7F034CA46BF5BCE30FF50C505510814C8313380AEBEE940DA86B4ED144723DE22A7A40B000000002400000000")]
        public async Task ParaInclusion_CandidateIncluded_ShouldBeParsedAsync(string hex)
        {
            var nodeResult = await _substrateDecode.DecodeEventAsync(hex, CancellationToken.None);
            PrerequisiteEvent(nodeResult);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.ParaInclusion));
        }
    }
}
