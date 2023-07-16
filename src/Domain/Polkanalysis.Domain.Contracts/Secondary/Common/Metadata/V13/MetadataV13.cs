﻿using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13
{
    public class MetadataV13 : BaseMetadata<RuntimeMetadataV13>
    {
        public override string TypeName() => nameof(MetadataV13);
    }
}
