using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14
{
    public class MetadataV14 : BaseMetadata<RuntimeMetadataV14>
    {
        public MetadataV14() : base()
        {
        }

        public MetadataV14(string hex) : base(hex)
        {
        }

        public override MetadataVersion Version => MetadataVersion.V14;
        public override string TypeName() => nameof(MetadataV14);
    }
}
