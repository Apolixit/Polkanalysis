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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime
{
    
    
    /// <summary>
    /// >> 738 - Composite[polkadot_runtime.Runtime]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Runtime : BaseType
    {
        
        public override string TypeName()
        {
            return "Runtime";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TypeSize = p - start;
        }
    }
}
