//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Blazscan.NetApiExt.Generated.Model.sp_runtime
{
    
    
    /// <summary>
    /// >> 24 - Composite[sp_runtime.ModuleError]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ModuleError : BaseType
    {
        
        /// <summary>
        /// >> index
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U8 _index;
        
        /// <summary>
        /// >> error
        /// </summary>
        private Blazscan.NetApiExt.Generated.Types.Base.Arr4U8 _error;
        
        public Ajuna.NetApi.Model.Types.Primitive.U8 Index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }
        
        public Blazscan.NetApiExt.Generated.Types.Base.Arr4U8 Error
        {
            get
            {
                return this._error;
            }
            set
            {
                this._error = value;
            }
        }
        
        public override string TypeName()
        {
            return "ModuleError";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Error.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Ajuna.NetApi.Model.Types.Primitive.U8();
            Index.Decode(byteArray, ref p);
            Error = new Blazscan.NetApiExt.Generated.Types.Base.Arr4U8();
            Error.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
