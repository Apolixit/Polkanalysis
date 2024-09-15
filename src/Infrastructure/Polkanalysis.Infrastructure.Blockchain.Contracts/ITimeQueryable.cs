using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts
{
    /// <summary>
    /// Request data about the blockchain at a specific time
    /// </summary>
    public interface ITimeQueryable
    {
        public IStorage Storage { get; }

        /// <summary>
        /// Get metadata from the blockchain
        /// Use <see cref="At"/> to get metadata at a specific block
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<MetaData> GetMetadataAsync(CancellationToken cancellationToken);
    }
}
