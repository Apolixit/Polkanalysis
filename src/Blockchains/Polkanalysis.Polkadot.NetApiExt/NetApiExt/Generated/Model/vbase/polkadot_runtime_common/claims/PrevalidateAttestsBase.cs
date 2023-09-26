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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.claims
{
    /// <summary>
    /// >> 15732 - Composite[polkadot_runtime_common.claims.PrevalidateAttestsBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class PrevalidateAttestsBase : BaseType
    {
        public override System.String TypeName()
        {
            return "PrevalidateAttestsBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.claims.PrevalidateAttestsBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.claims.PrevalidateAttestsBase instance = null;
            if (version == 9110U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9140U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9270U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9281U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9291.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9360.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_runtime_common.claims.PrevalidateAttests();
                instance.Create(data);
            }

            return instance;
        }
    }
}