using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.AwesomeAvatars
{
    public class Avatar
    {
        public U16 SeasonId { get; set; } = new U16();
        public Hash Dna { get; set; } = new Hash();
        public U32 Souls { get; set; } = new U32();
    }
}
