using System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base
{
    public class Field : BaseType, IMetadataType
    {
        public override string TypeName() => "Field<T: Form = MetaForm>";

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new BaseOpt<Str>();
            Name.Decode(byteArray, ref p);

            FieldTy = new TType();
            FieldTy.Decode(byteArray, ref p);

            FieldTypeName = new BaseOpt<Str>();
            FieldTypeName.Decode(byteArray, ref p);

            Docs = new BaseVec<Str>();
            Docs.Decode(byteArray, ref p);

            TypeSize = p - start;
        }

        public BaseOpt<Str> Name { get; private set; }
        public TType FieldTy { get; private set; }
        public BaseOpt<Str> FieldTypeName { get; private set; }
        public BaseVec<Str> Docs { get; private set; }

        public TType ItemType => FieldTy;
    }
}