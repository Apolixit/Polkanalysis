﻿using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Integration.Tests.Contracts;
using NSubstitute;
using NUnit.Framework;

namespace Blazscan.Domain.Integration.Tests.Polkadot.Errors
{
    public class SystemErrorListenerTest : PolkadotIntegrationTest
    {
        private ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(), 
                _substrateRepository,
                new PalletBuilder(_substrateRepository, new CurrentMetaData(_substrateRepository)));
        }
        
        [Test]
        [TestCase("0x00020000000001030504000000D861040D00000000000000")]
        public void System_ExtrinsicFailed_Index_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }

        [Test]
        [TestCase("0x000100000000002861D5DD77000000020000")]
        public void RuntimeEvent_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }
    }
}