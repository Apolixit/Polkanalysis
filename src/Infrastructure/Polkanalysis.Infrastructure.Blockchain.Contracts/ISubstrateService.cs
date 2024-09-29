using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts
{
    public interface ISubstrateService : ITimeQueryable
    {
        /// <summary>
        /// Other chains that this blockchain depends on
        /// For example, Polkadot depends on parachain like PeopleChain
        /// </summary>
        public IEnumerable<string> Dependencies { get; }
        public SubstrateClient AjunaClient { get; }
        public string BlockchainName { get; }
        public Hash GenesisHash { get; }
        public RuntimeVersion RuntimeVersion { get; }

        public ITimeQueryable At(U32 blockNumber);
        public ITimeQueryable At(BlockNumber blockNumber);
        public ITimeQueryable At(uint blockNumber);
        public ITimeQueryable At(int blockNumber);
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
