using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ParaGenesisArgs : BaseType
    {
        public DataCode GenesisHead { get; set; }
        public DataCode ValidationCode { get; set; }
        public Bool ParaKind { get; set; }

        public ParaGenesisArgs() { }

        public ParaGenesisArgs(DataCode genesisHead, DataCode validationCode, Bool paraKind)
        {
            Create(genesisHead, validationCode, paraKind);
        }

        public void Create(DataCode genesisHead, DataCode validationCode, Bool paraKind)
        {
            GenesisHead = genesisHead;
            ValidationCode = validationCode;
            ParaKind = paraKind;

            Bytes = Encode();
            TypeSize = GenesisHead.TypeSize + ValidationCode.TypeSize + ParaKind.TypeSize;
        }



        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(GenesisHead.Encode());
            result.AddRange(ValidationCode.Encode());
            result.AddRange(ParaKind.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            GenesisHead = new DataCode();
            GenesisHead.Decode(byteArray, ref p);
            ValidationCode = new DataCode();
            ValidationCode.Decode(byteArray, ref p);
            ParaKind = new Bool();
            ParaKind.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
