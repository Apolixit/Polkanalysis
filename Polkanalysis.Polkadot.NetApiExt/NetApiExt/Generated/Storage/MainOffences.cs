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
    
    
    public sealed class OffencesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public OffencesStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Offences", "Reports"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256), typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_staking.offence.OffenceDetails)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Offences", "ConcurrentReportsIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Offences", "ReportsByKindIndex"), new System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                            Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8), typeof(Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>)));
        }
        
        /// <summary>
        /// >> ReportsParams
        ///  The primary structure that holds all offence records keyed by report identifiers.
        /// </summary>
        public static string ReportsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Offences", "Reports", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ReportsDefault
        /// Default value as hex string
        /// </summary>
        public static string ReportsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Reports
        ///  The primary structure that holds all offence records keyed by report identifiers.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_staking.offence.OffenceDetails> Reports(Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = OffencesStorage.ReportsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_staking.offence.OffenceDetails>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ConcurrentReportsIndexParams
        ///  A vector of reports of the same kind that happened at the same time slot.
        /// </summary>
        public static string ConcurrentReportsIndexParams(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> key)
        {
            return RequestGenerator.GetStorage("Offences", "ConcurrentReportsIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> ConcurrentReportsIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string ConcurrentReportsIndexDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ConcurrentReportsIndex
        ///  A vector of reports of the same kind that happened at the same time slot.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256>> ConcurrentReportsIndex(Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> key, CancellationToken token)
        {
            string parameters = OffencesStorage.ConcurrentReportsIndexParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256>>(parameters, token);
            return result;
        }
        
        /// <summary>
        /// >> ReportsByKindIndexParams
        ///  Enumerates all reports of a kind along with the time they happened.
        /// 
        ///  All reports are sorted by the time of offence.
        /// 
        ///  Note that the actual type of this mapping is `Vec<u8>`, this is because values of
        ///  different types are not supported at the moment so we are doing the manual serialization.
        /// </summary>
        public static string ReportsByKindIndexParams(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8 key)
        {
            return RequestGenerator.GetStorage("Offences", "ReportsByKindIndex", Ajuna.NetApi.Model.Meta.Storage.Type.Map, new Ajuna.NetApi.Model.Meta.Storage.Hasher[] {
                        Ajuna.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Ajuna.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ReportsByKindIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string ReportsByKindIndexDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ReportsByKindIndex
        ///  Enumerates all reports of a kind along with the time they happened.
        /// 
        ///  All reports are sorted by the time of offence.
        /// 
        ///  Note that the actual type of this mapping is `Vec<u8>`, this is because values of
        ///  different types are not supported at the moment so we are doing the manual serialization.
        /// </summary>
        public async Task<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> ReportsByKindIndex(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8 key, CancellationToken token)
        {
            string parameters = OffencesStorage.ReportsByKindIndexParams(key);
            var result = await _client.GetStorageAsync<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>(parameters, token);
            return result;
        }
    }
    
    public sealed class OffencesCalls
    {
    }
    
    public sealed class OffencesConstants
    {
    }
}