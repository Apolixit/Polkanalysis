using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Dto;
using Substats.Domain.Contracts.Runtime.Module;
using Substats.Domain.Runtime.Module;
using Substats.Domain.Runtime;
using Ajuna.NetApi.Model.Meta;
using Microsoft.Win32;
using Org.BouncyCastle.Asn1.Utilities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using System.Security.Principal;

namespace Substats.Domain.Integration.Tests.Runtime.Module
{
    public class ModuleInformationTest : PolkadotIntegrationTest
    {
        private IModuleInformation _moduleRepository;

        [SetUp]
        public void Setup()
        {
            _moduleRepository = new ModuleInformation(
                new CurrentMetaData(
                    _substrateRepository,
                    Substitute.For<ILogger<CurrentMetaData>>()
            ),
            new ModelBuilder()
            );
        }

        /// <summary>
        /// Got all current module to check if everything is ok
        /// </summary>
        private static string[] PolkadotModules = new string[]
        {
            "System", "Scheduler", "Preimage", "Babe", "Timestamp", "Indices", "Balances", "TransactionPayment", "Authorship", "Staking", "Offences", "Historical", "Session", "Grandpa", "ImOnline", "AuthorityDiscovery", "Democracy", "Council", "TechnicalCommittee", "PhragmenElection", "TechnicalMembership", "Treasury", "Claims", "Vesting", "Utility", "Identity", "Proxy", "Multisig", "Bounties", "ChildBounties", "Tips", "ElectionProviderMultiPhase", "VoterList", "NominationPools", "FastUnstake", "ParachainsOrigin", "Configuration", "ParasShared", "ParaInclusion", "ParaInherent", "ParaScheduler", "Paras", "Initializer", "Dmp", "Ump", "Hrmp", "ParaSessionInfo", "ParasDisputes", "Registrar", "Slots", "Auctions", "Crowdloan", "XcmPallet"
        };

        [Test]
        public void Module_PalletBalances_ShouldWork()
        {
            var res = _moduleRepository.GetModuleDetail("balances");

            Assert.That(res, Is.Not.Null);

            Assert.That(res.Events, Is.Not.Null);
            Assert.That(res.Events.Count, Is.EqualTo(10));

            Assert.That(res.Calls, Is.Not.Null);
            Assert.That(res.Calls.Count, Is.EqualTo(6));

            Assert.That(res.Storage, Is.Not.Null);
            Assert.That(res.Storage.Count, Is.EqualTo(5));

            Assert.That(res.Constants, Is.Not.Null);
            Assert.That(res.Constants.Count, Is.EqualTo(3));

            Assert.That(res.Errors, Is.Not.Null);
            Assert.That(res.Errors.Count, Is.EqualTo(8));
        }

        [Test]
        [TestCaseSource(nameof(PolkadotModules))]
        public void Module_CheckEveryCurrentRuntimeModule_ShouldWork(string module)
        {
            var res = _moduleRepository.GetModuleDetail(module);
            Assert.That(res, Is.Not.Null);
        }
    }
}
