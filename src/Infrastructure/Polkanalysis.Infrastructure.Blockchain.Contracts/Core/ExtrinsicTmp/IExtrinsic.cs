using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public interface IExtrinsic
    {
        //
        // Summary:
        //     Signed
        public bool Signed { get; set; }

        //
        // Summary:
        //     Transaction Version
        public byte TransactionVersion { get; set; }

        //
        // Summary:
        //     Account
        public Account Account { get; set; }

        //
        // Summary:
        //     Era
        public Era Era { get; set; }

        //
        // Summary:
        //     Nonce
        public CompactInteger Nonce { get; set; }

        //
        // Summary:
        //     Charge
        public ChargeType Charge { get; set; }

        //
        // Summary:
        //     Method
        public Method Method { get; set; }

        //
        // Summary:
        //     Signature
        public byte[] Signature { get; set; }

        byte[] Encode();
    }
}
