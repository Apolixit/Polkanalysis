using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Runtime.Metadata;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Tests.Service
{
    public class MetadataServiceTest
    {
        private MetadataService _metadataService;
        protected string MockFiles = "\\Runtime\\Metadata\\Mocks\\";
        [SetUp]
        public void Setup()
        {
            _metadataService = new MetadataService();
        }

        private string readMetadataFromFile(string metadataName)
        {
            return File.ReadAllText($"{AppContext.BaseDirectory}{MockFiles}{metadataName}.txt");
        }

        private IList<PalletCallMetadataV9> generatePalletCallMetadataV9(int nb)
        {
            return Enumerable.Range(1, nb).Select(x => new PalletCallMetadataV9()
            {
                Name = new Str($"Test_{x}"),
                Docs = new BaseVec<Str>(new Str[] { new Str($"DocumentationCall_{x}") }),
                Args = new BaseVec<PalletCallArgsMetadataV9>(new PalletCallArgsMetadataV9[] {
                        new PalletCallArgsMetadataV9()
                        {
                            Name = new Str($"PalletCallArgsMetadataV9_Name_{x}"),
                            CallType = new Str($"PalletCallArgsMetadataV9_CallType_{x}")
                        }
                    })
            }).ToList();
        }

        private IList<PalletEventMetadataV9> generatePalletEventMetadataV9(int nb)
        {
            return Enumerable.Range(1, nb).Select(x => new PalletEventMetadataV9()
            {
                Name = new Str($"TestEvent_{x}"),
                Docs = new BaseVec<Str>(new Str[] { new Str($"DocumentationEvent_{x}") }),
                Args = new BaseVec<Str>(new Str[] { new Str($"ArgsEvent_{x}") })
            }).ToList();
        }

        private IList<PalletConstantMetadataV9> generatePalletConstantsMetadataV9(int nb)
        {
            var u8 = new U8();
            u8.Create(byte.MaxValue);
            var value = new ByteGetter();
            value.Create(new U8[] { u8 });

            return Enumerable.Range(1, nb).Select(x => new PalletConstantMetadataV9()
            {
                Name = new Str($"TestConstant_{x}"),
                ConstantType = new Str("ConstantType"),
                Documentation = new BaseVec<Str>(new Str[] { new Str($"DocumentationConstant_{x}") }),
                Value = value
            }).ToList();
        }

        private IList<PalletErrorMetadataV9> generatePalletErrorsMetadataV9(int nb)
        {
            return Enumerable.Range(1, nb).Select(x => new PalletErrorMetadataV9()
            {
                Name = new Str($"TestError_{x}"),
                Docs = new BaseVec<Str>(new Str[] { new Str($"DocumentationError_{x}") }),
            }).ToList();
        }

        [Test]
        public void MetadataV9_PalletCallDiff_ShouldSuceed()
        {
            IList<PalletCallMetadataV9> calls1 = generatePalletCallMetadataV9(4);
            IList<PalletCallMetadataV9> calls2 = generatePalletCallMetadataV9(4);

            var calls_1 = new List<PalletCallMetadataV9>() { calls1[0], calls1[1], calls1[2] };

            calls2[2].Args.Value[0].CallType.Value = "Changed !";
            var calls_2 = new List<PalletCallMetadataV9>() { calls2[1], calls2[2], calls2[3] };

            var res = _metadataService.CompareModuleCallsV9(calls_1, calls_2).ToList();

            Assert.That(res, Is.Not.Null);
            Assert.That(res[0], Is.EqualTo((CompareStatus.Added, calls2[3])));
            Assert.That(res[1], Is.EqualTo((CompareStatus.Removed, calls1[0])));
        }

        [Test]
        public void MetadataV9_PalletEventDiff_ShouldSuceed()
        {
            IList<PalletEventMetadataV9> calls1 = generatePalletEventMetadataV9(4);
            IList<PalletEventMetadataV9> calls2 = generatePalletEventMetadataV9(4);

            var calls_1 = new List<PalletEventMetadataV9>() { calls1[0], calls1[1], calls1[2] };

            calls2[2].Args.Value[0].Value = "Changed !";
            var calls_2 = new List<PalletEventMetadataV9>() { calls2[1], calls2[2], calls2[3] };

            var res = _metadataService.CompareModuleEventsV9(calls_1, calls_2).ToList();

            Assert.That(res, Is.Not.Null);
            Assert.That(res[0], Is.EqualTo((CompareStatus.Added, calls2[3])));
            Assert.That(res[1], Is.EqualTo((CompareStatus.Removed, calls1[0])));
        }

        [Test]
        public void MetadataV9_PalletConstantDiff_ShouldSuceed()
        {
            IList<PalletConstantMetadataV9> calls1 = generatePalletConstantsMetadataV9(4);
            IList<PalletConstantMetadataV9> calls2 = generatePalletConstantsMetadataV9(4);

            var calls_1 = new List<PalletConstantMetadataV9>() { calls1[0], calls1[1], calls1[2] };

            calls2[2].ConstantType.Value = "Changed !";
            var calls_2 = new List<PalletConstantMetadataV9>() { calls2[1], calls2[2], calls2[3] };

            var res = _metadataService.CompareModuleConstantsV9(calls_1, calls_2).ToList();

            Assert.That(res, Is.Not.Null);
            Assert.That(res[0], Is.EqualTo((CompareStatus.Added, calls2[3])));
            Assert.That(res[1], Is.EqualTo((CompareStatus.Removed, calls1[0])));
        }

        [Test]
        public void MetadataV9_PalletErrorDiff_ShouldSuceed()
        {
            IList<PalletErrorMetadataV9> calls1 = generatePalletErrorsMetadataV9(4);
            IList<PalletErrorMetadataV9> calls2 = generatePalletErrorsMetadataV9(4);

            var calls_1 = new List<PalletErrorMetadataV9>() { calls1[0], calls1[1], calls1[2] };

            calls2[2].Docs.Value[0].Value = "Changed !";
            var calls_2 = new List<PalletErrorMetadataV9>() { calls2[1], calls2[2], calls2[3] };

            var res = _metadataService.CompareModuleErrorsV9(calls_1, calls_2).ToList();

            Assert.That(res, Is.Not.Null);
            Assert.That(res[0], Is.EqualTo((CompareStatus.Added, calls2[3])));
            Assert.That(res[1], Is.EqualTo((CompareStatus.Removed, calls1[0])));
        }

        [Test]
        public void Metadata_CheckDifferentialPallet_ShouldSuceed()
        {
            var m1 = new List<ModuleMetadataV11>()
            {
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_1")
                },
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_2")
                },
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_3")
                }
            };

            var m2 = new List<ModuleMetadataV11>()
            {
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_2")
                },
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_3")
                },
                new ModuleMetadataV11()
                {
                    Name = new Str("Module_4")
                }
            };

            Assert.That(_metadataService.NameDiff<ModuleMetadataV11>(null, null).Count(), Is.EqualTo(0));

            var resOnlyFirstListNull = _metadataService.NameDiff(m1, null);
            Assert.That(resOnlyFirstListNull.All(x => x.Item1 == CompareStatus.Removed), Is.True);
            Assert.That(resOnlyFirstListNull.Count(), Is.EqualTo(m1.Count));

            var resOnlyFirstListEmpty = _metadataService.NameDiff(m1, new List<ModuleMetadataV11>());
            Assert.That(resOnlyFirstListEmpty.All(x => x.Item1 == CompareStatus.Removed), Is.True);
            Assert.That(resOnlyFirstListEmpty.Count(), Is.EqualTo(m1.Count));

            var resOnlySecondListNull = _metadataService.NameDiff(null, m2);
            Assert.That(resOnlySecondListNull.All(x => x.Item1 == CompareStatus.Added), Is.True);
            Assert.That(resOnlySecondListNull.Count(), Is.EqualTo(m2.Count));

            var resOnlySecondListEmpty = _metadataService.NameDiff(null, m2);
            Assert.That(resOnlySecondListEmpty.All(x => x.Item1 == CompareStatus.Added), Is.True);
            Assert.That(resOnlySecondListEmpty.Count(), Is.EqualTo(m2.Count));

            var res = _metadataService.NameDiff(m1, m2).ToList();
            Assert.That(res[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(res[1].Item1, Is.EqualTo(CompareStatus.Removed));

        }

        [Test]
        public async Task MetadataV11_SpecVersionCompare_V0_And_V1_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V11\\MetadataV11_0");
            var metadataDestination = readMetadataFromFile("V11\\MetadataV11_1");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V11));

            var res = await _metadataService.MetadataCompareV11Async(
                new MetadataV11(metadataSource),
                new MetadataV11(metadataDestination));

            Assert.That(res, Is.Not.Null);
            Assert.That(res.AllModulesDiff.Count(), Is.EqualTo(31));
            Assert.That(res.UnchangedModules.Count(), Is.EqualTo(30));
            Assert.That(res.ChangedModules.Count(), Is.EqualTo(1));

            Assert.That(res.ChangedModules.First().ModuleName, Is.EqualTo("Claims"));
            var errors = res.ChangedModules.First().Errors.ToList();

            Assert.That(errors.Count, Is.EqualTo(2));

            // VestedBalanceExists error has been added
            Assert.That(errors[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(errors[0].Item2.Name.Value, Is.EqualTo("VestedBalanceExists"));

            // DestinationVesting error has been removed
            Assert.That(errors[1].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(errors[1].Item2.Name.Value, Is.EqualTo("DestinationVesting"));
        }

        [Test]
        public async Task MetadataV11_SpecVersionCompare_V6_And_V7_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V11\\MetadataV11_6");
            var metadataDestination = readMetadataFromFile("V11\\MetadataV11_7");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V11));

            var res = await _metadataService.MetadataCompareV11Async(
                new MetadataV11(metadataSource),
                new MetadataV11(metadataDestination));

            Assert.That(res, Is.Not.Null);
            Assert.That(res.AllModulesDiff.Count(), Is.EqualTo(34));
            Assert.That(res.UnchangedModules.Count(), Is.EqualTo(33));
            Assert.That(res.ChangedModules.Count(), Is.EqualTo(1));

            Assert.That(res.ChangedModules.First().ModuleName, Is.EqualTo("Indices"));
            
            var calls = res.ChangedModules.First().Calls.ToList();
            Assert.That(calls.Count, Is.EqualTo(1));
            Assert.That(calls[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(calls[0].Item2.Name.Value, Is.EqualTo("freeze"));

            var events = res.ChangedModules.First().Events.ToList();
            Assert.That(events.Count, Is.EqualTo(1));
            Assert.That(events[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(events[0].Item2.Name.Value, Is.EqualTo("IndexFrozen"));
        }

        [Test]
        public async Task MetadataV11_SpecVersionCompare_V23_And_V24_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V11\\MetadataV11_23");
            var metadataDestination = readMetadataFromFile("V11\\MetadataV11_24");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V11));

            var res = await _metadataService.MetadataCompareV11Async(
                new MetadataV11(metadataSource),
                new MetadataV11(metadataDestination));

            Assert.That(res, Is.Not.Null);

            Assert.That(res.AddedModules, Is.Not.Null);
            Assert.That(res.AddedModules.First().ModuleName, Is.EqualTo("DummyPurchase"));

            Assert.That(res.RemovedModules, Is.Not.Null);
            Assert.That(res.RemovedModules.First().ModuleName, Is.EqualTo("Purchase"));

            Assert.That(res.ChangedModules.Count(), Is.EqualTo(3));

            if (res.ChangedModules.ToList() is [var first, var second, var third])
            {
                Assert.That(first.ModuleName, Is.EqualTo("DummyRegistrar"));
                Assert.That(first.Events.Count, Is.EqualTo(1));
                Assert.That(first.Events.First().Item1, Is.EqualTo(CompareStatus.Added));
                Assert.That(first.Events.First().Item2.Name.Value, Is.EqualTo("Dummy"));

                Assert.That(second.ModuleName, Is.EqualTo("DummySlots"));
                Assert.That(second.Events.Count, Is.EqualTo(1));
                Assert.That(second.Events.First().Item1, Is.EqualTo(CompareStatus.Added));
                Assert.That(second.Events.First().Item2.Name.Value, Is.EqualTo("Dummy"));

                Assert.That(third.ModuleName, Is.EqualTo("Multisig"));
                var constants = third.Constants.ToList();
                Assert.That(constants.Count, Is.EqualTo(3));

                Assert.That(constants[0].Item2.Name.Value, Is.EqualTo("DepositBase"));
                Assert.That(constants[0].Item2.ConstantType.Value, Is.EqualTo("BalanceOf<T>"));

                Assert.That(constants[1].Item2.Name.Value, Is.EqualTo("DepositFactor"));
                Assert.That(constants[1].Item2.ConstantType.Value, Is.EqualTo("BalanceOf<T>"));

                Assert.That(constants[2].Item2.Name.Value, Is.EqualTo("MaxSignatories"));
                Assert.That(constants[2].Item2.ConstantType.Value, Is.EqualTo("u16"));

            } else
                Assert.Fail();
        }

        [Test]
        public async Task MetadataV12_SpecVersionCompare_V27_And_V28_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V12\\MetadataV12_27");
            var metadataDestination = readMetadataFromFile("V12\\MetadataV12_28");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V12));

            var res = await _metadataService.MetadataCompareV12Async(
                new MetadataV12(metadataSource),
                new MetadataV12(metadataDestination));

            Assert.That(res, Is.Not.Null);

            var addedModules = res.AddedModules.ToList();
            Assert.That(addedModules.Count, Is.EqualTo(2));

            Assert.That(addedModules[0].ModuleName, Is.EqualTo("Bounties"));
            Assert.That(addedModules[1].ModuleName, Is.EqualTo("Tips"));

            var changedModules = res.ChangedModules.ToList();
            Assert.That(changedModules.Count, Is.EqualTo(7));

            Assert.That(changedModules[0].ModuleName, Is.EqualTo("Babe"));
            Assert.That(changedModules[0].Storage.First().Item2.status, Is.EqualTo(CompareStatus.Added));
            Assert.That(changedModules[0].Storage.First().Item2.storage.Name.Value, Is.EqualTo("NextAuthorities"));
            Assert.IsTrue(changedModules[0].HasStorageAdded("NextAuthorities"));

            // Now let's test ElectionsPhragmen which changed a lot
            var electionPhragmenModule = changedModules[1];
            Assert.That(electionPhragmenModule.ModuleName, Is.EqualTo("ElectionsPhragmen"));

            // No storage changes
            var electionPhragmenStorages = electionPhragmenModule.Storage.ToList();
            Assert.That(electionPhragmenStorages.Count, Is.EqualTo(0));

            var electionPhragmenCalls = electionPhragmenModule.Calls.ToList();
            Assert.That(electionPhragmenCalls[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenCalls[0].Item2.Name.Value, Is.EqualTo("clean_defunct_voters"));
            Assert.IsTrue(electionPhragmenModule.HasCallAdded("clean_defunct_voters"));

            Assert.That(electionPhragmenCalls[1].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenCalls[1].Item2.Name.Value, Is.EqualTo("report_defunct_voter"));
            Assert.IsTrue(electionPhragmenModule.HasCallRemoved("report_defunct_voter"));

            var electionPhragmenConstants = electionPhragmenModule.Constants.ToList();
            Assert.That(electionPhragmenConstants[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenConstants[0].Item2.Name.Value, Is.EqualTo("VotingBondBase"));
            Assert.IsTrue(electionPhragmenModule.HasConstantAdded("VotingBondBase"));

            Assert.That(electionPhragmenConstants[1].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenConstants[1].Item2.Name.Value, Is.EqualTo("VotingBondFactor"));

            Assert.That(electionPhragmenConstants[2].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenConstants[2].Item2.Name.Value, Is.EqualTo("VotingBond"));
            Assert.IsTrue(electionPhragmenModule.HasConstantRemoved("VotingBond"));

            var electionPhragmenEvents = electionPhragmenModule.Events.ToList();
            Assert.That(electionPhragmenEvents[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenEvents[0].Item2.Name.Value, Is.EqualTo("Renounced"));
            Assert.IsTrue(electionPhragmenModule.HasEventAdded("Renounced"));

            Assert.That(electionPhragmenEvents[1].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenEvents[1].Item2.Name.Value, Is.EqualTo("MemberRenounced"));
            Assert.IsTrue(electionPhragmenModule.HasEventRemoved("MemberRenounced"));

            Assert.That(electionPhragmenEvents[2].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenEvents[2].Item2.Name.Value, Is.EqualTo("VoterReported"));

            var electionPhragmenErrors = electionPhragmenModule.Errors.ToList();
            Assert.That(electionPhragmenErrors[0].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenErrors[0].Item2.Name.Value, Is.EqualTo("RunnerUpSubmit"));
            Assert.IsTrue(electionPhragmenModule.HasErrorAdded("RunnerUpSubmit"));

            Assert.That(electionPhragmenErrors[1].Item1, Is.EqualTo(CompareStatus.Added));
            Assert.That(electionPhragmenErrors[1].Item2.Name.Value, Is.EqualTo("InvalidWitnessData"));

            Assert.That(electionPhragmenErrors[2].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenErrors[2].Item2.Name.Value, Is.EqualTo("RunnerSubmit"));

            Assert.That(electionPhragmenErrors[3].Item1, Is.EqualTo(CompareStatus.Removed));
            Assert.That(electionPhragmenErrors[3].Item2.Name.Value, Is.EqualTo("InvalidCandidateCount"));
            Assert.IsTrue(electionPhragmenModule.HasErrorRemoved("InvalidCandidateCount"));
        }

        [Test]
        public async Task MetadataV13_SpecVersionCompare_V9080_And_V9090_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V13\\MetadataV13_9080");
            var metadataDestination = readMetadataFromFile("V13\\MetadataV13_9090");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V13));

            var res = await _metadataService.MetadataCompareV13Async(
                new MetadataV13(metadataSource),
                new MetadataV13(metadataDestination));

            Assert.That(res, Is.Not.Null);
            var changedModules = res.ChangedModules.ToList();

            Assert.That(changedModules[0].ModuleName, Is.EqualTo("Authorship"));
            Assert.IsTrue(changedModules[0].HasConstantAdded("UncleGenerations"));

            Assert.That(changedModules[1].ModuleName, Is.EqualTo("Balances"));
            Assert.IsTrue(changedModules[1].HasConstantAdded("MaxLocks"));
            Assert.IsTrue(changedModules[1].HasConstantAdded("MaxReserves"));

            Assert.That(changedModules[2].ModuleName, Is.EqualTo("Democracy"));
            Assert.That(changedModules[2].Constants.Count(), Is.EqualTo(2));
            Assert.IsTrue(changedModules[2].HasConstantAdded("InstantAllowed"));
            Assert.IsTrue(changedModules[2].HasConstantAdded("MaxProposals"));
            Assert.That(changedModules[2].Errors.Count(), Is.EqualTo(5));
            Assert.IsFalse(changedModules[2].HasErrorAdded("test"));
            Assert.IsFalse(changedModules[2].HasErrorRemoved("test2"));
        }

        [Test]
        public async Task MetadataV14_SpecVersionCompare_V9110_And_V9122_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V14\\MetadataV14_9110");
            var metadataDestination = readMetadataFromFile("V14\\MetadataV14_9122");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V14));

            var res = await _metadataService.MetadataCompareV14Async(
                new MetadataV14(metadataSource),
                new MetadataV14(metadataDestination));

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MetadataV14_SpecVersionCompare_V9420_And_V9430_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V14\\MetadataV14_9420");
            var metadataDestination = readMetadataFromFile("V14\\MetadataV14_9430");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V14));

            var res = await _metadataService.MetadataCompareV14Async(
                new MetadataV14(metadataSource),
                new MetadataV14(metadataDestination));

            Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task MetadataV14_SpecVersionCompare_V9370_And_V9420_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V14\\MetadataV14_9370");
            var metadataDestination = readMetadataFromFile("V14\\MetadataV14_9420");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V14));

            var res = await _metadataService.MetadataCompareV14Async(
                new MetadataV14(metadataSource),
                new MetadataV14(metadataDestination));

            Assert.That(res, Is.Not.Null);

            Assert.IsTrue(res.AddedModules.Any(x => x.ModuleName == "ConvictionVoting"));
            Assert.IsTrue(res.AddedModules.Any(x => x.ModuleName == "Referenda"));
            Assert.IsTrue(res.AddedModules.Any(x => x.ModuleName == "Whitelist"));
        }

        [Test]
        public async Task MetadataV14_SpecVersionCompare_V9270_And_V9280_ShouldSucceedAsync()
        {
            var metadataSource = readMetadataFromFile("V14\\MetadataV14_9270");
            var metadataDestination = readMetadataFromFile("V14\\MetadataV14_9280");

            Assert.That(_metadataService.EnsureMetadataVersion(metadataSource, metadataDestination), Is.EqualTo(MetadataVersion.V14));

            var res = await _metadataService.MetadataCompareV14Async(
                new MetadataV14(metadataSource),
                new MetadataV14(metadataDestination));

            // For this version, NominationPools pallet has been added
            Assert.That(res, Is.Not.Null);
            Assert.That(res.AddedModules.Count, Is.EqualTo(1));
            Assert.That(res.AddedModules.First().ModuleName, Is.EqualTo("NominationPools"));
        }
    }
}
