using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IRepositoryRequirement
    {
        public IEnumerable<IPalletStorage?> RequiredStorage { get; }
    }
}
