using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    public class PublicSr25519 : Public
    {
        public override KeyType Key => KeyType.Sr25519;
    }
}
