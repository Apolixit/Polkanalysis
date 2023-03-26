using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Crowdloan
{
    public class FundInfo : BaseType
    {
        public SubstrateAccount Depositor { get; set; }
        public BaseOpt<EnumMultiSigner> Verifier { get; set; }
        public U128 Deposit { get; set; } = new U128();
        public U128 Raised { get; set; } = new U128();
        public U32 End { get; set; }
        public U128 Cap { get; set; } = new U128();
        public EnumLastContribution LastContribution { get; set; }
        public U32 FirstPeriod { get; set; }
        public U32 LastPeriod { get; set; }
        public U32 FundIndex { get; set; }

        public FundInfo() { }

        public FundInfo(
            SubstrateAccount depositor, 
            BaseOpt<EnumMultiSigner> verifier, 
            U128 deposit, 
            U128 raised, 
            U32 end, 
            U128 cap, 
            EnumLastContribution lastContribution, 
            U32 firstPeriod, 
            U32 lastPeriod, 
            U32 fundIndex)
        {
            Create(depositor, verifier, deposit, raised, end, cap, lastContribution, firstPeriod, lastPeriod, fundIndex);
        }

        public void Create(SubstrateAccount depositor,
            BaseOpt<EnumMultiSigner> verifier,
            U128 deposit,
            U128 raised,
            U32 end,
            U128 cap,
            EnumLastContribution lastContribution,
            U32 firstPeriod,
            U32 lastPeriod,
            U32 fundIndex)
        {
            Depositor = depositor;
            Verifier = verifier;
            Deposit = deposit;
            Raised = raised;
            End = end;
            Cap = cap;
            LastContribution = lastContribution;
            FirstPeriod = firstPeriod;
            LastPeriod = lastPeriod;
            FundIndex = fundIndex;

            Bytes = Encode();
            TypeSize =
                Depositor.TypeSize +
                Verifier.TypeSize +
                Deposit.TypeSize +
                Raised.TypeSize +
                End.TypeSize +
                Cap.TypeSize +
                LastContribution.TypeSize +
                FirstPeriod.TypeSize +
                LastPeriod.TypeSize +
                FundIndex.TypeSize;

        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Verifier.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Raised.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Cap.Encode());
            result.AddRange(LastContribution.Encode());
            result.AddRange(FirstPeriod.Encode());
            result.AddRange(LastPeriod.Encode());
            result.AddRange(FundIndex.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Depositor = new SubstrateAccount();
            Depositor.Decode(byteArray, ref p);
            Verifier = new BaseOpt<EnumMultiSigner>();
            Verifier.Decode(byteArray, ref p);
            Deposit = new U128();
            Deposit.Decode(byteArray, ref p);
            Raised = new U128();
            Raised.Decode(byteArray, ref p);
            End = new U32();
            End.Decode(byteArray, ref p);
            Cap = new U128();
            Cap.Decode(byteArray, ref p);
            LastContribution = new EnumLastContribution();
            LastContribution.Decode(byteArray, ref p);
            FirstPeriod = new U32();
            FirstPeriod.Decode(byteArray, ref p);
            LastPeriod = new U32();
            LastPeriod.Decode(byteArray, ref p);
            FundIndex = new U32();
            FundIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
