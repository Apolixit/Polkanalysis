//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage
{
    
    
    public sealed class TipsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public TipsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Tips", "Tips"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_tips.OpenTip)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Tips", "Reasons"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
        }
        
        /// <summary>
        /// >> TipsParams
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public static string TipsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Tips", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_tips.OpenTip> Tips(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = TipsStorage.TipsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_tips.OpenTip>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ReasonsParams
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public static string ReasonsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Reasons", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Identity}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
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
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> Reasons(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = TipsStorage.ReasonsParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
            return result;
        }
    }
    
    public sealed class TipsCalls
    {
        
        /// <summary>
        /// >> report_awesome
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ReportAwesome(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> reason, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reason.Encode());
            byteArray.AddRange(who.Encode());
            return new Method(35, "Tips", 0, "report_awesome", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> retract_tip
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method RetractTip(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(35, "Tips", 1, "retract_tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> tip_new
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method TipNew(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> reason, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress who, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> tip_value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reason.Encode());
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(tip_value.Encode());
            return new Method(35, "Tips", 2, "tip_new", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> tip
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Tip(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 hash, Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> tip_value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            byteArray.AddRange(tip_value.Encode());
            return new Method(35, "Tips", 3, "tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> close_tip
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method CloseTip(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(35, "Tips", 4, "close_tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> slash_tip
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method SlashTip(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(35, "Tips", 5, "slash_tip", byteArray.ToArray());
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
        public Ajuna.NetApi.Model.Types.Primitive.U32 MaximumReasonLength()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00400000");
            return result;
        }
        
        /// <summary>
        /// >> DataDepositPerByte
        ///  The amount held on deposit per byte within the tip report reason or bounty description.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E1F505000000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> TipCountdown
        ///  The period for which a tip remains open after is has achieved threshold tippers.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U32 TipCountdown()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40380000");
            return result;
        }
        
        /// <summary>
        /// >> TipFindersFee
        ///  The percent of the final tip which goes to the original reporter of the tip.
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Percent TipFindersFee()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Percent();
            result.Create("0x14");
            return result;
        }
        
        /// <summary>
        /// >> TipReportDepositBase
        ///  The amount held on deposit for placing a tip report.
        /// </summary>
        public Ajuna.NetApi.Model.Types.Primitive.U128 TipReportDepositBase()
        {
            var result = new Ajuna.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00E40B54020000000000000000000000");
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
        Premature,
    }
}
