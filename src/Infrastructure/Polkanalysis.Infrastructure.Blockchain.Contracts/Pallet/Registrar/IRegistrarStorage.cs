using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Registrar
{
    public interface IRegistrarStorage : IPalletStorage
    {
        /// <summary>
        /// Pending swap operations.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Id> PendingSwapAsync(Id key, CancellationToken token);

        /// <summary>
        ///  Amount held on deposit for each para and the original depositor.
        /// 
        ///  The given account ID is responsible for registering the code and initial head data, but may only do
        ///  so if it isn't yet registered. (After that, it's up to governance to do so.)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<ParaInfo> ParasAsync(Id key, CancellationToken token);

        /// <summary>
        /// The next free `ParaId`.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Id> NextFreeParaIdAsync(CancellationToken token);
    }
}
