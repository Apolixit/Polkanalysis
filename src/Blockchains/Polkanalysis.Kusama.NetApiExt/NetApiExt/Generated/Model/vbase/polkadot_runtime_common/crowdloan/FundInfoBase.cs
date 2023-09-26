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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan
{
    /// <summary>
    /// >> 20638 - Composite[polkadot_runtime_common.crowdloan.FundInfoBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class FundInfoBase : BaseType
    {
        /// <summary>
        /// >> depositor
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Depositor { get; set; }
        /// <summary>
        /// >> verifier
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseValue Verifier { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        /// <summary>
        /// >> raised
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Raised { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 End { get; set; }
        /// <summary>
        /// >> cap
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Cap { get; set; }
        /// <summary>
        /// >> last_contribution
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnum LastContribution { get; set; }
        /// <summary>
        /// >> first_period
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FirstPeriod { get; set; }
        /// <summary>
        /// >> last_period
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LastPeriod { get; set; }
        /// <summary>
        /// >> fund_index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 FundIndex { get; set; }
        /// <summary>
        /// >> trie_index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TrieIndex { get; set; }

        public override System.String TypeName()
        {
            return "FundInfoBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Verifier.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Raised.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Cap.Encode());
            result.AddRange(LastContribution.Encode());
            result.AddRange(FirstPeriod.Encode());
            result.AddRange(LastPeriod.Encode());
            result.AddRange(FundIndex.Encode());
            result.AddRange(TrieIndex.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_common.crowdloan.FundInfoBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_runtime_common.crowdloan.FundInfo();
                instance.Create(data);
            }

            return instance;
        }
    }
}