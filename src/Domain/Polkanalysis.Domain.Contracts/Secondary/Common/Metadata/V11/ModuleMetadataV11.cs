﻿using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class ModuleMetadataV11 : BaseType
    {
        public Str Name { get; private set; }
        public BaseOpt<StorageMetadataV11> Storage { get; private set; }
        public BaseOpt<BaseVec<PalletCallMetadataV9>> Calls { get; private set; }
        public BaseOpt<BaseVec<PalletEventMetadataV9>> Events { get; private set; }
        public BaseVec<PalletConstantMetadataV9> Constants { get; private set; }
        public BaseVec<PalletErrorMetadataV9> Errors { get; private set; }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new Str();
            Name.Decode(byteArray, ref p);

            Storage = new BaseOpt<StorageMetadataV11>();
            Storage.Decode(byteArray, ref p);

            Calls = new BaseOpt<BaseVec<PalletCallMetadataV9>>();
            Calls.Decode(byteArray, ref p);

            Events = new BaseOpt<BaseVec<PalletEventMetadataV9>>();
            Events.Decode(byteArray, ref p);

            Constants = new BaseVec<PalletConstantMetadataV9>();
            Constants.Decode(byteArray, ref p);

            Errors = new BaseVec<PalletErrorMetadataV9>();
            Errors.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }
    }
}