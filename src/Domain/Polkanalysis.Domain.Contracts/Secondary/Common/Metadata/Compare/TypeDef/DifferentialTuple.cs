using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare.TypeDef
{
    public class DifferentialTuple : DifferentialBase<TType>
    {
        public static DifferentialTuple From(CompareStatus compareStatus, TypeDefTuple typeDef)
        {
            return new DifferentialTuple()
            {
                Elems = typeDef.Fields.Value.Select(x => (compareStatus, x))
            };
        }
    }
}
