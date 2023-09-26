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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9281
{
    public sealed class OffencesStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> ReportsParams
        ///  The primary structure that holds all offence records keyed by report identifiers.
        /// </summary>
        public static string ReportsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Offences", "Reports", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_staking.offence.OffenceDetails> Reports(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.primitive_types.H256 key, CancellationToken token)
        {
            string parameters = ReportsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_staking.offence.OffenceDetails>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ConcurrentReportsIndexParams
        ///  A vector of reports of the same kind that happened at the same time slot.
        /// </summary>
        public static string ConcurrentReportsIndexParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> key)
        {
            return RequestGenerator.GetStorage("Offences", "ConcurrentReportsIndex", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat, Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, key.Value);
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.primitive_types.H256>> ConcurrentReportsIndex(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> key, CancellationToken token)
        {
            string parameters = ConcurrentReportsIndexParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.primitive_types.H256>>(parameters, blockHash, token);
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
            return RequestGenerator.GetStorage("Offences", "ReportsByKindIndex", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
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
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> ReportsByKindIndex(Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr16U8 key, CancellationToken token)
        {
            string parameters = ReportsByKindIndexParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        public OffencesStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class OffencesConstants
    {
    }
}