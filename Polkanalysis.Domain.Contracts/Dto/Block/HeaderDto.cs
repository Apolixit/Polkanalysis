using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.TypeConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Block
{
    public class HeaderDto
    {
        public HeaderDto() { }
        public HeaderDto(Header header) {
            ExtrinsicsRoot = header.ExtrinsicsRoot;
            Number = header.Number.Value;
            ParentHash = header.ParentHash;
            StateRoot = header.StateRoot;
        }

        public Hash ExtrinsicsRoot { get; set; } = new Hash();

        public ulong Number { get; set; }

        public Hash? ParentHash { get; set; }

        public Hash StateRoot { get; set; } = new Hash();
    }
}
