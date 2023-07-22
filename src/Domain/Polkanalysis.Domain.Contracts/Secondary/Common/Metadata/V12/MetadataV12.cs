﻿using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12
{
    public class MetadataV12 : BaseMetadata<RuntimeMetadataV12>
    {
        public MetadataV12() : base()
        {
        }

        public MetadataV12(string hex) : base(hex)
        {
        }

        public override MetadataVersion Version => MetadataVersion.V12;

        public override string TypeName() => nameof(MetadataV12);
    }
}