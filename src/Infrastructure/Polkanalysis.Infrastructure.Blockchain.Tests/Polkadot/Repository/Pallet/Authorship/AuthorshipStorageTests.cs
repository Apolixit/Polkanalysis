using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Authorship.Enums;
using Ext = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_authorship;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Authorship
{
    public class AuthorshipStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task Uncles_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<Ext.EnumUncleEntryItem>();
            var uncleEnum = new Ext.EnumUncleEntryItem();
            uncleEnum.Create(Ext.UncleEntryItem.InclusionHeight, new U32(10));
            coreResult.Create(Utils.Bytes2HexString(new BaseVec<Ext.EnumUncleEntryItem>(new[]
            {
                uncleEnum
            }).Encode()));

            var uncleEnumExpected = new EnumUncleEntryItem();
            uncleEnumExpected.Create(UncleEntryItem.InclusionHeight, new U32(10));
            var expectedResult = new BaseVec<EnumUncleEntryItem>(new[]
            {
                uncleEnumExpected
            });

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Authorship.UnclesAsync);
        }

        [Test]
        public async Task UnclesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseVec<Ext.EnumUncleEntryItem>, BaseVec<EnumUncleEntryItem>>(_substrateRepository.Storage.Authorship.UnclesAsync);
        }

        [Test]
        public async Task Author_ShouldWorkAsync()
        {
            var coreResult = new AccountId32();
            coreResult.Create(Utils.GetPublicKeyFrom(MockAddress));

            var expectedResult = new SubstrateAccount(MockAddress);

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Authorship.AuthorAsync);
        }

        [Test]
        public async Task AuthorNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<AccountId32, SubstrateAccount>(_substrateRepository.Storage.Authorship.AuthorAsync);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DidSetUncles_ShouldWorkAsync(bool expectedResult)
        {
            await MockStorageCallAsync(new Bool(expectedResult), _substrateRepository.Storage.Authorship.DidSetUnclesAsync);
        }

        [Test]
        public async Task DidSetUnclesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Authorship.DidSetUnclesAsync);
        }
    }
}
