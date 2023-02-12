using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    public class Avatar
    {
        public U16 SeasonId { get; set; }
        public Hash Dna { get; set; }
        public U32 Souls { get; set; }
    }
}
