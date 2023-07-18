using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.Tests.Runtime.Metadata;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Service
{
    public class MetadataServiceTest
    {
        private MetadataService _metadataService;

        [SetUp]
        public void Setup()
        {
            _metadataService = new MetadataService();
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
            var value = new Substrate.NetApi.Model.Types.Metadata.V14.ByteGetter();
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
        public async Task MetadataV11_RealUseCaseBetween_V0_And_V1_ShouldSucceedAsync()
        {
            Assert.That(_metadataService.EnsureMetadataVersion(
                    MetadataParsingTest.MetadataV11_Version_0, 
                    MetadataParsingTest.MetadataV11_Version_1), Is.EqualTo(MetadataVersion.V11));

            var res = await _metadataService.MetadataCompareV11Async(
                new MetadataV11(MetadataParsingTest.MetadataV11_Version_0), 
                new MetadataV11(MetadataParsingTest.MetadataV11_Version_1));

            Assert.That(res, Is.Not.Null);
        }
    }
}
