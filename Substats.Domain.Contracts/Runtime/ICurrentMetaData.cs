using Ajuna.NetApi.Model.Meta;
using Substats.Domain.Contracts.Dto.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Runtime
{
    public interface ICurrentMetaData
    {
        /// <summary>
        /// Return current MetaData
        /// </summary>
        /// <returns></returns>
        public NodeMetadataV14 GetCurrentMetadata();

        /// <summary>
        /// Get current MetaData pallet module from pallet name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public PalletModule GetPalletModule(string palletName);

        /// <summary>
        /// Get current MetaData node type from type id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public NodeType GetPalletType(uint typeId);

        public TypeFieldDto BuildTypeField(NodeTypeField node);

        /// <summary>
        /// Build a "to Rust struct" implementation of given type
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string WriteType(uint typeId);

        /// <summary>
        /// Write node variant type
        /// A variant type is a struct which can change data depend of context
        /// For example in Rust : Option enum which can be Option<None> or Option<Some<T>>
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeVariant(NodeTypeVariant nodeType);


        public string WriteNodeCompact(NodeTypeCompact nodeType);

        /// <summary>
        /// The easiest value. Primitive is like U32, I54, Boolean etc
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodePrimitive(NodeTypePrimitive nodeType);


        public string WriteNodeComposite(NodeTypeComposite nodeType);

        /// <summary>
        /// A list of element
        /// In Rust it's Vec<T>
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeSequence(NodeTypeSequence nodeType);

        /// <summary>
        /// A tuple value (A, B)
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeTuple(NodeTypeTuple nodeType);

        /// <summary>
        /// The array type
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeArray(NodeTypeArray nodeType);

        /// <summary>
        /// Build a "to Rust struct" implementation of given type
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string BuildType(uint typeId);
    }
}
