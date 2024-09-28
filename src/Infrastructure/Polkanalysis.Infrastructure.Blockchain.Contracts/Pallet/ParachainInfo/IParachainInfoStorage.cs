using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParachainInfo
{
    public interface IParachainInfoStorage : IPalletStorage
    {
        /// <summary>
        /// ParachainId
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Id> ParachainIdAsync(CancellationToken token);
    }
}
