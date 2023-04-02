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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types
{
    
    
    /// <summary>
    /// >> 103 - Composite[pallet_ajuna_awesome_avatars.types.Season]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Season : BaseType
    {
        
        /// <summary>
        /// >> name
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT1 _name;
        
        /// <summary>
        /// >> description
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT2 _description;
        
        /// <summary>
        /// >> early_start
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _earlyStart;
        
        /// <summary>
        /// >> start
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _start;
        
        /// <summary>
        /// >> end
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _end;
        
        /// <summary>
        /// >> max_variations
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U8 _maxVariations;
        
        /// <summary>
        /// >> max_components
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U8 _maxComponents;
        
        /// <summary>
        /// >> tiers
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 _tiers;
        
        /// <summary>
        /// >> p_single_mint
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 _pSingleMint;
        
        /// <summary>
        /// >> p_batch_mint
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 _pBatchMint;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT1 Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT2 Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 EarlyStart
        {
            get
            {
                return this._earlyStart;
            }
            set
            {
                this._earlyStart = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 Start
        {
            get
            {
                return this._start;
            }
            set
            {
                this._start = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 End
        {
            get
            {
                return this._end;
            }
            set
            {
                this._end = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U8 MaxVariations
        {
            get
            {
                return this._maxVariations;
            }
            set
            {
                this._maxVariations = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U8 MaxComponents
        {
            get
            {
                return this._maxComponents;
            }
            set
            {
                this._maxComponents = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3 Tiers
        {
            get
            {
                return this._tiers;
            }
            set
            {
                this._tiers = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 PSingleMint
        {
            get
            {
                return this._pSingleMint;
            }
            set
            {
                this._pSingleMint = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4 PBatchMint
        {
            get
            {
                return this._pBatchMint;
            }
            set
            {
                this._pBatchMint = value;
            }
        }
        
        public override string TypeName()
        {
            return "Season";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Name.Encode());
            result.AddRange(Description.Encode());
            result.AddRange(EarlyStart.Encode());
            result.AddRange(Start.Encode());
            result.AddRange(End.Encode());
            result.AddRange(MaxVariations.Encode());
            result.AddRange(MaxComponents.Encode());
            result.AddRange(Tiers.Encode());
            result.AddRange(PSingleMint.Encode());
            result.AddRange(PBatchMint.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Name = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT1();
            Name.Decode(byteArray, ref p);
            Description = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT2();
            Description.Decode(byteArray, ref p);
            EarlyStart = new Substrate.NetApi.Model.Types.Primitive.U32();
            EarlyStart.Decode(byteArray, ref p);
            Start = new Substrate.NetApi.Model.Types.Primitive.U32();
            Start.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            MaxVariations = new Substrate.NetApi.Model.Types.Primitive.U8();
            MaxVariations.Decode(byteArray, ref p);
            MaxComponents = new Substrate.NetApi.Model.Types.Primitive.U8();
            MaxComponents.Decode(byteArray, ref p);
            Tiers = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT3();
            Tiers.Decode(byteArray, ref p);
            PSingleMint = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4();
            PSingleMint.Decode(byteArray, ref p);
            PBatchMint = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec.BoundedVecT4();
            PBatchMint.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
