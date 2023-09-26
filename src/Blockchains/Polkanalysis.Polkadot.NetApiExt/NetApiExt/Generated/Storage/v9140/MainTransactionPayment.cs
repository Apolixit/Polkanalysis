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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9140
{
    public sealed class TransactionPaymentStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> NextFeeMultiplierParams
        /// </summary>
        public static string NextFeeMultiplierParams()
        {
            return RequestGenerator.GetStorage("TransactionPayment", "NextFeeMultiplier", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextFeeMultiplierDefault
        /// Default value as hex string
        /// </summary>
        public static string NextFeeMultiplierDefault()
        {
            return "0x000064A7B3B6E00D0000000000000000";
        }

        /// <summary>
        /// >> NextFeeMultiplier
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.sp_arithmetic.fixed_point.FixedU128> NextFeeMultiplier(CancellationToken token)
        {
            string parameters = NextFeeMultiplierParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.sp_arithmetic.fixed_point.FixedU128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> StorageVersionParams
        /// </summary>
        public static string StorageVersionParams()
        {
            return RequestGenerator.GetStorage("TransactionPayment", "StorageVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> StorageVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string StorageVersionDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> StorageVersion
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_transaction_payment.EnumReleases> StorageVersion(CancellationToken token)
        {
            string parameters = StorageVersionParams();
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_transaction_payment.EnumReleases>(parameters, blockHash, token);
            return result;
        }

        public TransactionPaymentStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class TransactionPaymentConstants
    {
        /// <summary>
        /// >> TransactionByteFee
        ///  The fee to be paid for making a transaction; the per-byte portion.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TransactionByteFee()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x40420F00000000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> OperationalFeeMultiplier
        ///  A fee mulitplier for `Operational` extrinsics to compute "virtual tip" to boost their
        ///  `priority`
        /// 
        ///  This value is multipled by the `final_fee` to obtain a "virtual tip" that is later
        ///  added to a tip component in regular `priority` calculations.
        ///  It means that a `Normal` transaction can front-run a similarly-sized `Operational`
        ///  extrinsic (with no tip), by including a tip value greater than the virtual tip.
        /// 
        ///  ```rust,ignore
        ///  // For `Normal`
        ///  let priority = priority_calc(tip);
        /// 
        ///  // For `Operational`
        ///  let virtual_tip = (inclusion_fee + tip) * OperationalFeeMultiplier;
        ///  let priority = priority_calc(tip + virtual_tip);
        ///  ```
        /// 
        ///  Note that since we use `final_fee` the multiplier applies also to the regular `tip`
        ///  sent with the transaction. So, not only does the transaction get a priority bump based
        ///  on the `inclusion_fee`, but we also amplify the impact of tips applied to `Operational`
        ///  transactions.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 OperationalFeeMultiplier()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U8();
            result.Create("0x05");
            return result;
        }

        /// <summary>
        /// >> WeightToFee
        ///  The polynomial that is applied in order to derive fee from weight.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.frame_support.weights.WeightToFeeCoefficient> WeightToFee()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.frame_support.weights.WeightToFeeCoefficient>();
            result.Create("0x040000000000000000000000000000000000B4C4040001");
            return result;
        }
    }
}