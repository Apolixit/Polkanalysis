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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto
{
    /// <summary>
    /// >> 15558 - Composite[sp_core.crypto.AccountId32Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class AccountId32Base : BaseType
    {
        /// <summary>
        /// >> value
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr32U8 Value { get; set; }

        public override System.String TypeName()
        {
            return "AccountId32Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32();
                instance.Create(data);
            }

            return instance;
        }
    }
}