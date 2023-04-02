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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_bags_list.list
{
    
    
    /// <summary>
    /// >> 732 - Composite[pallet_bags_list.list.Node]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Node : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _id;
        
        /// <summary>
        /// >> prev
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> _prev;
        
        /// <summary>
        /// >> next
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> _next;
        
        /// <summary>
        /// >> bag_upper
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U64 _bagUpper;
        
        /// <summary>
        /// >> score
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U64 _score;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Prev
        {
            get
            {
                return this._prev;
            }
            set
            {
                this._prev = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Next
        {
            get
            {
                return this._next;
            }
            set
            {
                this._next = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U64 BagUpper
        {
            get
            {
                return this._bagUpper;
            }
            set
            {
                this._bagUpper = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U64 Score
        {
            get
            {
                return this._score;
            }
            set
            {
                this._score = value;
            }
        }
        
        public override string TypeName()
        {
            return "Node";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Prev.Encode());
            result.AddRange(Next.Encode());
            result.AddRange(BagUpper.Encode());
            result.AddRange(Score.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Id.Decode(byteArray, ref p);
            Prev = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>();
            Prev.Decode(byteArray, ref p);
            Next = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>();
            Next.Decode(byteArray, ref p);
            BagUpper = new Substrate.NetApi.Model.Types.Primitive.U64();
            BagUpper.Decode(byteArray, ref p);
            Score = new Substrate.NetApi.Model.Types.Primitive.U64();
            Score.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
