using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums;
using AccountId32Ext = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32;
using SpArithmeticExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_arithmetic.per_things;
using StakingExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_staking;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Staking
{
    public class StakingStorageTests : PolkadotMock
    {
        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task ValidatorCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.ValidatorCountAsync);
        }

        [Test]
        public async Task ValidatorCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.ValidatorCountAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MinimumValidatorCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MinimumValidatorCountAsync);
        }

        [Test]
        public async Task MinimumValidatorCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.ValidatorCountAsync);
        }

        [Test]
        public async Task Invulnerables_ShouldWorkAsync()
        {
            var accountId32 = new AccountId32Ext();
            accountId32.Create(Utils.GetPublicKeyFrom(MockAddress2));
            var coreResult = new BaseVec<AccountId32Ext>(new AccountId32Ext[] {
                accountId32
            });

            var expectedResult = new BaseVec<SubstrateAccount>(new SubstrateAccount[] {
                new SubstrateAccount(MockAddress2)
            });
            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.InvulnerablesAsync);
        }

        [Test]
        public async Task InvulnerablesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<AccountId32Ext>, BaseVec<SubstrateAccount>>(_substrateRepository.Storage.Staking.InvulnerablesAsync);
        }

        [Test]
        public async Task Bonded_ShouldWorkAsync()
        {
            var coreResult = new AccountId32Ext();
            coreResult.Create("0x22A1F64B0AB914A002EF775FEEA90A74D9F2CDBF12A10C81E161257D7118F41F");

            var expectedResult = new SubstrateAccount("1nQjyHGZmXaCEedntaV1Cq9VvHKmUYLqo1BRm85AomYELLH");

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Staking.BondedAsync);
        }

        [Test]
        public async Task BondedNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                AccountId32Ext,
                SubstrateAccount>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.BondedAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task MinNominatorBond_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MinNominatorBondAsync);
        }

        [Test]
        public async Task MinNominatorBondNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.MinNominatorBondAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task MinValidatorBond_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MinValidatorBondAsync);
        }

        [Test]
        public async Task MinValidatorBondNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.MinValidatorBondAsync);
        }

        [Test]
        public async Task MinCommission_ShouldWorkAsync()
        {
            var coreResult = new SpArithmeticExt.Perbill();
            coreResult.Create("0x00000000");

            var expectedResult = new Perbill(new U32(0));

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.MinCommissionAsync);
        }

        [Test]
        public async Task MinCommissionNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                SpArithmeticExt.Perbill, Perbill
                >(_substrateRepository.Storage.Staking.MinCommissionAsync);
        }

        [Test]
        [Ignore("Need to find a good test")]
        public async Task Ledger_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task LedgerNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                StakingExt.StakingLedger,
                StakingLedger>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.LedgerAsync);
        }

        [Test]
        public async Task Payee_WithSingleDestinationAccount_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.EnumRewardDestination();
            coreResult.Create("0x03DE7A64C518F056C5AAF0A61B5C4C2257D37292F1D31B404EAA711F851CF7773A");

            var expectedResult = new EnumRewardDestination();
            expectedResult.Create(RewardDestination.Account, new SubstrateAccount("162hzMgmVHYRjuRLJVmEwDkMEvh8C8D7fRPYmnDfkpwEAa3c"));

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Staking.PayeeAsync);
        }

        [Test]
        public async Task Payee_WithStakedDestinationAccount_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.EnumRewardDestination();
            coreResult.Create("0x00");

            var expectedResult = new EnumRewardDestination();
            expectedResult.Create(RewardDestination.Staked, new BaseVoid());

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Staking.PayeeAsync);
        }

        [Test]
        public async Task PayeeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                StakingExt.EnumRewardDestination,
                EnumRewardDestination>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.PayeeAsync);
        }

        [Test]
        public async Task Validators_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.ValidatorPrefs();
            coreResult.Create("0x0284D71700");

            var expectedResult = new ValidatorPrefs(new BaseCom<Perbill>(new CompactInteger(100000000)), new Bool(false));

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Staking.ValidatorsAsync);
        }

        [Test]
        public async Task ValidatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                StakingExt.ValidatorPrefs,
                ValidatorPrefs
                >(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.ValidatorsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForValidators_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.CounterForValidatorsAsync);
        }

        [Test]
        public async Task CounterForValidatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.CounterForValidatorsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MaxValidatorsCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MaxValidatorsCountAsync);
        }

        [Test]
        public async Task MaxValidatorsCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.MaxValidatorsCountAsync);
        }

        [Test]
        public async Task Nominators_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.Nominations();
            coreResult.Create("0x402C2A55B5B7E13A772E0B693C3B351D2FB5E5B4DA18AC379EBDB2F1F2E75597762C2A55B6068E3B8626608321044A89B82FC4898ECE34524659F48AA72AEF556C2C2A55B5B05723585C7421428D9EF451313E33E13803424B0F8CABD383D0DF372C2A55B5C7A1C48E176AAEAFF69A017D85B27A49F1FAFC160725A3376F417D002C2A55B5CF8D00511EF54AC7A60773810E906BEFB1B322F2D58199963DC973072C2A55B5C7E135AE443C6ED951338D4B32BE6CF61AC5BD000B7A11C26B3078202C2A55B59A282FB173B7FAF6E82984686F6FB83B0293DD498DB6329464A45D1C2C2A55B5E0D28CC772B47BB9B25981CBB69ECA73F7C3388FB6464E7D24BE470EF0DE782E8BAD3C663BE60812F0A2AC63464F5DA3EC448C73334C07D71EF27F2C6C695C4E546C6889CA591B582EEE8B49BA68D8485A3732E08D232B2F28F2342E2C2A55B5FFDCA266BD0207DF97565B03255F70783CA1A349BE5ED9F44589C3602C2A55B5A609BAFF13899D4BA4BAFEC105038D66A716494968FAE1A849D2DD5A2C2A55B5A6413894E13836FB0165E6ADCE7D77C06DCCF42B3B288397A27DDD3B2C2A55B5A116A4C88AFF57E8F2B70BA72DDA72DDA4B78630E16AD0CA69006F182C2A55B5EABF99708C2A9F1E21A3BED0FA589B18286225CEB1BC9E28FF06A04F2C2A55B51BAA94FF2DC4FEAE28C5ECCCB774C622545B0A127DBD5AE8E2C8E115BC01000000");

            var expectedResult = new Nominations(new BaseVec<SubstrateAccount>(new SubstrateAccount[]
            {
                new SubstrateAccount("1zugcag7cJVBtVRnFxv5Qftn7xKAnR6YJ9x4x3XLgGgmNnS"),
                new SubstrateAccount("1zugcawsx74AgoC4wz2dMEVFVDNo7rVuTRjZMnfNp9T49po"),
                new SubstrateAccount("1zugcaebzKgKLebGSQvtxpmPGCZLFoEVu6AfqwD7W5ZKQZt"),
                new SubstrateAccount("1zugcajGg5yDD9TEqKKzGx7iKuGWZMkRbYcyaFnaUaEkwMK"),
                new SubstrateAccount("1zugcakrhr3ZR7q7B8WKuaZY5BjZAU43m79xEyhNQwLTFjb"),
                new SubstrateAccount("1zugcajKZ8XwjWvC5QZWcrpjfnjZZ9FfxRB9f5Hy6GdXBpZ"),
                new SubstrateAccount("1zugcaaABVRXtyepKmwNR4g5iH2NtTNVBz1McZ81p91uAm8"),
                new SubstrateAccount("1zugcapKRuHy2C1PceJxTvXWiq6FHEDm2xa5XSU7KYP3rJE"),
                new SubstrateAccount("16SpacegeUTft9v3ts27CEC3tJaxgvE4uZeCctThFH3Vb24p"),
                new SubstrateAccount("13T9UGfntid52aHuaxX1j6uh3zTYzMPMG1Des9Cmvf7K4xfq"),
                new SubstrateAccount("1zugcavYA9yCuYwiEYeMHNJm9gXznYjNfXQjZsZukF1Mpow"),
                new SubstrateAccount("1zugcacYFxX3HveFpJVUShjfb3KyaomfVqMTFoxYuUWCdD8"),
                new SubstrateAccount("1zugcacan4nrJ3HPBmiBgEn2XvRMbehqvmzSQXT3uLBDkh3"),
                new SubstrateAccount("1zugcabYjgfQdMLC3cAzQ8tJZMo45tMnGpivpAzpxB4CZyK"),
                new SubstrateAccount("1zugcarJnZ4ft2PiJoGg6DgmZjnKNBrcKTFrAzhGPCX6bJ5"),
                new SubstrateAccount("1zugca8p9rquswKkHtVKmzR6Z8R9PAmj8MGL1x3HArdAp1J"),
            }),
            new U32(444), new Bool(false));

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), coreResult, expectedResult, _substrateRepository.Storage.Staking.NominatorsAsync);
        }

        [Test]
        public async Task NominatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                StakingExt.Nominations,
                Nominations>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.NominatorsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CounterForNominators_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.CounterForNominatorsAsync);
        }

        [Test]
        public async Task CounterForNominatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.CounterForNominatorsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task MaxNominatorsCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MaxNominatorsCountAsync);
        }

        [Test]
        public async Task MaxNominatorsCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.MaxNominatorsCountAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CurrentEra_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.CurrentEraAsync);
        }

        [Test]
        public async Task CurrentEraNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.CurrentEraAsync);
        }

        [Test]
        public async Task ActiveEra_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.ActiveEraInfo();
            coreResult.Create("0xFE030000015105AAFF86010000");

            var expectedResult = new ActiveEraInfo(new U32(1022), new BaseOpt<U64>(new U64(1679326578001)));

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.ActiveEraAsync);
        }

        [Test]
        public async Task ActiveEraNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                StakingExt.ActiveEraInfo,
                ActiveEraInfo>(_substrateRepository.Storage.Staking.ActiveEraAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task ErasStartSessionIndex_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallWithInputAsync(new U32(1), expectedResult, _substrateRepository.Storage.Staking.ErasStartSessionIndexAsync);
        }

        [Test]
        public async Task ErasStartSessionIndexNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.Staking.ErasStartSessionIndexAsync);
        }

        [Test]
        public async Task ErasStakers_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.Exposure();
            coreResult.Create("0x0F07B5D5E2A0EC4A000838986B06BB855AD6F44CCFEC6CFFAF6E8BC8AE6D803D8C25EC4D0CF9249900610F636F69D55B8E0350C2E90BF12D5DA2AEFB80C9E3D273E68C357133BFF1E7BD2E3C1013E289926F0F05746DF3C6CE01");

            var expectedResult = new Exposure(
                new BaseCom<U128>(new CompactInteger(21089324021167367)),
                new BaseCom<U128>(new CompactInteger(0)),
                new BaseVec<IndividualExposure>(new IndividualExposure[] {
                    new IndividualExposure(new SubstrateAccount("12HCxdeDmbEASiehH6e4vaksgEu4h1pe6eBH6uYZGSnmPsMR"), new BaseCom<U128>(new CompactInteger(1000950003756899))),
                    new IndividualExposure(new SubstrateAccount("12ptjQttvvJPXbSisBrmTYYGFfcFd5tKM27fttsmGatmUEJf"), new BaseCom<U128>(new CompactInteger(508828859593733))),
                }));

            await MockStorageCallWithInputAsync(
                new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), coreResult, expectedResult, _substrateRepository.Storage.Staking.ErasStakersAsync);
        }

        [Test]
        public async Task ErasStakersNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
               BaseTuple<U32, SubstrateAccount>,
               StakingExt.Exposure,
               Exposure>(new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), _substrateRepository.Storage.Staking.ErasStakersAsync);
        }

        [Test]
        public async Task ErasStakersClipped_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.Exposure();
            coreResult.Create("0x0F07B5D5E2A0EC4A000838986B06BB855AD6F44CCFEC6CFFAF6E8BC8AE6D803D8C25EC4D0CF9249900610F636F69D55B8E0350C2E90BF12D5DA2AEFB80C9E3D273E68C357133BFF1E7BD2E3C1013E289926F0F05746DF3C6CE01");

            var expectedResult = new Exposure(
                new BaseCom<U128>(new CompactInteger(new U128(21089324021167367))),
                new BaseCom<U128>(new CompactInteger(new U128(0))),
                new BaseVec<IndividualExposure>(new IndividualExposure[] {
                    new IndividualExposure(new SubstrateAccount("12HCxdeDmbEASiehH6e4vaksgEu4h1pe6eBH6uYZGSnmPsMR"), new BaseCom<U128>(new CompactInteger(new U128(1000950003756899)))),
                    new IndividualExposure(new SubstrateAccount("12ptjQttvvJPXbSisBrmTYYGFfcFd5tKM27fttsmGatmUEJf"), new BaseCom<U128>(new CompactInteger(new U128(508828859593733)))),
                }));

            await MockStorageCallWithInputAsync(
                new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), coreResult, expectedResult, _substrateRepository.Storage.Staking.ErasStakersClippedAsync);
        }

        [Test]
        public async Task ErasStakersClippedNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
               BaseTuple<U32, SubstrateAccount>,
               StakingExt.Exposure,
               Exposure>(new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), _substrateRepository.Storage.Staking.ErasStakersClippedAsync);
        }

        [Test]
        public async Task ErasValidatorPrefs_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.ValidatorPrefs();
            coreResult.Create("0x0284D71700");

            var expectedResult = new ValidatorPrefs(new BaseCom<Perbill>(new CompactInteger(100000000)), new Bool(false));

            await MockStorageCallWithInputAsync(new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), coreResult, expectedResult, _substrateRepository.Storage.Staking.ErasValidatorPrefsAsync);
        }

        [Test]
        public async Task ErasValidatorPrefsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
               BaseTuple<U32, SubstrateAccount>,
               StakingExt.ValidatorPrefs,
               ValidatorPrefs>(new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), _substrateRepository.Storage.Staking.ErasValidatorPrefsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task ErasValidatorReward_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallWithInputAsync(new U32(1), expectedResult, _substrateRepository.Storage.Staking.ErasValidatorRewardAsync);
        }

        [Test]
        public async Task ErasValidatorRewardNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.Staking.ErasValidatorRewardAsync);
        }

        [Test]
        public async Task ErasRewardPoints_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.EraRewardPoints();
            coreResult.Create("0x784D250108000B93D72DCC12BD5577438C92A19C4778E12CFB8ADA871A17694E5A2F86C3740C7A01000020F1B8ED9726E2781F24A87CD41E31E7CED50351422403E70FACBD1B5E562FF0410000");

            var expectedResult = new EraRewardPoints(
                new U32(19221880),
                new BaseVec<BaseTuple<SubstrateAccount, U32>>([
                    new BaseTuple<SubstrateAccount, U32>(
                        new SubstrateAccount("114SUbKCXjmb9czpWTtS3JANSmNRwVa4mmsMrWYpRG1kDH5"),
                        new U32(96780)),
                    new BaseTuple<SubstrateAccount, U32>(
                        new SubstrateAccount("11AnciffJctDC28odTEjDVYP2yWyp6275WLbrAUHi2vJm9f"),
                        new U32(16880)),
                ]));

            await MockStorageCallWithInputAsync(new U32(1), coreResult, expectedResult, _substrateRepository.Storage.Staking.ErasRewardPointsAsync);
        }

        [Test]
        public async Task ErasRewardPointsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                StakingExt.EraRewardPoints,
                EraRewardPoints>(new U32(1), _substrateRepository.Storage.Staking.ErasRewardPointsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task ErasTotalStake_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallWithInputAsync(new U32(1), expectedResult, _substrateRepository.Storage.Staking.ErasTotalStakeAsync);
        }

        [Test]
        public async Task ErasTotalStakeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.Staking.ErasTotalStakeAsync);
        }

        [Test]
        public async Task ForceEra_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.EnumForcing();
            coreResult.Create(StakingExt.Forcing.NotForcing);

            var expectedResult = new EnumForcing();
            expectedResult.Create(Forcing.NotForcing);

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.ForceEraAsync);
        }

        [Test]
        public async Task ForceEraNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                StakingExt.EnumForcing, EnumForcing>(_substrateRepository.Storage.Staking.ForceEraAsync);
        }

        [Test]
        public async Task SlashRewardFraction_ShouldWorkAsync()
        {
            var coreResult = new SpArithmeticExt.Perbill();
            coreResult.Create("0x00E1F505");

            var expectedResult = new Perbill(new U32(100000000));

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.SlashRewardFractionAsync);
        }

        [Test]
        public async Task SlashRewardFractionNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                SpArithmeticExt.Perbill, Perbill
                >(_substrateRepository.Storage.Staking.SlashRewardFractionAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task CanceledSlashPayout_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.CanceledSlashPayoutAsync);
        }

        [Test]
        public async Task CanceledSlashPayoutNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.CanceledSlashPayoutAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task MinimumActiveStake_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.MinimumActiveStakeAsync);
        }

        [Test]
        public async Task MinimumActiveStakeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.MinimumActiveStakeAsync);
        }

        [Test]
        [Ignore("Todo find test case")]
        public async Task UnappliedSlashes_ShouldWorkAsync()
        {
            //await MockStorageCallNullWithInputAsync<
            //    U32,
            //    BaseVec<StackingExt.UnappliedSlash>,
            //    BaseVec<UnappliedSlash>>(new U32(1), _substrateRepository.Storage.Staking.UnappliedSlashesAsync);
        }

        [Test]
        public async Task UnappliedSlashesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                U32,
                BaseVec<StakingExt.UnappliedSlash>,
                BaseVec<UnappliedSlash>>(new U32(1), _substrateRepository.Storage.Staking.UnappliedSlashesAsync);
        }

        [Test]
        public async Task BondedEras_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<BaseTuple<U32, U32>>();
            expectedResult.Create("0x10E303000076170000E40300007C170000E503000082170000E603000088170000");

            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.BondedErasAsync);
        }

        [Test]
        public async Task BondedErasNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.BondedErasAsync);
        }

        [Test]
        public async Task ValidatorSlashInEra_ShouldWorkAsync()
        {
            var perbill = new SpArithmeticExt.Perbill();
            perbill.Create("0x00000000");
            var coreResult = new BaseTuple<SpArithmeticExt.Perbill, U128>();
            coreResult.Create(perbill, new U128(0));

            var expectedResult = new BaseTuple<Perbill, U128>(new Perbill(new U32(0)), new U128(0));

            await MockStorageCallWithInputAsync(
                new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)),
                coreResult, expectedResult, _substrateRepository.Storage.Staking.ValidatorSlashInEraAsync);
        }

        [Test]
        public async Task ValidatorSlashInEraNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                BaseTuple<U32, SubstrateAccount>,
                BaseTuple<SpArithmeticExt.Perbill, U128>,
                BaseTuple<Perbill, U128>
                >(new BaseTuple<U32, SubstrateAccount>(new U32(0), new SubstrateAccount(MockAddress)), _substrateRepository.Storage.Staking.ValidatorSlashInEraAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task NominatorSlashInEra_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallWithInputAsync(
                new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)),
                expectedResult, _substrateRepository.Storage.Staking.NominatorSlashInEraAsync);
        }

        [Test]
        public async Task NominatorSlashInEraNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                BaseTuple<U32, SubstrateAccount>,
                BaseTuple<SpArithmeticExt.Perbill, U128>,
                BaseTuple<Perbill, U128>
                >(new BaseTuple<U32, SubstrateAccount>(new U32(1), new SubstrateAccount(MockAddress)), _substrateRepository.Storage.Staking.ValidatorSlashInEraAsync);
        }

        [Test]
        public async Task SlashingSpans_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.slashing.SlashingSpans();
            coreResult.Create("0x0400000095020000000000000801000000A4000000");

            var expectedResult = new SlashingSpans(
                new U32(4),
                new U32(661),
                new U32(0),
                new BaseVec<U32>(new U32[] {
                    new U32(1),
                    new U32(164)
                })
            );

            await MockStorageCallWithInputAsync(
                new SubstrateAccount(MockAddress),
                coreResult, expectedResult, _substrateRepository.Storage.Staking.SlashingSpansAsync);
        }

        [Test]
        public async Task SlashingSpansNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                StakingExt.slashing.SlashingSpans,
                SlashingSpans>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Staking.SlashingSpansAsync);
        }

        [Test]
        public async Task SpanSlash_ShouldWorkAsync()
        {
            var coreResult = new StakingExt.slashing.SpanRecord();
            coreResult.Create("0xCC7B8369010000000000000000000000CA5F1312000000000000000000000000");

            var expectedResult = new SpanRecord(
                new U128(6065191884),
                new U128(303259594));

            await MockStorageCallWithInputAsync(
                new BaseTuple<SubstrateAccount, U32>(new SubstrateAccount(MockAddress), new U32(1)),
                coreResult, expectedResult, _substrateRepository.Storage.Staking.SpanSlashAsync);
        }

        [Test]
        public async Task SpanSlashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<
                BaseTuple<SubstrateAccount, U32>,
                StakingExt.slashing.SpanRecord,
                SpanRecord>(new BaseTuple<SubstrateAccount, U32>(new SubstrateAccount(MockAddress), new U32(1)), _substrateRepository.Storage.Staking.SpanSlashAsync);
        }

        [Test]
        public async Task SpanSlashNull_WithNullInput_ShouldThrowExceptionAsync()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await MockStorageCallNullWithInputAsync<
                BaseTuple<SubstrateAccount, U32>,
                StakingExt.slashing.SpanRecord,
                SpanRecord>(null!, _substrateRepository.Storage.Staking.SpanSlashAsync));

        }

        [Test]
        [Ignore("Find a solution")]
        public async Task SpanSlashNull_WithEmptyInput_ShouldThrowExceptionAsync()
        {
            await MockStorageCallNullWithInputAsync<
                BaseTuple<SubstrateAccount, U32>,
                StakingExt.slashing.SpanRecord,
                SpanRecord>(new BaseTuple<SubstrateAccount, U32>(), _substrateRepository.Storage.Staking.SpanSlashAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task CurrentPlannedSession_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.CurrentPlannedSessionAsync);
        }

        [Test]
        public async Task CurrentPlannedSessionNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.CurrentPlannedSessionAsync);
        }

        [Test]
        public async Task OffendingValidators_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<BaseTuple<U32, Bool>>(new BaseTuple<U32, Bool>[] {
                new BaseTuple<U32, Bool>(new U32(1), new Bool(true)),
                new BaseTuple<U32, Bool>(new U32(20), new Bool(false))
            });

            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Staking.OffendingValidatorsAsync);
        }

        [Test]
        public async Task OffendingValidatorsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Staking.OffendingValidatorsAsync);
        }

        [Test]
        public async Task StorageVersion_ShouldWorkAsync()
        {
            var coreResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_staking.EnumReleases();
            coreResult.Create("0x0A");

            var expectedResult = new EnumReleases();
            expectedResult.Create(Releases.V11_0_0);

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.StorageVersionAsync, 9122);
        }

        [Test]
        public async Task StorageVersionNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_staking.EnumReleases,
                EnumReleases>(_substrateRepository.Storage.Staking.StorageVersionAsync, 9122);
        }

        [Test]
        public async Task ChillThreshold_ShouldWorkAsync()
        {
            var coreResult = new SpArithmeticExt.Percent();
            coreResult.Create("0x5A");

            var expectedResult = new Percent(new U8(90));

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.Staking.ChillThresholdAsync);
        }

        [Test]
        public async Task ChillThresholdNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                SpArithmeticExt.Percent,
                Percent>(_substrateRepository.Storage.Staking.ChillThresholdAsync);
        }
    }
}
