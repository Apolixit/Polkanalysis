using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Tests.UseCase.Runtime;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Dto
{
    public class CompareSpecVersionDtoTest
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        [TestCase(PalletVersionHandlerCommandTests.MetadataV14_9270, PalletVersionHandlerCommandTests.MetadataV14_9280)]
        public void CompareMetadataV14_ShouldSucceed(string metadataSource, string metadataTarget)
        {
            var comparison = new CompareSpecVersionDto(MetadataUtils.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget)));

            Assert.That(comparison.ModulesChanged.Count, Is.GreaterThan(1));
        }
    }
}
