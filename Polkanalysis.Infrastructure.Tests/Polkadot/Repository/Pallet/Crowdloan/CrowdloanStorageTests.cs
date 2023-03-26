using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Tests.Polkadot.Repository.Pallet.Crowdloan
{
    public class CrowdloanStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task EndingsCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Crowdloan.EndingsCountAsync);
        }

        [Test]
        public async Task EndingsCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Crowdloan.EndingsCountAsync);
        }

        [Test]
        public async Task Funds_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo();
            coreResult.Create("0x521F755ACF5E3764DDAAB3E330C77125CF2DB266BEE14C6030D7D552F269B01700005039278C040000000000000000000000D42FF274A80A0000000000000000007822D800008053EE7BA80A00000000000000000001220000000B0000001200000037000000");

            var expectedResult = new FundInfo();
            var enumLastContribution = new EnumLastContribution();
            enumLastContribution.Create(LastContribution.PreEnding, new U32(34));

            expectedResult.Create(
                new SubstrateAccount("12rgGkphjoZ25FubPoxywaNm3oVhSHnzExnT6hsLnicuLaaj"),
                new BaseOpt<EnumMultiSigner>(),
                new U128(5000000000000),
                new U128(2999970000000000),
                new U32(14164600),
                new U128(3000000000000000),
                enumLastContribution,
                new U32(11),
                new U32(18),
                new U32(55));

            await MockStorageCallWithInputAsync(new Id(2094), coreResult, expectedResult, _substrateRepository.Storage.Crowdloan.FundsAsync);
        }

        [Test]
        public async Task FundsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.FundInfo,
                FundInfo>(new Id(2), _substrateRepository.Storage.Crowdloan.FundsAsync);
        }

        [Test]
        public async Task NewRaise_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();
            coreResult.Create("0x080A0D00000C0D0000");

            var expectedResult = new BaseVec<Id>(new Id[]
            {
                new Id(3338),
                new Id(3340),
            });

            await MockStorageCallAsync<BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>,
                BaseVec<Id>>(coreResult, expectedResult, _substrateRepository.Storage.Crowdloan.NewRaiseAsync);
        }

        [Test]
        public async Task NewRaiseNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>,
                BaseVec<Id>>(_substrateRepository.Storage.Crowdloan.NewRaiseAsync);
        }
    }
}
