using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base
{
    public interface IMetadataName
    {
        public Str Name { get; }
    }

    public interface IMetadataType
    {
        public TType ItemType { get; }
    }
}
