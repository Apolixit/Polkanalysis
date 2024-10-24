using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface ICoreService
    {
        /// <summary>
        /// Return the datetime from the pallet timestamp
        /// </summary>
        /// <param name="blockHash">The hash of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DateTime> GetDateTimeFromTimestampAsync(Hash? blockHash, CancellationToken cancellationToken);

        /// <summary>
        /// Return the datetime from the pallet timestamp
        /// </summary>
        /// <param name="blockNum">The number of the block</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DateTime> GetDateTimeFromTimestampAsync(uint? blockNum, CancellationToken cancellationToken);
    }
}
