using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using IdentityExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_identity.types;
using AccountId32Ext = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Identity
{
    public class IdentityStorageTests : PolkadotMock
    {
        [Test]
        public async Task IdentityOf_ShouldWorkAsync()
        {
            var coreResult = new IdentityExt.Registration();
            coreResult.Create("0x04010000000200BB34642400000000000000000000000017506F6C6B61646F742E70726F202D205265616C676172001568747470733A2F2F706F6C6B61646F742E70726F14407265616C6761723A6D61747269782E6F72671368656C6C6F40706F6C6B61646F742E70726F00000D4070726F706F6C6B61646F74");

            var identityInfo = new IdentityInfo().From("Polkadot.pro - Realgar", null, "https://polkadot.pro", "@realgar:matrix.org", "hello@polkadot.pro", null, "@propolkadot", null, new BaseVec<BaseTuple<EnumData, EnumData>>(new BaseTuple<EnumData, EnumData>[] { }));
            var enumJudgement = new EnumJudgement();
            enumJudgement.Create(Judgement.Reasonable, new BaseVoid());
            var judgements = new BaseVec<BaseTuple<U32, EnumJudgement>>(new BaseTuple<U32, EnumJudgement>[]
            {
                new BaseTuple<U32, EnumJudgement>(new U32(1), enumJudgement)
            });
            var expectedResult = new Registration(identityInfo, new U128(156300000000), judgements);

            Assert.That(coreResult.Encode(), Is.EqualTo(coreResult.Bytes));
            var mapped = new Registration();
            mapped.Create(coreResult.Encode());

            Assert.That(mapped.Deposit.Encode(), Is.EqualTo(coreResult.Deposit.Encode()));
            Assert.That(mapped.Judgements.Encode(), Is.EqualTo(coreResult.Judgements.Encode()));
            Assert.That(mapped.Info.Encode(), Is.EqualTo(coreResult.Info.Encode()));
            Assert.That(mapped.Encode(), Is.EqualTo(coreResult.Encode()));

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateService.Storage.Identity.IdentityOfAsync);

            Assert.That(coreResult.Info.Display.Encode(), Is.EquivalentTo(expectedResult.Info.Display.Bytes));
            Assert.That(coreResult.Info.Legal.Encode(), Is.EquivalentTo(expectedResult.Info.Legal.Bytes));
            Assert.That(coreResult.Info.Web.Encode(), Is.EquivalentTo(expectedResult.Info.Web.Bytes));
            Assert.That(coreResult.Info.Riot.Encode(), Is.EquivalentTo(expectedResult.Info.Riot.Bytes));
            Assert.That(coreResult.Info.Email.Encode(), Is.EquivalentTo(expectedResult.Info.Email.Bytes));
            Assert.That(coreResult.Info.PgpFingerprint.Encode(), Is.EquivalentTo(expectedResult.Info.PgpFingerprint.Bytes));
            Assert.That(coreResult.Info.Twitter.Encode(), Is.EquivalentTo(expectedResult.Info.Twitter.Bytes));
            Assert.That(coreResult.Info.Image.Encode(), Is.EquivalentTo(expectedResult.Info.Image.Bytes));
            //Assert.That(coreResult.Info.Additional.Encode(), Is.EquivalentTo(expectedResult.Info.Additional.Bytes));
        }

        [Test]
        public async Task IdentityOfNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                IdentityExt.Registration,
                Registration>(new SubstrateAccount(MockAddress), _substrateService.Storage.Identity.IdentityOfAsync);
        }

        [Test]
        public async Task SuperOf_ShouldWorkAsync()
        {
            var coreResult = new BaseTuple<AccountId32Ext, IdentityExt.EnumData>();
            coreResult.Create("0x127A30E486492921E58F2564B36AB1CA21FF630672F0E76920EDD601F8F2B89A07415A494D5554");

            var expectedResult = new BaseTuple<SubstrateAccount, EnumData>(
                new SubstrateAccount("1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih"),
                new EnumData(Data.Raw6, new FlexibleNameable().FromText("AZIMUT")));

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateService.Storage.Identity.SuperOfAsync);
        }

        [Test]
        public async Task SuperOfNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                BaseTuple<AccountId32Ext, IdentityExt.EnumData>,
                    BaseTuple<SubstrateAccount, EnumData>>(new SubstrateAccount(MockAddress), _substrateService.Storage.Identity.SuperOfAsync);
        }

        [Test]
        public async Task SubsOf_ShouldWorkAsync()
        {
            var coreResult = new BaseTuple<U128, BaseVec<AccountId32Ext>>();
            coreResult.Create("0x80E98E118C00000000000000000000000CA4C5B68728F7FDBDB4426714A385017A471D5CD22A156ACD30A40277E6417B600EDAA0D08E8B21D6E8F946EFF381AD4BE29AA63569A54A6A75C91B878B463033F6BE65CC16C65708BB6A0E4B9958FFE23D1C56EE5683670A69DBBBB70C10D507");

            var expectedResult = new BaseTuple<U128, BaseVec<SubstrateAccount>>(
                new U128(601590000000),
                new BaseVec<SubstrateAccount>(new SubstrateAccount[] {
                    new SubstrateAccount("14j3azi9gKGx2de7ADL3dkzZXFzTTUy1t3RND21PymHRXRp6"),
                    new SubstrateAccount("1LUckyocmz9YzeQZHVpBvYYRGXb3rnSm2tvfz79h3G3JDgP"),
                    new SubstrateAccount("16aXLhFh9mZoyW5emqZM6fJWTqbWENGrJkAoGwtR1S8XoFwY")
                }));

            var res = await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateService.Storage.Identity.SubsOfAsync);

            Assert.That(res.Value[0].As<U128>().Value, Is.EqualTo(expectedResult.Value[0].As<U128>().Value));

            Assert.That(res.Value[1].As<BaseVec<SubstrateAccount>>().Value[0].As<SubstrateAccount>().ToPolkadotAddress(), Is.EqualTo(expectedResult.Value[1].As<BaseVec<SubstrateAccount>>().Value[0].As<SubstrateAccount>().ToPolkadotAddress()));

            Assert.That(res.Value[1].As<BaseVec<SubstrateAccount>>().Value[1].As<SubstrateAccount>().ToPolkadotAddress(), Is.EqualTo(expectedResult.Value[1].As<BaseVec<SubstrateAccount>>().Value[1].As<SubstrateAccount>().ToPolkadotAddress()));

            Assert.That(res.Value[1].As<BaseVec<SubstrateAccount>>().Value[2].As<SubstrateAccount>().ToPolkadotAddress(), Is.EqualTo(expectedResult.Value[1].As<BaseVec<SubstrateAccount>>().Value[2].As<SubstrateAccount>().ToPolkadotAddress()));
        }

        [Test]
        public async Task SubsOfNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync
                <SubstrateAccount, BaseTuple<U128, BaseVec<AccountId32Ext>>, BaseTuple<U128, BaseVec<SubstrateAccount>>>(new SubstrateAccount(MockAddress), _substrateService.Storage.Identity.SubsOfAsync);
        }

        [Test]
        public async Task Registrars_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<BaseOpt<IdentityExt.RegistrarInfo>>();
            coreResult.Create("0x0C014C4BF7F93D0A5ED801EF778F8E7EF58201BDD7E33E167FAF42A01D439283CB430000000000000000000000000000000000000000000000000112CCB53338AC0DA571D3697548346FB5F0B637AC9412F8ABBF6D13588BE7563200B08EF01B00000000000000000000000000000000000000010A8A307EF15B9F928697FA09DCC72A2C19A266C1D32FA158F9916B8B804E1621000000000000000000000000000000000000000000000000");

            var expectedResult = new BaseVec<BaseOpt<RegistrarInfo>>(new BaseOpt<RegistrarInfo>[]
            {
                new BaseOpt<RegistrarInfo>(
                    new RegistrarInfo(
                        new SubstrateAccount("12j3Cz8qskCGJxmSJpVL2z2t3Fpmw3KoBaBaRGPnuibFc7o8"),
                        new U128(0),
                        new U64(0))),

                new BaseOpt<RegistrarInfo>(
                    new RegistrarInfo(
                        new SubstrateAccount("1Reg2TYv9rGfrQKpPREmrHRxrNsUDBQKzkYwP1UstD97wpJ"),
                        new U128(120000000000),
                        new U64(0))),

                new BaseOpt<RegistrarInfo>(
                    new RegistrarInfo(
                        new SubstrateAccount("1EpXirnoTimS1SWq52BeYx7sitsusXNGzMyGx8WPujPd1HB"),
                        new U128(0),
                        new U64(0))),
            });

            await MockStorageCallAsync(coreResult, expectedResult, _substrateService.Storage.Identity.RegistrarsAsync);
        }

        [Test]
        public async Task RegistrarsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseOpt<IdentityExt.RegistrarInfo>>,
                BaseVec<BaseOpt<RegistrarInfo>>>(_substrateService.Storage.Identity.RegistrarsAsync);
        }
    }
}
