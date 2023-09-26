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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.xcm.double_encoded
{
    /// <summary>
    /// >> 20473 - Composite[xcm.double_encoded.DoubleEncodedT1Base]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class DoubleEncodedT1Base : BaseType
    {
        /// <summary>
        /// >> encoded
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Encoded { get; set; }

        public override System.String TypeName()
        {
            return "DoubleEncodedT1Base";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Encoded.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.xcm.double_encoded.DoubleEncodedT1Base Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.xcm.double_encoded.DoubleEncodedT1Base instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.xcm.double_encoded.DoubleEncodedT1();
                instance.Create(data);
            }

            return instance;
        }
    }
}