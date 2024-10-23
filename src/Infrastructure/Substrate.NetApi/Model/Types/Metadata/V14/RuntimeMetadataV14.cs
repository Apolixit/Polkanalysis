using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using Substrate.NetApi.Model.Types.Metadata.Base.Portable;
using System;

namespace Substrate.NetApi.Model.Types.Metadata.V14
{
    /// <summary>
    /// Runtime Metadata V14
    /// </summary>
    public class RuntimeMetadataV14 : BaseType
    {
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Types = new PortableRegistry();
            Types.Decode(byteArray, ref p);

            Modules = new BaseVec<PalletMetadataV14>();
            Modules.Decode(byteArray, ref p);

            Extrinsic = new ExtrinsicMetadataV14();
            Extrinsic.Decode(byteArray, ref p);

            TypeId = new TType();
            TypeId.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        /// <summary>
        /// Types
        /// </summary>
        public PortableRegistry Types { get; private set; }

        /// <summary>
        /// Modules
        /// </summary>
        public BaseVec<PalletMetadataV14> Modules { get; private set; }

        /// <summary>
        /// Extrinsic
        /// </summary>
        public ExtrinsicMetadataV14 Extrinsic { get; private set; }

        /// <summary>
        /// Type Id
        /// </summary>
        public TType TypeId { get; private set; }
    }
}