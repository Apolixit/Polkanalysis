//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage
{
    
    
    public sealed class UtilityStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        public UtilityStorage(SubstrateClientExt client)
        {
            this._client = client;
        }
    }
    
    public sealed class UtilityCalls
    {
        
        /// <summary>
        /// >> batch
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method Batch(Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(24, "Utility", 0, "batch", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> as_derivative
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method AsDerivative(Substrate.NetApi.Model.Types.Primitive.U16 index, Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(24, "Utility", 1, "as_derivative", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> batch_all
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method BatchAll(Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(24, "Utility", 2, "batch_all", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> dispatch_as
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method DispatchAs(Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumOriginCaller as_origin, Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(as_origin.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(24, "Utility", 3, "dispatch_as", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_batch
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method ForceBatch(Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(24, "Utility", 4, "force_batch", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> with_weight
        /// Contains one variant per dispatchable that can be called by an extrinsic.
        /// </summary>
        public static Method WithWeight(Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumRuntimeCall call, Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_weights.weight_v2.Weight weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(call.Encode());
            byteArray.AddRange(weight.Encode());
            return new Method(24, "Utility", 5, "with_weight", byteArray.ToArray());
        }
    }
    
    public enum UtilityErrors
    {
        
        /// <summary>
        /// >> TooManyCalls
        /// Too many calls batched.
        /// </summary>
        TooManyCalls,
    }
}
