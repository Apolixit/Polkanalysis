using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core.DispatchInfo
{
    [DomainMapping("frame_support/weights")]
    public enum DispatchClass
    {

        Normal = 0,

        Operational = 1,

        Mandatory = 2,
    }

    public sealed class EnumDispatchClass : BaseEnum<DispatchClass> 
    {
    }
}
