using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Session;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Session
{
    public class SessionStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task Validators_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<AccountId32>();
            coreResult.Create("0x080000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E000B93D72DCC12BD5577438C92A19C4778E12CFB8ADA871A17694E5A2F86C374");

            var expectedResult = new BaseVec<SubstrateAccount>(
                new SubstrateAccount[]
                {
                    new SubstrateAccount("111B8CxcmnWbuDLyGvgUmRezDCK1brRZmvUuQ6SrFdMyc3S"),
                    new SubstrateAccount("114SUbKCXjmb9czpWTtS3JANSmNRwVa4mmsMrWYpRG1kDH5"),
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Session.ValidatorsAsync);
        }

        [Test]
        public async Task ValidatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<AccountId32>,
                BaseVec<SubstrateAccount>>(_substrateRepository.Storage.Session.ValidatorsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CurrentIndex_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Session.CurrentIndexAsync);
        }

        [Test]
        public async Task CurrentIndexNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Session.CurrentIndexAsync);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task QueuedChanged_ShouldWorkAsync(bool expectedResult)
        {
            await MockStorageCallAsync(new Bool(expectedResult), _substrateRepository.Storage.Session.QueuedChangedAsync);
        }

        [Test]
        public async Task QueuedChangedNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Session.QueuedChangedAsync);
        }

        [Test]
        public async Task QueuedKeys_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys>>();
            coreResult.Create("0x080000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E3866D53E02DB8FF21AE934A03E06375BA5F3588BD444902794DDE526FAC2CAE066F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E6120789E92DD38C67EB7D8AF316EDE060936F8FCB834CCC6080F9ED76207BDB2B73748DC56202D8BF42D2F9B89DB6BA75DE85773AE2BAB085B2F8B115F6C3F7512151C9A9A52E094114C0C1CD1AF7B0F7F2023B34B78AD842A87AF690AECBF2DA725E0D5D79067887F1187849D2778DAA7A9109D644A27581A025D7FDFF78441B755000B93D72DCC12BD5577438C92A19C4778E12CFB8ADA871A17694E5A2F86C374FFF437FF18629BF1490E5C9B3EC6F1515D46BB9B2AEAA6E39E36611F2479B50D9C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B8E7E98DE5E2A79DDBDB78030294BD73E2641B50B5B25FBAA2B40A6CA8CB2E0509EF1E3E727F41EBEB3AEA2815F004002D27714DB121FD6F92FAC8BEDBB9716098AC16E2487AE411A37A41F7A086824B2EFD39C94B3494EFA7C1B708E360B380C66F5B305293C5CE2538E4D8E773A6D51CB10ADC0C50D9B9CBA83E8429A2E2E1E");

            var expectedResult = new BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>(
                new BaseTuple<SubstrateAccount, SessionKeysPolka>[]
                {
                    new BaseTuple<SubstrateAccount, SessionKeysPolka>(
                        new SubstrateAccount("111B8CxcmnWbuDLyGvgUmRezDCK1brRZmvUuQ6SrFdMyc3S"),
                        new SessionKeysPolka(
                            new PublicEd25519("0x3866d53e02db8ff21ae934a03e06375ba5f3588bd444902794dde526fac2cae0"),
                            new PublicSr25519("0x66f60202b962c40e58fcf3481f5773dc178b9fe096f81511eaa4c7bad20e6120"),
                            new PublicSr25519("0x789e92dd38c67eb7d8af316ede060936f8fcb834ccc6080f9ed76207bdb2b737"),
                            new PublicSr25519("0x48dc56202d8bf42d2f9b89db6ba75de85773ae2bab085b2f8b115f6c3f751215"),
                            new PublicSr25519("0x1c9a9a52e094114c0c1cd1af7b0f7f2023b34b78ad842a87af690aecbf2da725"),
                            new PublicSr25519("0xe0d5d79067887f1187849d2778daa7a9109d644a27581a025d7fdff78441b755")
                        )
                    ),
                    new BaseTuple<SubstrateAccount, SessionKeysPolka>(
                        new SubstrateAccount("114SUbKCXjmb9czpWTtS3JANSmNRwVa4mmsMrWYpRG1kDH5"),
                        new SessionKeysPolka(
                            new PublicEd25519("0xfff437ff18629bf1490e5c9b3ec6f1515d46bb9b2aeaa6e39e36611f2479b50d"),
                            new PublicSr25519("0x9c40155989f6072e82caba245d7db7e40a60f866b403257976b89aba6be2b55b"),
                            new PublicSr25519("0x8e7e98de5e2a79ddbdb78030294bd73e2641b50b5b25fbaa2b40a6ca8cb2e050"),
                            new PublicSr25519("0x9ef1e3e727f41ebeb3aea2815f004002d27714db121fd6f92fac8bedbb971609"),
                            new PublicSr25519("0x8ac16e2487ae411a37a41f7a086824b2efd39c94b3494efa7c1b708e360b380c"),
                            new PublicSr25519("0x66f5b305293c5ce2538e4d8e773a6d51cb10adc0c50d9b9cba83e8429a2e2e1e")
                        )
                    )
                }
            );

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Session.QueuedKeysAsync);
        }

        [Test]
        public async Task QueuedKeysNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseTuple<AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys>>,
                BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>>(_substrateRepository.Storage.Session.QueuedKeysAsync);
        }

        [Test]
        public async Task DisabledValidators_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<U32>(new U32[] { new U32(10), new U32(20) });
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Session.DisabledValidatorsAsync);
        }

        [Test]
        public async Task DisabledValidatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Session.DisabledValidatorsAsync);
        }

        [Test]
        public async Task NextKeys_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys(); coreResult.Create("0x608F61824D3AE16D443CD0FEC15C18590C890D4105E9402CAD8743FB423E52B4BE7C58318C49FF328D53A6D67830A8A046A41F5124824D3CE2E72CC9965EF57E7480718449722DA80B61AAB07EC8079CC85D7756D8C55E8D27689184172AB52D02D1AE50ABF4787916AA4D35E41D807F88E32460FB084187B4070C3A7331F92F20417266880FC4C2DE2E2D5C0529AF712EF5570DB2121F86419A0E63C1DA3D203A2CDCB143BA3E7FA41DCCF5534C6FD36EF91187D55E35DAC9D3925AC08E2C22");

            var expectedResult = new SessionKeysPolka(
                new PublicEd25519("0x608f61824d3ae16d443cd0fec15c18590c890d4105e9402cad8743fb423e52b4"),
                new PublicSr25519("0xbe7c58318c49ff328d53a6d67830a8a046a41f5124824d3ce2e72cc9965ef57e"),
                new PublicSr25519("0x7480718449722da80b61aab07ec8079cc85d7756d8c55e8d27689184172ab52d"),
                new PublicSr25519("0x02d1ae50abf4787916aa4d35e41d807f88e32460fb084187b4070c3a7331f92f"),
                new PublicSr25519("0x20417266880fc4c2de2e2d5c0529af712ef5570db2121f86419a0e63c1da3d20"),
                new PublicSr25519("0x3a2cdcb143ba3e7fa41dccf5534c6fd36ef91187d55e35dac9d3925ac08e2c22")
            );

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Session.NextKeysAsync);
        }

        [Test]
        public async Task NextKeysNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.SessionKeys,
                SessionKeysPolka>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Session.NextKeysAsync);
        }

        [Test]
        public async Task KeyOwner_ShouldWorkAsync()
        {
            var input = new BaseTuple<FlexibleNameable, Hexa>();
            input.Create(new FlexibleNameable().FromText("gran"), new Hexa("0xf26945a8a64032a1defa76e720a99649125b55751b6088205e7acab901de670b"));

            var coreResult = new AccountId32();
            coreResult.Create("0x17316829C406A05CD9CDB8D5DE5FB23D26B3672F8CBCA1FCC6538833589A121A");

            var expectedResult = new SubstrateAccount("1XQn94kWaMVJG16AWPKGmYFERfttsjZq4ompSTz2jxHK6uL");

            await MockStorageCallWithInputAsync(input, coreResult, expectedResult, _substrateRepository.Storage.Session.KeyOwnerAsync);
        }

        [Test]
        public async Task KeyOwnerNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                BaseTuple<FlexibleNameable, Hexa>, AccountId32, SubstrateAccount>(
                new BaseTuple<FlexibleNameable, Hexa>(new FlexibleNameable().FromText("gran"), new Hexa("0xf26945a8a64032a1defa76e720a99649125b55751b6088205e7acab901de670b")), _substrateRepository.Storage.Session.KeyOwnerAsync);
        }
    }
}
