using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Abstract;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Threading;

namespace Polkanalysis.Domain.Tests.Service
{
    public class AccountServiceTest : DomainTestAbstract
    {
        private IAccountService _accountService;
        private ISubstrateService _substrateRepository;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = Substitute.For<ISubstrateService>();
            _accountService = new AccountService(_substrateRepository, _substrateDbContext,  Substitute.For<ILogger<AccountService>>());

            // Mock Properties
            _substrateRepository.Rpc.System.PropertiesAsync(CancellationToken.None).Returns(new Substrate.NetApi.Model.Rpc.Properties()
            {
                Ss58Format = 0,
                TokenDecimals = 10,
                TokenSymbol = "DOT"
            });

            // Always a valid Substrate address
            _substrateRepository.IsValidAccountAddress(Arg.Any<string>()).Returns(true);
        }

        [Test, Ignore("Need to mock Query")]
        public async Task GetAccountsWithValidResponse_ShouldSucceedAsync()
        {
            var res = await _accountService.GetAccountsAsync(CancellationToken.None);
            Assert.Fail();
        }

        [Test]
        public async Task GetAccountsDetails_WithValidAddress_ShouldSuceedAsync()
        {
            string address = "16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS";
            var account = new SubstrateAccount(address);

            #region Mock balances lock
            _substrateRepository.Storage.Balances.LocksAsync(account, CancellationToken.None).Returns(new BaseVec<Infrastructure.Blockchain.Contracts.Pallet.Balances.BalanceLock>(
            [
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.BalanceLock(
                new Contracts.Core.Display.NameableSize8("democrac"),
                new U128(100),
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReasons(Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Reasons.Fee)
                ),
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.BalanceLock(
                new Contracts.Core.Display.NameableSize8("pyconvot"),
                new U128(150),
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReasons(Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Reasons.All)
                ),
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.BalanceLock(
                new Contracts.Core.Display.NameableSize8("xxxxxxxx"),
                new U128(200),
                new Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.EnumReasons(Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums.Reasons.All)
                )
            ]));
            #endregion

            #region Mock reserves
            _substrateRepository.Storage.Balances.ReservesAsync(Arg.Is(account), Arg.Any<CancellationToken>()).Returns(new BaseVec<Infrastructure.Blockchain.Contracts.Pallet.Balances.ReserveData>(
                    new Infrastructure.Blockchain.Contracts.Pallet.Balances.ReserveData[]
                    {
                        new Infrastructure.Blockchain.Contracts.Pallet.Balances.ReserveData(
                            new Contracts.Core.Display.FlexibleNameable().FromText("HelloIAmTheReserve"),
                            new U128(100))
                    }
                ));
            #endregion

            #region Mock identity
            var enumJudgement = new EnumJudgement();
            enumJudgement.Create(Judgement.Reasonable, new BaseVoid());
            var judgements = new BaseVec<BaseTuple<U32, EnumJudgement>>(new BaseTuple<U32, EnumJudgement>[]
            {
                new BaseTuple<U32, EnumJudgement>(new U32(1), enumJudgement)
            });

            _substrateRepository.Storage.Identity.IdentityOfAsync(
                Arg.Is(new SubstrateAccount(address)), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.Identity.Registration(
                    new Infrastructure.Blockchain.Contracts.Pallet.Identity.IdentityInfo().From(
                        display: "AccountName",
                        legal: "AliceLegal",
                        web: "www.alice.com",
                        riot: "alice@riot",
                        email: null,
                        pgpFingerprint: "xxxx",
                        twitter: "AliceTwitter",
                        image: "www.alice.com/image.jpg",
                        additional: new BaseVec<BaseTuple<EnumData, EnumData>>()
                    ),
                    new U128(100),
                    judgements
                ));
            #endregion

            _substrateRepository.Storage.Identity.SubsOfAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();
            _substrateRepository.Storage.Identity.SuperOfAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();

            _substrateRepository.Storage.NominationPools.PoolMembersAsync(Arg.Is(account), Arg.Any<CancellationToken>()).Returns(new Infrastructure.Blockchain.Contracts.Pallet.NominationPools.PoolMember(
                new U32(100),
                new U128(1000),
                new U128(1001),
                new BaseVec<BaseTuple<U32, U128>>(new BaseTuple<U32, U128>[]
                {
                    new BaseTuple<U32, U128>(new U32(1), new U128(100))
                })
                ));

            _substrateRepository.Storage.System.AccountAsync(Arg.Is(account), Arg.Any<CancellationToken>()).Returns(
                new AccountInfo(
                    new U32(11),
                    new U32(20),
                    new U32(30),
                    new U32(40),
                    new Infrastructure.Blockchain.Contracts.Pallet.Balances.AccountData(
                        new U128(5000),
                        new U128(60),
                        new U128(70),
                        new U128(80))));


            _substrateRepository.Rpc.System.AccountNextIndexAsync(address, Arg.Any<CancellationToken>()).Returns((uint)10);

            AccountDto res = await _accountService.GetAccountDetailAsync("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS", CancellationToken.None);

            Assert.That(res.InformationsDto.Name, Is.EqualTo("AccountName"));
            Assert.That(res.InformationsDto.Website, Is.EqualTo("www.alice.com"));
            Assert.That(res.InformationsDto.Legal, Is.EqualTo("AliceLegal"));
            Assert.That(res.InformationsDto.Matrix, Is.EqualTo("alice@riot"));
            Assert.That(res.InformationsDto.Email, Is.Empty);
            Assert.That(res.InformationsDto.Image, Is.EqualTo("www.alice.com/image.jpg"));
            Assert.That(res.InformationsDto.Other, Is.Null);

            Assert.That(res.Balances.Transferable.Native, Is.EqualTo(0.0000005));
            Assert.That(res.Balances.Pool.Native, Is.EqualTo(0.0000001));
            
            Assert.That(res.Balances.NonTransferable.Count(), Is.EqualTo(3));
            Assert.That(res.Balances.NonTransferable[0].Currency.Native, Is.EqualTo(0.00000001));
            Assert.That(res.Balances.NonTransferable[0].Reason, Is.EqualTo("Democracy"));
            Assert.That(res.Balances.NonTransferable[1].Currency.Native, Is.EqualTo(0.000000015));
            Assert.That(res.Balances.NonTransferable[1].Reason, Is.EqualTo("Referenda"));
            Assert.That(res.Balances.NonTransferable[2].Currency.Native, Is.EqualTo(0.00000002));
            Assert.That(res.Balances.NonTransferable[2].Reason, Is.EqualTo("xxxxxxxx"));

            Assert.That(res.Balances.Crowdloan.Native, Is.EqualTo(0));
            Assert.That(res.Balances.Total.Native, Is.EqualTo(0.000000645));

            Assert.That(res.Address.Name, Is.EqualTo("AccountName"));
            Assert.That(res.Address.Address, Is.EqualTo("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS"));
            
            Assert.That(res.AccountIndex, Is.EqualTo((uint)10));
            Assert.That(res.Nonce, Is.EqualTo((uint)11));
            
            Assert.That(res.AccountTypes.Count(), Is.EqualTo(2));
            Assert.That(res.AccountTypes[0], Is.EqualTo(AccountType.OnChainIdentity));
            Assert.That(res.AccountTypes[1], Is.EqualTo(AccountType.PoolMember));
        }

