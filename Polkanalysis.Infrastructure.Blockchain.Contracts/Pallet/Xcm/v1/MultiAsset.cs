using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1
{
    public class MultiAsset : BaseType
    {
        public EnumAssetId Id { get; set; }
        public EnumFungibility Fun { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Fun.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new EnumAssetId();
            Id.Decode(byteArray, ref p);
            Fun = new EnumFungibility();
            Fun.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
