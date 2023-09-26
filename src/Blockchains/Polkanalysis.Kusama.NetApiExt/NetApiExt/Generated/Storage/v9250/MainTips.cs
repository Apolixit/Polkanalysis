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
using System.Threading.Tasks;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9250
{
    public sealed class TipsStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> TipsParams
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public static string TipsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Tips", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> TipsDefault
        /// Default value as hex string
        /// </summary>
        public static string TipsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Tips
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_tips.OpenTip> Tips(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = TipsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.pallet_tips.OpenTip>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReasonsParams
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public static string ReasonsParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Reasons", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Identity }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ReasonsDefault
        /// Default value as hex string
        /// </summary>
        public static string ReasonsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Reasons
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> Reasons(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = ReasonsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        public TipsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class TipsConstants
    {
        /// <summary>
        /// >> MaximumReasonLength
        ///  Maximum acceptable reason length.
        /// 
        ///  Benchmarks depend on this value, be sure to update weights file when changing this value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaximumReasonLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00400000");
            return result;
        }

        /// <summary>
        /// >> DataDepositPerByte
        ///  The amount held on deposit per byte within the tip report reason or bounty description.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x55A0FC01000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> TipCountdown
        ///  The period for which a tip remains open after is has achieved threshold tippers.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TipCountdown()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40380000");
            return result;
        }

        /// <summary>
        /// >> TipFindersFee
        ///  The percent of the final tip which goes to the original reporter of the tip.
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Percent TipFindersFee()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9250.sp_arithmetic.per_things.Percent();
            result.Create("0x14");
            return result;
        }

        /// <summary>
        /// >> TipReportDepositBase
        ///  The amount held on deposit for placing a tip report.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TipReportDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x34A1AEC6000000000000000000000000");
            return result;
        }
    }

    public enum TipsErrors
    {
        /// <summary>
        /// >> ReasonTooBig
        /// The reason given is just too big.
        /// </summary>
        ReasonTooBig,
        /// <summary>
        /// >> AlreadyKnown
        /// The tip was already found/started.
        /// </summary>
        AlreadyKnown,
        /// <summary>
        /// >> UnknownTip
        /// The tip hash is unknown.
        /// </summary>
        UnknownTip,
        /// <summary>
        /// >> NotFinder
        /// The account attempting to retract the tip is not the finder of the tip.
        /// </summary>
        NotFinder,
        /// <summary>
        /// >> StillOpen
        /// The tip cannot be claimed/closed because there are not enough tippers yet.
        /// </summary>
        StillOpen,
        /// <summary>
        /// >> Premature
        /// The tip cannot be claimed/closed because it's still in the countdown period.
        /// </summary>
        Premature
    }
}