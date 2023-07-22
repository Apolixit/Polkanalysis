using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;

namespace Polkanalysis.Domain.Tests.Runtime.Metadata
{
    public class MetadataParsingTest
    {
        [Test]
        [TestCase(MetadataMocks.MetadataV11_0, 11)]
        [TestCase(MetadataMocks.MetadataV12_26, 12)]
        [TestCase(MetadataMocks.MetadataV13_9050, 13)]
        public void ValidMetadata_CheckVersion_ShouldWork(string metadata, int version)
        {
            var metadataInfo = new CheckRuntimeMetadata(metadata);

            Assert.That(metadataInfo.MetaDataInfo, Is.Not.Null);
            Assert.That(metadataInfo.MetaDataInfo.Version.Value, Is.EqualTo(version));
        }

        /// <summary>
        /// This <see cref="MetadataV11_Version_0"/> is the metadata from block 1
        /// This is V11 and SpecVersion = 0
        /// Verification of this unit test is done directly from Subscan : https://polkadot.subscan.io/runtime?version=0
        /// </summary>
        [Test]
        public void MetadataV11_ShouldBeParsed()
        {
            var metadataV11 = new MetadataV11();
            metadataV11.Create(MetadataMocks.MetadataV11_0);

            Assert.That(metadataV11, Is.Not.Null);
            Assert.That(metadataV11.RuntimeMetadataData.Modules.Value.Count, Is.EqualTo(31));
        }

        /// <summary>
        /// This <see cref="MetadataV12_26"/> is the metadata from block 3_000_000
        /// This is V12 and SpecVersion = 26
        /// Verification of this unit test is done directly from Subscan : https://polkadot.subscan.io/runtime?version=26
        /// </summary>
        [Test]
        public void MetadataV12_ShouldBeParsed()
        {
            var metadataV12 = new MetadataV12();
            metadataV12.Create(MetadataMocks.MetadataV12_26);

            Assert.That(metadataV12, Is.Not.Null);
            Assert.That(metadataV12.RuntimeMetadataData.Modules.Value.Count, Is.EqualTo(28));
        }

        /// <summary>
        /// This <see cref="MetadataV13_9050"/> is the metadata from block 6_000_000
        /// This is V13 and SpecVersion = 9,050
        /// Verification of this unit test is done directly from Subscan : https://polkadot.subscan.io/runtime?version=9050
        /// </summary>
        [Test]
        public void MetadataV13_ShouldBeParsed()
        {
            var metadataV13 = new MetadataV13();
            metadataV13.Create(MetadataMocks.MetadataV13_9050);

            Assert.That(metadataV13, Is.Not.Null);
            Assert.That(metadataV13.RuntimeMetadataData.Modules.Value.Count, Is.EqualTo(31));
        }
    }
}
