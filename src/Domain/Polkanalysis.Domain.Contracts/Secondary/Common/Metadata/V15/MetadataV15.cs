using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V15
{
    public class MetadataV15 : BaseMetadata<RuntimeMetadataV15>
    {
        public MetadataV15() : base()
        {
        }

        public MetadataV15(string hex) : base(hex)
        {
        }

        public override MetadataVersion Version => MetadataVersion.V15;
        public override string TypeName() => nameof(MetadataV15);
    }
}
