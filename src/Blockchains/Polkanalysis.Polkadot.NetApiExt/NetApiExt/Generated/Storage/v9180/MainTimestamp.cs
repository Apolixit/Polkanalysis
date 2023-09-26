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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180
{
    public sealed class TimestampStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> NowParams
        ///  Current time for the current block.
        /// </summary>
        public static string NowParams()
        {
            return RequestGenerator.GetStorage("Timestamp", "Now", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NowDefault
        /// Default value as hex string
        /// </summary>
        public static string NowDefault()
        {
            return "0x0000000000000000";
        }

        /// <summary>
        /// >> Now
        ///  Current time for the current block.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> Now(CancellationToken token)
        {
            string parameters = NowParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> DidUpdateParams
        ///  Did the timestamp get updated in this block?
        /// </summary>
        public static string DidUpdateParams()
        {
            return RequestGenerator.GetStorage("Timestamp", "DidUpdate", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> DidUpdateDefault
        /// Default value as hex string
        /// </summary>
        public static string DidUpdateDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> DidUpdate
        ///  Did the timestamp get updated in this block?
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> DidUpdate(CancellationToken token)
        {
            string parameters = DidUpdateParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockHash, token);
            return result;
        }

        public TimestampStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class TimestampConstants
    {
        /// <summary>
        /// >> MinimumPeriod
        ///  The minimum period between blocks. Beware that this is different to the *expected*
        ///  period that the block production apparatus provides. Your chosen consensus system will
        ///  generally work with this to determine a sensible block time. e.g. For Aura, it will be
        ///  double this period on default settings.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MinimumPeriod()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xB80B000000000000");
            return result;
        }
    }
}