using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types
{
    public class PriceWithDirection : BaseType
    {
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Amount { get; set; } = default!;
        /// <summary>
        /// >> direction
        /// </summary>
        public EnumPriceDirection Direction { get; set; } = default!;

        public override String TypeName()
        {
            return "PriceWithDirection";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Amount.Encode());
            result.AddRange(Direction.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            Direction = new EnumPriceDirection();
            Direction.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
