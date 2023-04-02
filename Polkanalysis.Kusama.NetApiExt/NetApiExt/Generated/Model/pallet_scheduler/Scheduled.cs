//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_scheduler
{
    
    
    /// <summary>
    /// >> 679 - Composite[pallet_scheduler.Scheduled]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Scheduled : BaseType
    {
        
        /// <summary>
        /// >> maybe_id
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8> _maybeId;
        
        /// <summary>
        /// >> priority
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U8 _priority;
        
        /// <summary>
        /// >> call
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded _call;
        
        /// <summary>
        /// >> maybe_periodic
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> _maybePeriodic;
        
        /// <summary>
        /// >> origin
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumOriginCaller _origin;
        
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8> MaybeId
        {
            get
            {
                return this._maybeId;
            }
            set
            {
                this._maybeId = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U8 Priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                this._priority = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded Call
        {
            get
            {
                return this._call;
            }
            set
            {
                this._call = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> MaybePeriodic
        {
            get
            {
                return this._maybePeriodic;
            }
            set
            {
                this._maybePeriodic = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumOriginCaller Origin
        {
            get
            {
                return this._origin;
            }
            set
            {
                this._origin = value;
            }
        }
        
        public override string TypeName()
        {
            return "Scheduled";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaybeId.Encode());
            result.AddRange(Priority.Encode());
            result.AddRange(Call.Encode());
            result.AddRange(MaybePeriodic.Encode());
            result.AddRange(Origin.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaybeId = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8>();
            MaybeId.Decode(byteArray, ref p);
            Priority = new Substrate.NetApi.Model.Types.Primitive.U8();
            Priority.Decode(byteArray, ref p);
            Call = new Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded();
            Call.Decode(byteArray, ref p);
            MaybePeriodic = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>();
            MaybePeriodic.Decode(byteArray, ref p);
            Origin = new Polkanalysis.Kusama.NetApiExt.Generated.Model.kusama_runtime.EnumOriginCaller();
            Origin.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
