using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances
{
    public class AccountData : BaseType
    {
        public U128 Free { get; set; } = new U128();
        public U128 Reserved { get; set; } = new U128();

        public U128? MiscFrozen { get; set; }
        public U128? FeeFrozen { get; set; }
        public U128? Frozen { get; set; }
        public ExtraFlags? Flags { get; set; }

        public AccountData() { }

        public AccountData(U128 free, U128 reserved, U128 miscFrozen, U128 feeFrozen)
        {
            Create(free, reserved, miscFrozen, feeFrozen);
        }

        public AccountData(U128 free, U128 reserved, U128 frozen, ExtraFlags flags)
        {
            Create(free, reserved, frozen, flags);
        }

        public void Create(U128 free, U128 reserved, U128 miscFrozen, U128 feeFrozen)
        {
            Free = free;
            Reserved = reserved;
            MiscFrozen = miscFrozen;
            FeeFrozen = feeFrozen;

            Bytes = Encode();
            TypeSize = Free.TypeSize + Reserved.TypeSize + MiscFrozen.TypeSize + FeeFrozen.TypeSize;
        }

        public void Create(U128 free, U128 reserved, U128 frozen, ExtraFlags flags)
        {
            Free = free;
            Reserved = reserved;
            Frozen = frozen;
            Flags = flags;

            Bytes = Encode();
            TypeSize = Free.TypeSize + Reserved.TypeSize + Frozen.TypeSize + Flags.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());

            if(MiscFrozen is not null)
                result.AddRange(MiscFrozen.Encode());

            if (FeeFrozen is not null)
                result.AddRange(FeeFrozen.Encode());

            if (Frozen is not null)
                result.AddRange(Frozen.Encode());

            if (Flags is not null)
                result.AddRange(Flags.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            //var start = p;
            //Free = new U128();
            //Free.Decode(byteArray, ref p);
            //Reserved = new U128();
            //Reserved.Decode(byteArray, ref p);
            //MiscFrozen = new U128();
            //MiscFrozen.Decode(byteArray, ref p);
            //FeeFrozen = new U128();
            //FeeFrozen.Decode(byteArray, ref p);
            //TypeSize = p - start;
            throw new NotImplementedException();
        }
    }
}