        [Test]
        public void GetAccountsDetailsWithInvalidAddress_ShouldThrowException()
        {
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountDetailAsync(null!, CancellationToken.None));
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountDetailAsync(string.Empty, CancellationToken.None));
                //Assert.ThrowsAsync<AddressException>(async () => await _accountService.GetAccountDetailAsync("InvalidAddressHash", CancellationToken.None));
            });
        }

        [Test]
        public async Task GetAccountTypeAsync_WithValidAccount_ShouldSucceedAsync()
        {
            var account = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");

            _substrateRepository.Storage.Session.NextKeysAsync(Arg.Is(account), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.Session.SessionKeysPolka());
            _substrateRepository.Storage.Staking.NominatorsAsync(Arg.Is(account), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.Staking.Nominations());
            _substrateRepository.Storage.Identity.IdentityOfAsync(Arg.Is(account), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.Identity.Registration());
            _substrateRepository.Storage.NominationPools.PoolMembersAsync(Arg.Is(account), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.NominationPools.PoolMember());

            var accountType = await _accountService.GetAccountTypeAsync(account, CancellationToken.None);

            Assert.That(accountType.Count(), Is.EqualTo(4));
            Assert.That(accountType.Any(x => x == AccountType.OnChainIdentity), Is.True);
            Assert.That(accountType.Any(x => x == AccountType.PoolMember), Is.True);
            Assert.That(accountType.Any(x => x == AccountType.Validator), Is.True);
            Assert.That(accountType.Any(x => x == AccountType.Nominator), Is.True);
        }

        [Test]
        public async Task GetAccountTypeAsync_WhenEverythingIsNull_ShouldSucceedAsync()
        {
            var account = new SubstrateAccount("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS");

            _substrateRepository.Storage.Session.NextKeysAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();
            _substrateRepository.Storage.Staking.NominatorsAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();
            _substrateRepository.Storage.Identity.IdentityOfAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();
            _substrateRepository.Storage.NominationPools.PoolMembersAsync(Arg.Is(account), Arg.Any<CancellationToken>()).ReturnsNull();

            var accountTypeAddress = await _accountService.GetAccountTypeAsync("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS", CancellationToken.None);
            var accountType = await _accountService.GetAccountTypeAsync(account, CancellationToken.None);

            Assert.That(accountTypeAddress.Count(), Is.EqualTo(0));
            Assert.That(accountType.Count(), Is.EqualTo(0));
        }

        [Test]
        [TestCase("16aP3oTaD7oQ6qmxU6fDAi7NWUB7knqH6UsWbwjnAhvRSxzS", "AccountName")]
        public async Task GetAccountsIdentityWithValidAddress_ShouldSucceedAsync(string address, string name)
        {
            var enumJudgement = new EnumJudgement();
            enumJudgement.Create(Judgement.Reasonable, new BaseVoid());
            var judgements = new BaseVec<BaseTuple<U32, EnumJudgement>>(new BaseTuple<U32, EnumJudgement>[]
            {
                new BaseTuple<U32, EnumJudgement>(new U32(1), enumJudgement)
            });

            _substrateRepository.Storage.Identity.IdentityOfAsync(
                Arg.Is(new SubstrateAccount(address)), Arg.Any<CancellationToken>())
                .Returns(new Infrastructure.Blockchain.Contracts.Pallet.Identity.Registration(
                    new Infrastructure.Blockchain.Contracts.Pallet.Identity.IdentityInfo().From(
                        display: name,
                        legal: "AliceLegal",
                        web: "www.alice.com",
                        riot: "alice@riot",
                        email: null,
                        pgpFingerprint: "xxxx",
                        twitter: "AliceTwitter",
                        image: "www.alice.com/image.jpg",
                        additional: new BaseVec<BaseTuple<EnumData, EnumData>>()
                    ),
                    new U128(100),
                    judgements
                ));

            var aliceDto = await _accountService.GetAccountAddressAsync(address, CancellationToken.None);

            Assert.That(aliceDto.Address, Is.EqualTo(address));
            Assert.That(aliceDto.PublicKey, Is.EqualTo(Utils.Bytes2HexString(Utils.GetPublicKeyFrom(address))));
            Assert.That(aliceDto.Name, Is.EqualTo(name));
        }

        [Test]
        public void GetAccountsIdentityWithInvalidAddress_ShouldThrowException()
        {
            Assert.Multiple(() =>
            {
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountAddressAsync((string)null!, CancellationToken.None));
                Assert.ThrowsAsync<ArgumentNullException>(async () => await _accountService.GetAccountAddressAsync(string.Empty, CancellationToken.None));
                //Assert.ThrowsAsync<AddressException>(async () => await _accountService.GetAccountIdentityAsync("InvalidAddressHash", CancellationToken.None));
            });
        }
    }
}
