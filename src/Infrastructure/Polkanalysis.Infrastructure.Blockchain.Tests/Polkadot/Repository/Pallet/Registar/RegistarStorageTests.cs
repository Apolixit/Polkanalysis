using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Registar
{
    public class RegistarStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task NextFreeParaId_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id();
            coreResult.Create("0x0D0D0000");

            var expectedResult = new Id(3341);

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Registrar.NextFreeParaIdAsync);
        }

        [Test]
        public async Task NextFreeParaIdNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id, Id>(_substrateRepository.Storage.Registrar.NextFreeParaIdAsync);
        }

        [Test]
        public async Task Paras_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_runtime_common.paras_registrar.ParaInfo();
            coreResult.Create("0x24F6561B36AF544CC2619B9EE0276753E6A9C5E20E27D4CA231F9E7F489246510010A5D4E8000000000000000000000000");

            var expectedResult = new ParaInfo(
                new SubstrateAccount("1qTuG515hwNxAFMSDB6tvhbPtJp1FMmxdcFehfswoJbA3n2"),
                new U128(1000000000000),
                new Bool(false)
            );

            await MockStorageCallWithInputAsync(new Id(2098), coreResult, expectedResult, _substrateRepository.Storage.Registrar.ParasAsync);
        }

        [Test]
        public async Task ParasNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_runtime_common.paras_registrar.ParaInfo,
                ParaInfo>(new Id(1), _substrateRepository.Storage.Registrar.ParasAsync);
        }

        [Test]
        public async Task PendingSwap_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id();
            coreResult.Create("0x01000000");

            var expectedResult = new Id(1);

            await MockStorageCallWithInputAsync(new Id(2098), coreResult, expectedResult, _substrateRepository.Storage.Registrar.PendingSwapAsync);
        }

        [Test]
        public async Task PendingSwapNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id,
                Id>(new Id(1), _substrateRepository.Storage.Registrar.PendingSwapAsync);
        }
    }
}
