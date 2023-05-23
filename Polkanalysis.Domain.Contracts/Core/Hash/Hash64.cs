using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core
{
    public class Hash64 : Hash
    {
        public override int TypeSize => 64;
    }
}
