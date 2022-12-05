﻿using Blazscan.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Repository
{
    public interface ISubstrateNodeRepository
    {
        /// <summary>
        /// Substrate client generated by the Ajuna SDK
        /// </summary>
        public SubstrateClientExt Client { get; }

        /// <summary>
        /// Check every 'millisecondCheck' if we are connected to blockchain and call the callback method with status
        /// If we are not connected, try to reconnect
        /// </summary>
        /// <param name="isConnectedCallback">Callback status method</param>
        /// <param name="cancellationToken">Allow to stop the check</param>
        /// <param name="millisecondCheck">Millisecond frequency to check if we are connected and try to reconnect</param>
        /// <returns></returns>
        Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500);
    }
}
