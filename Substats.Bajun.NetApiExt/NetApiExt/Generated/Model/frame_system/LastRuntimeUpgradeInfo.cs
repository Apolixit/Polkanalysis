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


namespace Substats.Bajun.NetApiExt.Generated.Model.frame_system
{
    
    
    /// <summary>
    /// >> 119 - Composite[frame_system.LastRuntimeUpgradeInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class LastRuntimeUpgradeInfo : BaseType
    {
        
        /// <summary>
        /// >> spec_version
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> _specVersion;
        
        /// <summary>
        /// >> spec_name
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Str _specName;
        
        public Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> SpecVersion
        {
            get
            {
                return this._specVersion;
            }
            set
            {
                this._specVersion = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.Str SpecName
        {
            get
            {
                return this._specName;
            }
            set
            {
                this._specName = value;
            }
        }
        
        public override string TypeName()
        {
            return "LastRuntimeUpgradeInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpecVersion.Encode());
            result.AddRange(SpecName.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpecVersion = new Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>();
            SpecVersion.Decode(byteArray, ref p);
            SpecName = new Ajuna.NetApi.Model.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
