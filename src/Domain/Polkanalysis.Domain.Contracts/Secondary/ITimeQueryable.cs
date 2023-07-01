using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary
{
    public interface ITimeQueryable
    {
        public IStorage Storage { get; }
    }
}
