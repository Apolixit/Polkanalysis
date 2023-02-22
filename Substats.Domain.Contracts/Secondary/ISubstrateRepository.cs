using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Adapter.Block;
using Substats.Domain.Contracts.Secondary.Common;
using Substats.Domain.Contracts.Secondary.Contracts;
using Substats.Domain.Contracts.Secondary.Rpc;

namespace Substats.Domain.Contracts.Secondary
{
    public interface ISubstrateRepository : ITimeQueryable
    {
        public string BlockchainName { get; }
        public Hash GenesisHash { get; }
        public IMetadata RuntimeMetadata { get; }
        public IRuntimeVersion RuntimeVersion { get; }

        public ITimeQueryable At(U32 blockNumber);
        public ITimeQueryable At(BlockNumber blockNumber);
        public ITimeQueryable At(uint blockNumber);
        public ITimeQueryable At(Hash blockHash);
        public ITimeQueryable At(string blockHash);

        public IRpc Rpc { get; }
        public IConstants Constants { get; }
        public ICalls Calls { get; }
        public IEvents Events { get; }
        public IErrors Errors { get; }

        public bool IsConnected();
        public Task ConnectAsync();
        public Task CloseAsync();
        /// <summary>
        /// Check every 'millisecondCheck' if we are connected to blockchain and call the callback method with status
        /// If we are not connected, try to reconnect
        /// </summary>
        /// <param name="isConnectedCallback">Callback status method</param>
        /// <param name="cancellationToken">Allow to stop the check</param>
        /// <param name="millisecondCheck">Millisecond frequency to check if we are connected and try to reconnect</param>
        /// <returns></returns>
        Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500);

        /// <summary>
        /// Check if account address is valid for current Substrate blockchain
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool IsValidAccountAddress(string address);
    }
}
