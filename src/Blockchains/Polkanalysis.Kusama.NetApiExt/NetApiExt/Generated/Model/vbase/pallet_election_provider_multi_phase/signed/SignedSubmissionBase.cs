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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase.signed
{
    /// <summary>
    /// >> 20586 - Composite[pallet_election_provider_multi_phase.signed.SignedSubmissionBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class SignedSubmissionBase : BaseType
    {
        /// <summary>
        /// >> who
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_core.crypto.AccountId32Base Who { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        /// <summary>
        /// >> raw_solution
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase.RawSolutionBase RawSolution { get; set; }
        /// <summary>
        /// >> call_fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CallFee { get; set; }
        /// <summary>
        /// >> reward
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Reward { get; set; }

        public override System.String TypeName()
        {
            return "SignedSubmissionBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(RawSolution.Encode());
            result.AddRange(CallFee.Encode());
            result.AddRange(Reward.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase.signed.SignedSubmissionBase Create(byte[] data, uint version)
        {
            Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase.signed.SignedSubmissionBase instance = null;
            if (version == 9430U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9420U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9381U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9370U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9370.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9360U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9350U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9350.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9340U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9320U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9300U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9291U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9291.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9280U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9280.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9271U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9271.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9260U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9250U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9230U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9220U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9200U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9200.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9190U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9180U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9170U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9170.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9160U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9151U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9151.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9150U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9130U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9130.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9122U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            if (version == 9111U)
            {
                instance = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_election_provider_multi_phase.signed.SignedSubmission();
                instance.Create(data);
            }

            return instance;
        }
    }
}