using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base.Portable
{
    public class PortableRegistry : BaseVec<PortableType>
    {
        public override string TypeName() => "PortableRegistry";
    }
}