//using Ajuna.NetApi.Model.Types.Base;
//using Ajuna.NetApi.Model.Types.Primitive;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Substats.Domain.Contracts.Core.DispatchInfo
//{
//    public class Weight : BaseType
//    {
//        public U64 RefTime { get; set; }
//        public U64 ProofSize { get; set; }

//        public override byte[] Encode()
//        {
//            var result = new List<byte>();
//            result.AddRange(RefTime.Encode());
//            result.AddRange(ProofSize.Encode());
//            return result.ToArray();
//        }

//        public override void Decode(byte[] byteArray, ref int p)
//        {
//            var start = p;
//            RefTime = new U64();
//            RefTime.Decode(byteArray, ref p);
//            ProofSize = new U64();
//            ProofSize.Decode(byteArray, ref p);
//            TypeSize = p - start;
//        }
//    }
//}
