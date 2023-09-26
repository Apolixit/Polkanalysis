//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_nomination_pools;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools
{
    /// <summary>
    /// >> 13779 - Composite[pallet_nomination_pools.PoolRoles]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PoolRoles : PoolRolesBase
    {
        public override System.String TypeName()
        {
            return "PoolRoles";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Root.Encode());
            result.AddRange(Nominator.Encode());
            result.AddRange(StateToggler.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Depositor = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32();
            Depositor.Decode(byteArray, ref p);
            Root = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32>();
            Root.Decode(byteArray, ref p);
            Nominator = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32>();
            Nominator.Decode(byteArray, ref p);
            StateToggler = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32>();
            StateToggler.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}