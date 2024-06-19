using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using NUnit.Framework;
using static Polkanalysis.Domain.Contracts.Runtime.Module.TypeProperty;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    internal class FindPropertyTest : PolkadotIntegrationTest
    {
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _currentMetaData;
        private readonly ILogger<CurrentMetaData> _logger;

        public FindPropertyTest()
        {
            _logger = Substitute.For<ILogger<CurrentMetaData>>();
            _currentMetaData = new CurrentMetaData(_substrateService, _logger);
            _palletBuilder = new PalletBuilder(_substrateService, _currentMetaData, Substitute.For<ILogger<PalletBuilder>>());
        }

        [Test]
        public void FindProperty_WhenValidEvent_Created_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.Created);

            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("depositor"));
            Assert.That(property[0].Param, Is.EqualTo("T::AccountId"));
            Assert.That(property[0].TypeParam, Is.EqualTo(ParamType.AccountId));

            Assert.That(property[1].Name, Is.EqualTo("pool_id"));
            Assert.That(property[1].Param, Is.EqualTo("U32"));
            Assert.That(property[1].TypeParam, Is.EqualTo(ParamType.Primitive));
        }

        [Test]
        public void FindProperty_WhenValidEvent_StateChanged_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.StateChanged);
            //BaseTuple<U32, EnumPoolState>
            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("pool_id"));
            Assert.That(property[0].Param, Is.EqualTo("U32"));
            Assert.That(property[0].TypeParam, Is.EqualTo(ParamType.Primitive));

            Assert.That(property[1].Name, Is.EqualTo("new_state"));
            Assert.That(property[1].Param, Is.EqualTo("PoolState"));
            Assert.That(property[1].TypeParam, Is.EqualTo(ParamType.EnumSimple));
        }

        [Test]
        public void FindProperty_WhenValidEvent_PoolCommissionUpdated_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PoolCommissionUpdated);
            //BaseTuple<U32, BaseOpt<BaseTuple<Perbill, SubstrateAccount>>>
            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("pool_id"));
            Assert.That(property[1].Name, Is.EqualTo("current"));
        }

        [Test]
        public void FindProperty_WhenValidEvent_PoolCommissionChangeRateUpdated_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums.Event.PoolCommissionChangeRateUpdated);
            //BaseTuple<U32, CommissionChangeRate>
            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("pool_id"));
            Assert.That(property[1].Name, Is.EqualTo("change_rate"));
            Assert.That(property[1].SubProperties[0].Name, Is.EqualTo("max_increase"));
            Assert.That(property[1].SubProperties[1].Name, Is.EqualTo("min_delay"));
        }

        [Test]
        public void FindProperty_WhenCombineProperties_ShouldReturnProperties()
        {
            var property = _palletBuilder.FindProperty(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking.Enums.Event.ValidatorPrefsSet);
            Assert.That(property, Is.Not.Null);
            Assert.That(property[0].Name, Is.EqualTo("stash"));
            Assert.That(property[1].Name, Is.EqualTo("prefs"));
            Assert.That(property[1].SubProperties.Count, Is.GreaterThan(0));
            Assert.That(property[1].SubProperties[0].Name, Is.EqualTo("commission"));
            Assert.That(property[1].SubProperties[1].Name, Is.EqualTo("blocked"));
        }
    }
}
