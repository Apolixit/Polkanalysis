using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14
{
    public class ModuleMetadataV14 : BaseType, IMetadataName
    {
        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<PalletStorageMetadataV14>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<PalletCallMetadata14>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<PalletEventMetadataV14>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV14>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseOpt<PalletErrorMetadataV14>();
            Errors.Decode(byteArray, ref p);

            Index = new U8();
            Index.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public Str Name { get; private set; }
        public BaseOpt<PalletStorageMetadataV14> Storage { get; private set; }
        public BaseOpt<PalletCallMetadata14> Calls { get; private set; }
        public BaseOpt<PalletEventMetadataV14> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV14> Constants { get; private set; }
        public BaseOpt<PalletErrorMetadataV14> Errors { get; private set; }
        public U8 Index { get; private set; }
    }
}
