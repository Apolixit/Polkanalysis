using Polkanalysis.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class ModuleInformationTest : PolkadotIntegrationTest
    {
        private IModuleInformation _moduleRepository;
        private ISubstrateService _substrateService;

        [SetUp]
        public void Setup()
        {
            _moduleRepository = new ModuleInformation(
                new CurrentMetaData(
                    _substrateRepository,
                    Substitute.For<ILogger<CurrentMetaData>>()
            ),
            new ModelBuilder(), _substrateRepository
            );
        }

        /// <summary>
        /// Got all current module to check if everything is ok
        /// </summary>
        private static string[] PolkadotModules = new string[]
        {
            "System", "Scheduler", "Preimage", "Babe", "Timestamp", "Indices", "Balances", "TransactionPayment", "Authorship", "Staking", "Offences", "Historical", "Session", "Grandpa", "ImOnline", "AuthorityDiscovery", "Democracy", "Council", "TechnicalCommittee", "PhragmenElection", "TechnicalMembership", "Treasury", "Claims", "Vesting", "Utility", "Identity", "Proxy", "Multisig", "Bounties", "ChildBounties", "Tips", "ElectionProviderMultiPhase", "VoterList", "NominationPools", "FastUnstake", "ParachainsOrigin", "Configuration", "ParasShared", "ParaInclusion", "ParaInherent", "ParaScheduler", "Paras", "Initializer", "Dmp", "Ump", "Hrmp", "ParaSessionInfo", "ParasDisputes", "Registrar", "Slots", "Auctions", "Crowdloan", "XcmPallet"
        };

        [Test, Timeout(2000)]
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
