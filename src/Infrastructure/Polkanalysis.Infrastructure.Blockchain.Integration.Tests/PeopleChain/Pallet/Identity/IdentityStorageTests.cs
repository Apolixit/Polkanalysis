using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.PeopleChain.Pallet.Identity
{
    internal class IdentityStorageTests : PeopleChainIntegrationTests
    {
        [Test]
        [TestCase(504300, "14Xh9F14w9GPwprsytsXd9nCpf9VvjAUTg5Mj7zN2SU8RBDj")]
        public async Task IdentityOf_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.IdentityOfAsync(new SubstrateAccount(address), CancellationToken.None);
            
            Assert.That(res, Is.Not.Null);

            var judgement = res.Judgements.Value[0].As<BaseTuple<U32, EnumJudgement>>();
            Assert.That(judgement.Value[0].As<U32>().Value, Is.EqualTo(3));
            Assert.That(judgement.Value[1].As<EnumJudgement>().Value, Is.EqualTo(Judgement.Reasonable));

            var info = res.Info;
            Assert.That(info.Display.ToHuman(), Is.EqualTo("I Love Cripto BD"));
        }

        [Test]
        [TestCase(504300, "1REAJ1k691g5Eqqg9gL7vvZCBG7FCCZ8zgQkZWd4va5ESih")]
        public async Task SubsOf_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.SubsOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(583390, "13zeUFXbkfQg22e13Ux1mLWXRxRhnpPUf4229zpnCbffWPnF")]
        public async Task SuperOf_ShouldWorkAsync(int blockNum, string address)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.SuperOfAsync(new SubstrateAccount(address), CancellationToken.None);
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value[0].As<SubstrateAccount>().ToPolkadotAddress(), Is.EqualTo("14Gn7SEmCgMX7Ukuppnw5TRjA7pao2HFpuJo39frB42tYLEh"));
        }

        [Test]
        [TestCase(504300)]
        public async Task Registrars_ShouldWorkAsync(int blockNum)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.RegistrarsAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [TestCase(639400, "152Rg99tAkt8BM3H9VcV88dxWys2WpZQ8r3LuVyAUozmzcv7")]
        public async Task UsernameAuthorities_ShouldWorkAsync(int blockNum, string account)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.UsernameAuthoritiesAsync(new SubstrateAccount(account), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Allocation.Value, Is.EqualTo(1_000_000));
            Assert.That(res.SuffixStr, Is.EqualTo("dot"));
            
        }

        [Test, Ignore("No test case")]
        [TestCase(1)]
        public async Task AccountOfUsername_ShouldWorkAsync(int blockNum)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.AccountOfUsernameAsync(new BaseVec<U8>() { }, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }

        [Test, Ignore("No test case")]
        [TestCase(1)]
        public async Task PendingUsernames_ShouldWorkAsync(int blockNum)
        {
            var res = await _substrateRepository.At(blockNum).Storage.Identity.PendingUsernamesAsync(new BaseVec<U8>() { }, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
