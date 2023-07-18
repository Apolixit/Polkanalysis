using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9
{
    public class MetadataV9 : BaseMetadata<RuntimeMetadataV9>
    {
        public MetadataV9() : base()
        {
        }

        public MetadataV9(string hex) : base(hex)
        {
        }

        public override MetadataVersion Version => MetadataVersion.V9;

        public override string TypeName() => nameof(MetadataV9);
    }
}
