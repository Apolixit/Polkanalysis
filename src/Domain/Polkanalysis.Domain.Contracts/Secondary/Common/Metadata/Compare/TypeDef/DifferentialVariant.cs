using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare.TypeDef
{
    public class DifferentialVariant : DifferentialBase<Variant>
    {
        public static DifferentialVariant From(CompareStatus compareStatus, TypeDefVariant typeDef) {
            return new DifferentialVariant()
            {
                Elems = typeDef.TypeParam.Value.Select(x => (compareStatus, x))
            };
        }
    }
}
