using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Authorship.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Authorship
{
    public class AuthorshipStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task Uncles_ShouldWorkAsync()
        {
            var coreResult = new BoundedVecT7();
            var uncleEnum = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem();
            uncleEnum.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.UncleEntryItem.InclusionHeight, new U32(10));
            coreResult.Create(Utils.Bytes2HexString(new BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_authorship.EnumUncleEntryItem>(new[]
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
            await MockStorageCallNullAsync<BoundedVecT7, BaseVec<EnumUncleEntryItem>>(_substrateRepository.Storage.Authorship.UnclesAsync);
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
