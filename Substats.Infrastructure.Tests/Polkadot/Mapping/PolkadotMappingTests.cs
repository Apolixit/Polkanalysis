﻿using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Infrastructure.Tests.Polkadot.Repository;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Mapping
{
    public class PolkadotMappingTests : PolkadotRepositoryMock
    {
        [Test]
        public void SubstrateAccount_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount(MockAddress);
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(substrateAccount);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void AccountId32_ToSubstrateAccount_ShouldWork()
        {
            var accountId32 = new AccountId32();
            var publicKey = Utils.GetPublicKeyFrom(MockAddress);
            accountId32.Create(publicKey);

            var substrateAccount = SubstrateMapper.Instance.Map<AccountId32, SubstrateAccount>(accountId32);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void ParachainId_ShouldWork()
        {
            var s1 = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            s1.Create("0x01000000");

            var d1 = SubstrateMapper.Instance.Map<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Domain.Contracts.Core.Id>(s1);

            Assert.That(s1.Value, Is.EqualTo(d1.Value));

            // Reverse
            var s2 = new Domain.Contracts.Core.Id(1);

            var d2 = SubstrateMapper.Instance.Map<
                Domain.Contracts.Core.Id,
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(s2);

            Assert.That(s2.Value, Is.EqualTo(d2.Value));
        }

        [Test]
        public void BaseVec_FromOneToAnother_ShouldWork()
        {
            var source = new BaseVec<SubstrateAccount>(new SubstrateAccount[] 
            { 
                new SubstrateAccount(MockAddress),
                new SubstrateAccount(MockAddress2)
            });

            // Convert BaseVec<SubstrateAccount> to BaseVec<AccountId32>
            BaseVec<AccountId32> dest = SubstrateMapper.Instance.Map<BaseVec<SubstrateAccount>, BaseVec<AccountId32>>(source);
            Assert.That(dest, Is.Not.Null);
        }

        [Test]
        public void PublicEd25519_ShouldWork()
        {
            Assert.Fail();
        }

        [Test]
        public void PublicSr25519_ShouldWork()
        {
            Assert.Fail();
        }
    }
}
