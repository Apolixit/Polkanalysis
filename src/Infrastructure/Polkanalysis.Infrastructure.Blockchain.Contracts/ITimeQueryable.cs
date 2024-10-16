using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
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
        /// <summary>
        /// All storages of the current blockchain
        /// </summary>
        public IStorage Storage { get; }

        /// <summary>
        /// Build an extrinsic, given the current metadata (potentially old metadata if BlockHash has been set)
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        Task<IExtrinsic> GetExtrinsicAsync(string hex);

        /// <summary>
        /// Get metadata from the blockchain
        /// Use <see cref="At"/> to get metadata at a specific block
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(uint majorVersion, MetaData metadata)> GetMetadataWithVersionAsync(CancellationToken cancellationToken);
        Task<MetaData> GetMetadataAsync(CancellationToken cancellationToken);
    }
}
