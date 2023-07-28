using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare.TypeDef
{
    public class DifferentialComposite : DifferentialBase<Field>
    {
        public static DifferentialComposite From(CompareStatus compareStatus, TypeDefComposite typeDef)
        {
            return new DifferentialComposite()
            {
                Elems = typeDef.Fields.Value.Select(x => (compareStatus, x))
            };
        }
    }
}
