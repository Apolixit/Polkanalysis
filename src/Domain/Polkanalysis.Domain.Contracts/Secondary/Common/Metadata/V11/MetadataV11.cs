using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class MetadataV11 : BaseMetadata<RuntimeMetadataV11>
    {
        public MetadataV11() : base()
        {
        }

        public MetadataV11(string hex) : base(hex) 
        {
        }

        public override MetadataVersion Version => MetadataVersion.V11;

        public override string TypeName() => nameof(MetadataV11);
    }
}
